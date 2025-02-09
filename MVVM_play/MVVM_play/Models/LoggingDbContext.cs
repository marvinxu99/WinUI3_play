using Microsoft.EntityFrameworkCore;
using System.IO;

namespace MVVM_play.Models;

public class LoggingDbContext : DbContext
{
    public DbSet<LogEntry> Logs { get; set; }  // Log table

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        //string dbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "app.db");
        string dbPath = Path.Combine("E:/eDev/csharp/WinUI/MVVM_play/MVVM_play", "logging.db");
        options.UseSqlite($"Data Source={dbPath}");
    }
}
