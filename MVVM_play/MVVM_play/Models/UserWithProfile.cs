using System;

namespace MVVM_play.Models;

public class UserWithProfile
{
    public int Id { get; set; }  // User ID
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string? City { get; set; }

    // UserProfile fields
    public int UserProfileId { get; set; }
    public string? Gender { get; set; } = string.Empty;
    public string? PrimaryAddress { get; set; }
    public string? SecondaryAddress { get; set; }
    public string? AvatarUrl { get; set; }
    public DateTime? CreatedDateTime { get; set; }

    // Constructor to Map Data
    internal UserWithProfile(Models.User user, UserProfile? profile)
    {
        Id = user.Id;
        Name = user.Name;
        Age = user.Age;
        City = user.City;

        if (profile != null)
        {
            UserProfileId = profile.Id;
            Gender = profile.Gender;
            PrimaryAddress = profile.PrimaryAddress;
            SecondaryAddress = profile.SecondaryAddress;
            AvatarUrl = profile.AvatarUrl;
            CreatedDateTime = profile.CreatedDateTime;
        }
    }
}
