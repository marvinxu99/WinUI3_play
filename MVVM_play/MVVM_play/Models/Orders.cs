using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVVM_play.Models
{
    [Table("Orders")]
    [Index(nameof(PersonId), nameof(CurrentStartDtTm), nameof(TemplateOrderFlag), nameof(CatalogTypeCd), Name = "ix_person_curstart_tflag_catalogtype")]
    [Index(nameof(PersonId), nameof(EncntrId), nameof(HideFlag), nameof(CurrentStartDtTm), nameof(ProjectedStopDtTm), Name = "ix_person_encntr_start_projstop")]
    [Index(nameof(PersonId), nameof(ProjectedStopDtTm), nameof(CatalogTypeCd), nameof(TemplateOrderFlag), nameof(EncntrId), Name = "ix_person_projstop_catalogtype_encntr")]
    [Index(nameof(OrderStatusCd), nameof(StatusDtTm), Name = "ix_orderstatus_statusdttm")]
    [Index(nameof(NeedRxVerifyFlag), nameof(ActivityTypeCd), nameof(CatalogTypeCd), nameof(EncntrId), Name = "ix_rxverify_acttype_catalogtype_encntr")]
    [Index(nameof(PersonId), nameof(UpdatedDateTime), Name = "ix_person_updtdttm")]
    [Index(nameof(OrigOrderDtTm), nameof(ProductId), nameof(OrderStatusCd), nameof(ActivityTypeCd), nameof(SynonymId), Name = "ix_origdttm_prodid_status_etc")]
    [Index(nameof(PersonId), nameof(OrderStatusCd), nameof(TemplateOrderFlag), Name = "ix_person_ordestatus_tflag")]
    [Index(nameof(EncntrId), nameof(CatalogTypeCd), nameof(CatalogCd), Name = "ix_encntr_catalogtype_catalog")]
    [Index(nameof(PersonId), nameof(CatalogCd), Name = "ix_person_catalog")]
    [Index(nameof(PersonId), nameof(CatalogTypeCd), Name = "ix_person_catalogtype")]
    [Index(nameof(PersonId), nameof(OrderStatusCd), nameof(CatalogTypeCd), Name = "ix_person_orderstatus_catalogtype")]
    [Index(nameof(UpdatedDateTime), nameof(OrderId), Name = "ix_updtdttm_orderid")]
    public class Order : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OrderId { get; set; }

        public bool ActiveInd { get; set; } = true;

        public long ActiveStatusCd { get; set; }

        public DateTime ActiveStatusDtTm { get; set; } = DateTime.Now;

        public long ActiveStatusPrsnlId { get; set; } = 0;

        public long ActivityTypeCd { get; set; } = 0;

        public short AdHocOrderFlag { get; set; } = 0;

        public long CatalogCd { get; set; } = 0;

        public long CatalogTypeCd { get; set; } = 0;

        [MaxLength(255)]
        public string? Cki { get; set; }

        [MaxLength(255)]
        public string? ClinicalDisplayLine { get; set; }

        public DateTime ClinRelevantUpdtDtTm { get; set; } = DateTime.Now;

        public int ClinRelevantUpdtTz { get; set; } = 0;

        public short CluSubkeyFlag { get; set; } = 0;

        public int CommentTypeMask { get; set; } = 0;

        public bool ConstantInd { get; set; } = false;

        public long ContributorSystemCd { get; set; } = 0;

        public short? CsFlag { get; set; }

        public long CsOrderId { get; set; } = 0;

        public DateTime CurrentStartDtTm { get; set; } = DateTime.Now;

        public int CurrentStartTz { get; set; } = 0;

        public int DayOfTreatmentSequence { get; set; } = 0;

        public long DcpClinCatCd { get; set; } = 0;

        [MaxLength(255)]
        public string? DeptMiscLine { get; set; }

        public long? DeptStatusCd { get; set; }

        public DateTime? DiscontinueEffectiveDtTm { get; set; }

        public int? DiscontinueEffectiveTz { get; set; }

        public bool DiscontinueInd { get; set; } = false;

        public long? DiscontinueTypeCd { get; set; }

        public short? DosingMethodFlag { get; set; }

        public long? EncounterFinancialId { get; set; }

        public long EncntrId { get; set; } = 0;

        public bool EsoNewOrderInd { get; set; } = false;

        public long? FormularyStatusCd { get; set; }

        public long FrequencyId { get; set; } = 0;

        public short FreqTypeFlag { get; set; } = 0;

        public long? FutureLocationFacilityCd { get; set; }

        public long? FutureLocationNurseUnitCd { get; set; }

        public short? GroupOrderFlag { get; set; }

        public long GroupOrderId { get; set; } = 0;

        public short HideFlag { get; set; } = 0;

        [MaxLength(100)]
        public string? HnaOrderMnemonic { get; set; }

        public bool IncompleteOrderInd { get; set; } = false;

        public bool? IngredientInd { get; set; }

        public long? InstId { get; set; }

        public bool? IntervalInd { get; set; }

        public bool? IVInd { get; set; }

        public long IvSetSynonymId { get; set; } = 0;

        public int LastActionSequence { get; set; } = 0;

        public int? LastCoreActionSequence { get; set; }

        public int? LastIngredActionSequence { get; set; }

        public long? LastUpdateProviderId { get; set; }

        public long? LatestCommunicationTypeCd { get; set; }

        public long? LinkNbr { get; set; }

        public short? LinkOrderFlag { get; set; }

        public long? LinkOrderId { get; set; }

        public short? LinkTypeFlag { get; set; }

        public long? MedOrderTypeCd { get; set; }

        public DateTime? ModifiedStartDtTm { get; set; }

        public bool NeedDoctorCosignInd { get; set; } = false;

        public bool NeedNurseReviewInd { get; set; } = false;

        public bool NeedPhysicianValidateInd { get; set; } = false;

        public short NeedRxClinReviewFlag { get; set; } = 0;

        public short NeedRxVerifyFlag { get; set; } = 0;

        public long OeFormatId { get; set; } = 0;

        public short OrderableTypeFlag { get; set; } = 0;

        [MaxLength(100)]
        public string? OrderedAsMnemonic { get; set; }

        public bool OrderCommentInd { get; set; } = false;

        [MaxLength(255)]
        public string? OrderDetailDisplayLine { get; set; }

        [MaxLength(100)]
        [Required]
        public string OrderMnemonic { get; set; } = null!;

        public long OrderStatusCd { get; set; } = 0;

        public DateTime StatusDtTm { get; set; } = DateTime.Now;

        public long? StatusPrsnlId { get; set; }

        public int? OrderStatusReasonBit { get; set; }

        public long? OriginatingEncntrId { get; set; } = 0;

        public int? OrigOrderConvsSeq { get; set; }

        public DateTime? OrigOrderDtTm { get; set; }

        public int? OrigOrderTz { get; set; }

        public short? OrigOrderAsFlag { get; set; }

        public short? OverrideFlag { get; set; }

        public long PathwayCatalogId { get; set; } = 0;

        public long PersonId { get; set; } = 0;

        public long? PrescriptionGroupValue { get; set; }

        public long? PrescriptionOrderId { get; set; }

        public bool PrnInd { get; set; } = false;

        public long? ProductId { get; set; } = 0;

        public DateTime? ProjectedStopDtTm { get; set; }

        public int? ProjectedStopTz { get; set; }

        public long? ProtocolOrderId { get; set; }

        public int? RefTextMask { get; set; }

        public DateTime? ResumeEffectiveDtTm { get; set; }

        public int? ResumeEffectiveTz { get; set; }

        public bool? ResumeInd { get; set; }

        public int? RxMask { get; set; }

        public long? SchStateCd { get; set; } = 0;

        [MaxLength(1000)]
        public string? SimplifiedDisplayLine { get; set; }

        public DateTime? SoftStopDtTm { get; set; }

        public int? SoftStopTz { get; set; }

        public long? SourceCd { get; set; }

        public long? StopTypeCd { get; set; }

        // In the original model, suspend_effective_dt_tm used a default value
        // such as datetime.fromisoformat(END_EFFECTIVE_DATE_ISO). Set this as needed.
        public DateTime SuspendEffectiveDtTm { get; set; }

        public int? SuspendEffectiveTz { get; set; }

        public bool? SuspendInd { get; set; }

        public long? SynonymId { get; set; } = 0;

        public int? TemplateCoreActionSequence { get; set; }

        public int? TemplateDoseSequence { get; set; }

        public short? TemplateOrderFlag { get; set; }

        public long TemplateOrderId { get; set; } = 0;

        public bool VettingApprovalFlag { get; set; } = false;
    }
}
