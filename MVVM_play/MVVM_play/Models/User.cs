namespace MVVM_play.Models;

internal class User
{
    public int Id { get; set; }  // Primary Key
    public required string Name { get; set; }
    public int Age { get; set; }
    public string? City { get; set; }
}
