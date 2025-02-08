using MVVM_play.Models;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MVVM_play.Services
{
    public enum LogLevel
    {
        Trace,       // Very detailed logs, typically used for debugging
        Debug,       // Debugging information
        Information, // General information
        Warning,     // Warnings about potential issues
        Error,       // Errors that prevent normal execution
        Critical     // Fatal errors, application may crash
    }


    public class LoggingService
    {
        private readonly string _logFilePath;
        private const long MaxFileSizeBytes = 5 * 1024 * 1024; // 5MB max size before rotation
        private const int MaxLogFilesToKeep = 10; // Keep last 10 log files
        private static readonly ConcurrentQueue<LogEntry> _logQueue = new();
        private static readonly Task _logWriterTask;
        private static readonly Lock _lock = new();
        private readonly LoggingDbContext _dbContext;

        static LoggingService()
        {
            _logWriterTask = Task.Run(ProcessLogQueue);
        }

        public LoggingService(string logFilePath = "app.log")
        {
            _logFilePath = logFilePath;
            _dbContext = new LoggingDbContext();
            _dbContext.Database.EnsureCreated(); // Ensure database exists
        }

        public static void Log(LogLevel level, string message, object? context = null)
        {
            var logEntry = new LogEntry
            {
                Timestamp = DateTime.UtcNow,
                Level = level.ToString(),
                Message = message,
                Context = context != null ? JsonSerializer.Serialize(context) : null
            };

            _logQueue.Enqueue(logEntry);
            Console.WriteLine(JsonSerializer.Serialize(logEntry)); // Console output (optional)

            if (level == LogLevel.Critical)
            {
                Task.Run(() => SendEmailAlert(logEntry)); // Send email for Critical logs
            }
        }

        public static void Trace(string message, object? context = null) => Log(LogLevel.Trace, message, context);
        public void Debug(string message, object? context = null) => Log(LogLevel.Debug, message, context);
        public void Information(string message, object? context = null) => Log(LogLevel.Information, message, context);
        public void Warning(string message, object? context = null) => Log(LogLevel.Warning, message, context);
        public void Error(string message, object? context = null) => Log(LogLevel.Error, message, context);
        public void Critical(string message, object? context = null) => Log(LogLevel.Critical, message, context);

        private static async Task ProcessLogQueue()
        {
            using var dbContext = new LoggingDbContext();

            while (true)
            {
                if (!_logQueue.IsEmpty)
                {
                    lock (_lock)
                    {
                        RotateLogsIfNeeded(); // Check for log file rotation
                        using StreamWriter writer = new("app.log", append: true);

                        while (_logQueue.TryDequeue(out LogEntry? logEntry))
                        {
                            // Write to File
                            writer.WriteLine(JsonSerializer.Serialize(logEntry));

                            // Write to Database
                            dbContext.Logs.Add(logEntry);
                        }
                        dbContext.SaveChanges();
                    }
                }

                await Task.Delay(500); // Batch process logs every 500ms
            }
        }

        private static void RotateLogsIfNeeded()
        {
            FileInfo logFile = new("app.log");
            if (!logFile.Exists) return;

            if (logFile.Length > MaxFileSizeBytes)
            {
                string archiveName = $"logs/app_{DateTime.UtcNow:yyyyMMdd_HHmmss}.log";
                Directory.CreateDirectory("logs"); // Ensure logs folder exists
                File.Move("app.log", archiveName);

                Console.WriteLine($"Log file rotated: {archiveName}");

                // Cleanup old logs (keep last MaxLogFilesToKeep)
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

        private static void SendEmailAlert(LogEntry logEntry)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.your-email-provider.com") // Replace with actual SMTP server
                {
                    Port = 587, // Typically 587 for TLS, 465 for SSL
                    Credentials = new NetworkCredential("your-email@example.com", "your-email-password"), // Update credentials
                    EnableSsl = true
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("your-email@example.com"),
                    Subject = $"[CRITICAL] {logEntry.Message}",
                    Body = $"Timestamp: {logEntry.Timestamp}\n" +
                           $"Level: {logEntry.Level}\n" +
                           $"Message: {logEntry.Message}\n" +
                           $"Context: {logEntry.Context}\n" +
                           $"Machine: {logEntry.MachineName}\n" +
                           $"Thread: {logEntry.ThreadId}",
                    IsBodyHtml = false
                };

                mailMessage.To.Add("admin@example.com"); // Replace with recipient email

                smtpClient.Send(mailMessage);
                Console.WriteLine("Critical log email sent.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send alert email: {ex.Message}");
            }
        }
    }
}
