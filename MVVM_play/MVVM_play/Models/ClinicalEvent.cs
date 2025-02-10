using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVVM_play.Models
{
    [Index(nameof(ReferenceNbr), nameof(ValidFromDtTm), nameof(ContributorSystemCd), Name = "ix_ref_num_validate_dttm_contrib")]
    [Index(nameof(EventId), nameof(ValidUntilDtTm), Name = "ix_event_id_validate_until")]
    [Index(nameof(PersonId), nameof(EventEndDtTm), nameof(ValidUntilDtTm), nameof(EncntrId), nameof(ResultStatusCd), nameof(PerformedPrsnlId), Name = "ix_personid_event_end_dttm_valid_encntrid")]
    [Index(nameof(EncntrId), nameof(ResultStatusCd), Name = "ix_encntr_id_result_status")]
    [Index(nameof(ParentEventId), nameof(ValidUntilDtTm), Name = "ix_parent_event_id_valid_until")]
    [Index(nameof(OrderId), nameof(ValidFromDtTm), Name = "ix_order_id_valid_from")]
    [Index(nameof(SrcEventId), nameof(ValidUntilDtTm), Name = "ix_src_event_id_valid_until")]
    [Index(nameof(CeDynamicLabelId), nameof(ValidUntilDtTm), Name = "ix_ce_dynamic_label_id_valid_until")]
    [Index(nameof(PersonId), nameof(EventCd), nameof(ClinsigUpdtDtTm), nameof(ValidUntilDtTm), Name = "ix_person_id_event_cd_valid_until")]
    [Index(nameof(PerformedDtTm), nameof(EventCd), Name = "ix_performed_dttm_event_cd")]
    [Index(nameof(PersonId), nameof(ValidFromDtTm), Name = "ix_person_id_valid_from")]
    [Index(nameof(EncntrId), nameof(ClinsigUpdtDtTm), Name = "ix_encntr_id_clinsig_updt_dttm")]
    [Index(nameof(EncntrId), nameof(EventClassCd), Name = "ix_encntr_id_event_class_cd")]
    [Index(nameof(EventCd), nameof(EventEndDtTm), Name = "ix_event_cd_event_end_dt_tm")]
    [Index(nameof(PersonId), nameof(UpdatedDateTime), Name = "ix_person_id_updat_dttm")]
    [Index(nameof(PersonId), nameof(EventCd), nameof(EventEndDtTm), nameof(ValidUntilDtTm), Name = "ix_personid_event_cd_event_end_dttm_valid_until")]
    [Index(nameof(SeriesRefNbr), Name = "ix_series_ref_nbr")]
    public class ClinicalEvent : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ClinicalEventId { get; set; }

        public string? AccessionNbr { get; set; }
        public short AuthenticFlag { get; set; } = 1;
        public long CatalogCd { get; set; } = 0;
        public long CeDynamicLabelId { get; set; } = 0;
        public string? ClinicalSeq { get; set; }
        public DateTime? ClinsigUpdtDtTm { get; set; }
        public short? CluSubkey1Flag { get; set; }
        public string? CollatingSeq { get; set; }
        public short ContributorSystemCd { get; set; } = 0;
        public string? CriticalHigh { get; set; }
        public string? CriticalLow { get; set; }
        public string? DeviceFreeTxt { get; set; }
        public long EncntrFinancialId { get; set; } = 0;
        public long EncntrId { get; set; } = 0;
        public long EntryModeCd { get; set; } = 0;
        public long EventCd { get; set; }
        public long EventClassCd { get; set; }
        public DateTime EventEndDtTm { get; set; }
        public decimal? EventEndDtTmOs { get; set; }
        public int? EventEndTz { get; set; }
        public long EventId { get; set; }
        public long EventReltnCd { get; set; }
        public DateTime? EventStartDtTm { get; set; }
        public int? EventStartTz { get; set; }
        public string EventTag { get; set; } = "";
        public short? EventTagSetFlag { get; set; }
        public string? EventTitleText { get; set; }
        public DateTime? ExpirationDtTm { get; set; }
        public long InquireSecurityCd { get; set; } = 0;
        public long? InstId { get; set; }
        public long ModifierLongTextId { get; set; } = 0;
        public short? NomenStringFlag { get; set; } = 1;
        public long NormalcyCd { get; set; } = 1;
        public long NormalcyMethodCd { get; set; } = 1;
        public string? NormalHigh { get; set; }
        public string? NormalLow { get; set; }
        public string? NormalRefRangeTxt { get; set; }
        public long? NoteImportanceBitMap { get; set; }
        public long OrderActionSequence { get; set; } = 0;
        public long OrderId { get; set; } = 0;
        public long ParentEventId { get; set; } = 0;
        public DateTime PerformedDtTm { get; set; } = DateTime.UtcNow;
        public int? PerformedTz { get; set; }
        public long PerformedPrsnlId { get; set; } = 0;
        public long PersonId { get; set; }
        public short PublishFlag { get; set; } = 1;
        public long QcReviewCd { get; set; } = 1;
        public long RecordStatusCd { get; set; }
        public string? ReferenceNbr { get; set; }
        public long? ResourceCd { get; set; }
        public long? ResourceGroupCd { get; set; }
        public long ResultStatusCd { get; set; }
        public long? ResultTimeUnitsCd { get; set; }
        public long? ResultUnitsCd { get; set; }
        public string? ResultVal { get; set; }
        public string? SeriesRefNbr { get; set; }
        public long? SourceCd { get; set; }
        public long SrcEventId { get; set; } = 0;
        public DateTime? SrcClinsigUpdtDtTm { get; set; }
        public int? SubtableBitMap { get; set; }
        public long? TaskAssayCd { get; set; }
        public long? TaskAssayVersionNbr { get; set; }
        public DateTime ValidFromDtTm { get; set; } = DateTime.UtcNow;
        public DateTime ValidUntilDtTm { get; set; } = DateTime.MaxValue;
        public DateTime? VerifiedDtTm { get; set; }
        public long VerifiedPrsnlId { get; set; } = 0;
        public int? ViewLevel { get; set; }

        public override string ToString()
        {
            return $"ClinicalEvent(ID={ClinicalEventId}, Result={ResultVal})";
        }
    }
}
