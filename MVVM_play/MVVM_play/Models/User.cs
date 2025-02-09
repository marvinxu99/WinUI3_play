using System;

namespace MVVM_play.Models;

public class User
{
    public int Id { get; set; }  // Primary Key
    public required string Name { get; set; }
    public int Age { get; set; }
    public string? City { get; set; }

    // Add Navigation Property
    public UserProfile? UserProfile { get; set; }
    public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;  // Set only on INSERT
    public DateTime UpdateDateTime { get; set; } = DateTime.UtcNow;   // Auto-update on changes

}
