using MVVM_play.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MVVM_play.Services;

public enum LogLevel
{
    Trace,       // Very detailed logs, typically used for debugging
    Debug,       // Debugging information
    Information, // General information
    Warning,     // Warnings about potential issues
    Error,       // Errors that prevent normal execution
    Critical     // Fatal errors, application may crash
}

public partial class LoggingService : IDisposable
{
    private readonly LoggingDbContext _dbContext;

    private readonly string _logFilePath = Path.Combine("E:/eDev/csharp/WinUI/MVVM_play/MVVM_play", "app.log");
    private const long MaxFileSizeBytes = 5 * 1024 * 1024; // 5MB max size before rotation
    private const int MaxLogFilesToKeep = 10; // Keep last 10 log files
    private static readonly ConcurrentQueue<LogEntry> _logQueue = new();

    /* Using _cts ensures that background logging stops cleanly when the service is no longer needed. 
     * _cts.Cancel() is called on Dispose
     */
    private readonly CancellationTokenSource _cts = new();

    private readonly Task _logWriterTask;
    private static readonly Lock _fileLock = new();

    private bool _disposed = false;

    public LoggingService(LoggingDbContext dbContext)
    {
        System.Diagnostics.Debug.WriteLine("LoggingService constructor called.");

        _dbContext = dbContext;
        _dbContext.Database.EnsureCreated(); // Ensure database exists

        _logWriterTask = Task.Run(ProcessLogQueue);

        System.Diagnostics.Debug.WriteLine("ProcessLogQueue task started.");

        //TestLogging();

    }

    public void Log(LogLevel level, string message, object? context = null)
    {
        var logEntry = new LogEntry
        {
            Timestamp = DateTime.UtcNow,
            Level = level.ToString(),
            Message = message,
            Context = context != null ? JsonSerializer.Serialize(context) : null
        };

        _logQueue.Enqueue(logEntry);

        System.Diagnostics.Debug.WriteLine(JsonSerializer.Serialize(logEntry)); // Console output (optional)

        if (level == LogLevel.Critical)
        {
            _ = Task.Run(() => SendEmailAlert(logEntry)); // Send email for Critical logs
        }
    }

    public void Trace(string message, object? context = null) => Log(LogLevel.Trace, message, context);
    public void Debug(string message, object? context = null) => Log(LogLevel.Debug, message, context);
    public void Information(string message, object? context = null) => Log(LogLevel.Information, message, context);
    public void Warning(string message, object? context = null) => Log(LogLevel.Warning, message, context);
    public void Error(string message, object? context = null) => Log(LogLevel.Error, message, context);
    public void Critical(string message, object? context = null) => Log(LogLevel.Critical, message, context);

    private async Task ProcessLogQueue()
    {
        System.Diagnostics.Debug.WriteLine("Starting log processor...");

        while (!_cts.Token.IsCancellationRequested)
        {
            if (!_logQueue.IsEmpty)
            {
                List<LogEntry> logBatch = [];

                while (_logQueue.TryDequeue(out LogEntry? logEntry))
                {
                    logBatch.Add(logEntry);
                }

                if (logBatch.Count > 0)
                {
                    Console.WriteLine($"Processing {logBatch.Count} logs...");

                    lock (_fileLock)
                    {
                        RotateLogsIfNeeded();
                        using StreamWriter writer = new(_logFilePath, append: true);
                        foreach (var log in logBatch)
                        {
                            writer.WriteLine(JsonSerializer.Serialize(log));
                        }
                    }

                    await _dbContext.Logs.AddRangeAsync(logBatch);
                    await _dbContext.SaveChangesAsync();
                }
            }

            await Task.Delay(500, _cts.Token); // Batch process logs every 500ms
        }
    }

    private void RotateLogsIfNeeded()
    {
        FileInfo logFile = new(_logFilePath);
        if (!logFile.Exists) return;

        if (logFile.Length > MaxFileSizeBytes)
        {
            string archiveName = $"logs/app_{DateTime.UtcNow:yyyyMMdd_HHmmss}.log";
            Directory.CreateDirectory("logs");
            File.Move(_logFilePath, archiveName);

            System.Diagnostics.Debug.WriteLine($"Log file rotated: {archiveName}");

            var oldLogs = Directory.GetFiles("logs", "app_*.log")
                .Select(f => new FileInfo(f))
                .OrderByDescending(f => f.CreationTimeUtc)
                .Skip(MaxLogFilesToKeep)
                .ToList();

            foreach (var oldLog in oldLogs)
            {
                oldLog.Delete();
            }
        }
    }

    private void SendEmailAlert(LogEntry logEntry)
    {
        try
        {
            string? emailUser = Environment.GetEnvironmentVariable("EMAIL_USERNAME");
            string? emailPassword = Environment.GetEnvironmentVariable("EMAIL_PASSWORD");

            if (string.IsNullOrEmpty(emailUser) || string.IsNullOrEmpty(emailPassword))
            {
                System.Diagnostics.Debug.WriteLine("Email credentials are missing!");
                return;
            }

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(emailUser, emailPassword),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("marvinxu99@gmail.com"),
                Subject = $"[CRITICAL] {logEntry.Message}",
                Body = $"Timestamp: {logEntry.Timestamp}\n" +
                       $"Level: {logEntry.Level}\n" +
                       $"Message: {logEntry.Message}\n" +
                       $"Context: {logEntry.Context}\n",
                IsBodyHtml = false
            };

            mailMessage.To.Add("marvinxu99@hotmail.com");
            smtpClient.Send(mailMessage);
            System.Diagnostics.Debug.WriteLine("Critical log email sent.");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Failed to send alert email: {ex.Message}");
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /*
     * Handles both managed & unmanaged resources properly
     * Prevents multiple disposal attempts
     * Supports inheritance (if needed in derived classes)
     */
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        if (disposing)
        {
            System.Diagnostics.Debug.WriteLine("LoggingService is being disposed.");

            // Cancel the logging process
            _cts.Cancel();
            _logWriterTask.Wait();  // Ensure the task stops before disposing resources
            _cts.Dispose();
        }

        _disposed = true;
    }

    public void TestLogging()
    {
        //Log(LogLevel.Information, "Testing log queue processing.");
        Critical("Test Message");
    }

}
