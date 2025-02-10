using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MVVM_play.Models;

public class CodeValue : AuditableEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long CodeValueId { get; set; }

    public bool ActiveInd { get; set; } = true;
    public long? ActiveTypeCd { get; set; }
    public long? ActiveStatusPrsnlId { get; set; }

    [Column(TypeName = "timestamp")]
    public DateTime BeginEffectiveDtTm { get; set; } = DateTime.Now;

    [MaxLength(12)]
    public string? Meaning { get; set; }

    [MaxLength(255)]
    public string? Cki { get; set; }

    public int CodeSet { get; set; }

    public int CollationSeq { get; set; } = 0;

    [MaxLength(255)]
    public string? ConceptCki { get; set; }

    public long DataStatusCd { get; set; } = 0;

    [Column(TypeName = "timestamp")]
    public DateTime? DataStatusDtTm { get; set; }

    public long? DataStatusPrsnlId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Definition { get; set; } = string.Empty;

    [Required]
    [MaxLength(60)]
    public string Description { get; set; } = string.Empty;

    [Required]
    [MaxLength(40)]
    public string Display { get; set; } = string.Empty;

    [Required]
    [MaxLength(40)]
    public string DisplayKey { get; set; } = string.Empty;

    [Column(TypeName = "timestamp")]
    public DateTime EndEffectiveDtTm { get; set; } = DateTime.Parse("2100-12-31T23:59:59.9999999");

    [Column(TypeName = "timestamp")]
    public DateTime? InactiveDtTm { get; set; }

    public long InstId { get; set; } = 0;

    public override string ToString()
    {
        return $"<CodeValue(CodeValueId={CodeValueId}, Display={Display}, Description={Description})>";
    }
}
