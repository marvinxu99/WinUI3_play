using Microsoft.EntityFrameworkCore;

namespace MVVM_play.Models;

public partial class LoggingDbContext : DbContext
{
    public DbSet<LogEntry> Logs { get; set; }  // Log table

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // SQLite
        //string dbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "app.db");
        //string dbPath = Path.Combine("E:/eDev/csharp/WinUI/MVVM_play/MVVM_play", "logging.db");
        //options.UseSqlite($"Data Source={dbPath}");

        // PostgreSQL
        string connectionString = "Host=localhost;Port=5432;Database=logging_db;Username=winter;Password=123456";
        options.UseNpgsql(connectionString);

    }
}
