﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MVVM_play.Models;

public partial class DatabaseContext : DbContext
{
    public DbSet<ClinicalEvent> ClinicalEvent { get; set; }
    public DbSet<CodeValue> CodeValue { get; set; }
    public DbSet<CodeValueSet> CodeValueSet { get; set; }
    public DbSet<OrderCatalog> OrderCatalog { get; set; }
    public DbSet<OrderCatalogSynonym> OrderCatalogSynonym { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderAction> OrderAction { get; set; }
    public DbSet<OrderTask> OrderTask { get; set; }
    public DbSet<TaskActivity> TaskActivity { get; set; }


    public DbSet<User> Users { get; set; }  // Example table
    public DbSet<UserProfile> UserProfiles { get; set; }  // Example table
    public DbSet<UserProfileHx> UserProfilesHx { get; set; }  // Example table



    public DatabaseContext() { }  // Parameterless Constructor required for migrations

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options) { }

    //protected override void OnConfiguring(DbContextOptionsBuilder options)
    //    => options.UseSqlite("Data Source=app.db");  // SQLite Database
    ///* 
    // * C:\Users\marvi\AppData\Local\Packages\195ed4b8-05f1-488c-83c2-10626a775615_26xhmmqw87qyr\LocalState\app.db
    // */
    // BELOW IS NOT COMPATIBILIE WITH CLI
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        //string dbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "app.db");
        string dbPath = Path.Combine("E:/eDev/csharp/WinUI/MVVM_play/MVVM_play", "app.db");
        options.UseSqlite($"Data Source={dbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define One-to-One Relationship: User → UserProfile
        modelBuilder.Entity<User>()
            .HasOne(u => u.UserProfile)  // One User has One UserProfile
            .WithOne(up => up.User)  // One UserProfile belongs to One User
            .HasForeignKey<UserProfile>(up => up.UserId)  // UserId is the FK
            .OnDelete(DeleteBehavior.Cascade);  // Delete Profile when User is deleted

        // Define Foreign Key Relationship
        modelBuilder.Entity<UserProfileHx>()
            .HasOne(up => up.User)  // One UserProfile has one User
            .WithMany()  // One User can have multiple UserProfiles
            .HasForeignKey(up => up.UserId)  // Foreign Key
            .OnDelete(DeleteBehavior.Cascade);  // Delete UserProfile if User is delete

    }

    public void InitializeDatabase()
    {
        this.Database.EnsureCreated(); // Create database if not exists

        if (!Users.Any())  // Check if Users table is empty
        {
            Users.AddRange(
            [
                new User { Name = "Alice", Age = 25, City = "Vancouver" },
                new User { Name = "Bob", Age = 30, City = "Toronto" },
                new User { Name = "Charlie", Age = 35, City = "Calgary" },
                new User { Name = "David", Age = 40, City = "Montreal" },
                new User { Name = "Eve", Age = 28, City = "Ottawa" }
            ]);

            this.SaveChanges(); // Save data to SQLite
        }
    }

    // Method to get dynamic columns from a table
    public async Task<List<string>> GetColumnNamesAsync(string tableName)
    {
        var columns = new List<string>();

        using (var conn = this.Database.GetDbConnection())
        {
            await conn.OpenAsync();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = $"PRAGMA table_info({tableName})";
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        columns.Add(reader.GetString(1)); // Column name
                    }
                }
            }
        }

        return columns;
    }

    // Method to get dynamic data from a table
    public async Task<List<Dictionary<string, object>>> GetDataAsync(string tableName)
    {
        var data = new List<Dictionary<string, object>>();

        using (var conn = this.Database.GetDbConnection())
        {
            await conn.OpenAsync();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = $"SELECT * FROM {tableName}";
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var row = new Dictionary<string, object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row[reader.GetName(i)] = reader.GetValue(i);
                        }
                        data.Add(row);
                    }
                }
            }
        }

        return data;
    }


    public async Task CreateOrUpdateUserWithProfileAsync(User user, UserProfile userProfile)
    {
        using var transaction = await Database.BeginTransactionAsync(); // Begin Transaction

        try
        {
            // Step 1: Insert or Update User
            var existingUser = await Users.FindAsync(user.Id);
            if (existingUser == null)
            {
                Users.Add(user);
                await SaveChangesAsync(); // Save User first
            }
            else
            {
                Entry(existingUser).CurrentValues.SetValues(user);
                await SaveChangesAsync();
            }

            // Step 2: Insert or Update UserProfile (Ensure User Exists)
            var existingProfile = await UserProfiles.FirstOrDefaultAsync(p => p.UserId == user.Id);
            if (existingProfile == null)
            {
                userProfile.UserId = user.Id; // Set Foreign Key
                UserProfiles.Add(userProfile);
            }
            else
            {
                Entry(existingProfile).CurrentValues.SetValues(userProfile);
            }
            await SaveChangesAsync();

            // Step 3: Commit Transaction
            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(); // Rollback if any error occurs
            throw new Exception("Transaction failed: " + ex.Message);
        }
    }

    public override int SaveChanges()
    {
        ApplyTimestamps();  // Auto-update timestamps before saving
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ApplyTimestamps();  // Auto-update timestamps before saving
        return base.SaveChangesAsync(cancellationToken);
    }

    private void ApplyTimestamps()
    {
        var entries = ChangeTracker.Entries<IAuditable>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)   // New row → Set CreatedDateTime
            {
                entry.Property(u => u.CreatedBy).CurrentValue = "TestUser";
                entry.Property(u => u.CreatedDateTime).CurrentValue = DateTime.UtcNow;
                entry.Property(u => u.UpdatedBy).CurrentValue = "TestUser";
                entry.Property(u => u.UpdatedDateTime).CurrentValue = DateTime.UtcNow;

            }
            else if (entry.State == EntityState.Modified) // Update row → Update UpdateDateTime
            {
                entry.Property(u => u.UpdatedBy).CurrentValue = "TestUser";
                entry.Property(u => u.UpdatedDateTime).CurrentValue = DateTime.UtcNow;
            }
        }


    }
}
