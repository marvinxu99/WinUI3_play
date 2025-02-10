using System;

namespace MVVM_play.Models;


/// <summary>
/// Interface representing audit fields to be recorded in all DB entities.
/// </summary>
public interface IAuditable
{
    /// <summary>
    /// Gets or sets the The audit created by field.
    /// </summary>
    string CreatedBy { get; set; }

    /// <summary>
    /// Gets or sets the audit created date/time field.
    /// </summary>
    DateTime CreatedDateTime { get; set; }

    /// <summary>
    /// Gets or sets the audit updated by field.
    /// </summary>
    string UpdatedBy { get; set; }

    /// <summary>
    /// Gets or sets the audit updated date/time.
    /// </summary>
    DateTime UpdatedDateTime { get; set; }
}
