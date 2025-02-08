using System;
using System.ComponentModel.DataAnnotations;

namespace MVVM_play.Models
{
    internal class LogEntry
    {
        [Key]
        public int Id { get; set; } // Primary Key

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        [Required]
        public string Level { get; set; } = "Information"; // Log Level

        [Required]
        public string Message { get; set; } = string.Empty;

        public string? Context { get; set; } // Optional structured data (JSON)
        public string MachineName { get; set; } = Environment.MachineName;
        public int ThreadId { get; set; } = Environment.CurrentManagedThreadId;
    }
}
