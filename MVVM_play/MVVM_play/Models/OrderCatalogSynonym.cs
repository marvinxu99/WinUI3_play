using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVVM_play.Models;


[Index(nameof(CatalogCd), nameof(MnemonicKeyCap), nameof(ItemId))]
[Index(nameof(CatalogTypeCd), nameof(MnemonicKeyCap))]
[Index(nameof(ActivityTypeCd), nameof(MnemonicKeyCap))]
[Index(nameof(MnemonicKeyCap), nameof(SynonymId))]
[Index(nameof(MnemonicKeyCap), nameof(MnemonicTypeCd), nameof(CatalogTypeCd), nameof(OrderableTypeFlag))]
public class OrderCatalogSynonym : AuditableEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long SynonymId { get; set; }

    public bool ActiveInd { get; set; } = true;
    public long ActiveStatusCd { get; set; } = 48; // Default Code
    public DateTime ActiveStatusDtTm { get; set; } = DateTime.Now;
    public long? ActiveStatusPrsnlId { get; set; }
    public long? ActivitySubtypeCd { get; set; }
    public long? ActivityTypeCd { get; set; }
    public short AuthorizationReviewFlag { get; set; } = 0;
    public bool? AutoprogSynInd { get; set; }
    public long CatalogCd { get; set; }
    public long CatalogTypeCd { get; set; }

    [MaxLength(255)]
    public string? Cki { get; set; }

    public decimal? ConcentrationStrength { get; set; }
    public long? ConcentrationStrengthUnitCd { get; set; }
    public decimal? ConcentrationVolume { get; set; }
    public long? ConcentrationVolumeUnitCd { get; set; }

    [MaxLength(255)]
    public string? ConceptCki { get; set; }

    public long? CsIndexCd { get; set; }
    public long DcpClinCatCd { get; set; }
    public bool? DisplayAdditivesFirstInd { get; set; }
    public bool? FilteredOdInd { get; set; }

    [MaxLength(255)]
    public string? HealthPlanView { get; set; }

    public short HideFlag { get; set; } = 0;
    public bool? HighAlertInd { get; set; }
    public long? HighAlertLongTextId { get; set; }
    public bool? HighAlertRequiredNtfyInd { get; set; }
    public bool? IgnoreHideConvertInd { get; set; }
    public bool? IngredientRateConversionInd { get; set; }
    public long? InstId { get; set; }
    public bool? IntermittentInd { get; set; }
    public long? ItemId { get; set; }
    public short? LastAdminDispBasisFlag { get; set; }
    public bool? LockTargetDoseInd { get; set; }
    public decimal? MaxDoseCalcBsaValue { get; set; }
    public decimal? MaxFinalDose { get; set; }
    public long? MaxFinalDoseUnitCd { get; set; }

    // 0.00	Use System Default
    // 1.00	Order Level
    // 2.00	Event Code Level
    public short MedIntervalWarnFlag { get; set; }

    [MaxLength(200)]
    public string Mnemonic { get; set; } = string.Empty;

    [MaxLength(200)]
    public string MnemonicKeyCap { get; set; } = string.Empty;

    [MaxLength(400)]
    public string MnemonicKeyCapANls { get; set; } = string.Empty;

    [MaxLength(405)]
    public string MnemonicKeyCapNls { get; set; } = string.Empty;

    public long MnemonicTypeCd { get; set; }
    public bool? MultipleOrdSentInd { get; set; }
    public long OeFormatId { get; set; }

    /* orderable_type_flag:
        0.00	Standard
          1.00	Standard
          2.00	Order Set/Care Set
          3.00	Care Plan
          4.00	AP Special
          5.00	Department Only
          6.00	Care Set - Order Set
          7.00	Home Health Problem
          8.00	Multi-Ingredient
          9.00	Interval test
         10.00	Freetext
         11.00	TPN
         12.00	Attachment
         13.00	Compound
         14.00	Complex IV
    */
    public short OrderableTypeFlag { get; set; }
    public long? OrderSentenceId { get; set; }
    public short? PreferredDoseFlag { get; set; }
    public int? RefTextMask { get; set; }   // Value that shows what parts of the online reference manual have been associated with the synonym
    public long? RoundingRuleCd { get; set; }
    public int? RxMask { get; set; }
    [MaxLength(100)]
    public string? VirtualView { get; set; }

    public short? WitnessFlag { get; set; }

    public override string ToString()
    {
        return $"<OrderCatalogSynonym(SynonymId={SynonymId}, Mnemonic={Mnemonic})>";
    }
}
