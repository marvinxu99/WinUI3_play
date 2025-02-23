using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MVVM_play.Models;

/*
 * Since EF CLI cannot create DbContext automatically, manually provide the factory.
 */
public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
{
    public DatabaseContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();

        //optionsBuilder.UseSqlite("Data Source=app.db");  // Use relative path
        //                                                 // app.db location: E:\eDev\csharp\WinUI\MVVM_play\MVVM_play
        string connectionString = "Host=localhost;Port=5432;Database=mvvm_db;Username=winter;Password=123456";
        optionsBuilder.UseNpgsql(connectionString);

        return new DatabaseContext(optionsBuilder.Options);
    }
}
