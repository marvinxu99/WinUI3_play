using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVVM_play.Models;

internal class UserProfile
{
    [Key]
    public int Id { get; set; }  // Primary Key

    //Foreign Key Property
    public int UserId { get; set; }

    //Navigation Property
    [ForeignKey("UserId")]
    public required User User { get; set; }

    public required string Gender { get; set; }

    public string? PrimaryAddress { get; set; }

    public string? SecondaryAddress { get; set; }

    public string? AvatarUrl { get; set; }

    public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;  // Track history time
}
