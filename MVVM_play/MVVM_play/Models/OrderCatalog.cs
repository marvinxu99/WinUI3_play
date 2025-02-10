using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace MVVM_play.Models
{
    [Index(nameof(PrimaryMnemonic), Name = "ix_primary_mnemonic")]
    public class OrderCatalog : AuditableEntity
    {
        [Key]
        public long CatalogCd { get; set; }

        [MaxLength(100)]
        public required string PrimaryMnemonic { get; set; }
        public bool? AbnReviewInd { get; set; }
        public bool ActiveInd { get; set; } = true;
        public long ActivityTypeCd { get; set; } = 0;
        public long ActivitySubtypeCd { get; set; } = 0;
        public bool AutoCancelInd { get; set; } = false;
        public bool BillOnlyInd { get; set; } = false;
        public long CatalogTypeCd { get; set; }
        [MaxLength(255)]
        public string? Cki { get; set; }
        public short? CommentTemplateFlag { get; set; }
        public bool CompleteUponOrderInd { get; set; } = false;
        [MaxLength(255)]
        public string? ConceptCki { get; set; }
        public long? ConsentFormFormatCd { get; set; }
        public bool ConsentFormInd { get; set; } = false;
        public long? ConsentFormRoutingCd { get; set; }
        public short ContOrderMethodFlag { get; set; } = 0;
        public long DcpClinCatCd { get; set; } = 0;
        public int DcDisplayDays { get; set; } = 0;
        public int DcInteractionDays { get; set; } = 0;
        [MaxLength(100)]
        public string? DeptDisplayName { get; set; }
        public bool DeptDupCheckInd { get; set; } = false;
        [MaxLength(100)]
        public string? Description { get; set; }
        public bool DisableOrderCommentInd { get; set; } = false;
        public bool DiscernAutoVerifyFlag { get; set; } = false;
        public int? DosingActIngredCode { get; set; }
        public bool? DosingAllIngredInd { get; set; }
        public bool DupCheckInd { get; set; } = false;
        public long EventCd { get; set; } = 0;
        public long FormId { get; set; } = 0;
        public short? FormLevel { get; set; }
        public long? InstId { get; set; }
        public bool InstRestrictionInd { get; set; } = false;
        public int ModifiableFlag { get; set; } = 0;
        public long OeFormatId { get; set; } = 0;
        public int OpDcDisplayDays { get; set; } = -1;
        public int OpDcInteractionDays { get; set; } = -1;
        public int OrderableTypeFlag { get; set; } = 0;
        public bool OrderReviewInd { get; set; } = false;
        public long OrdComTemplateLongTextId { get; set; } = 0;
        public int? PrepInfoFlag { get; set; }
        public bool PrintReqInd { get; set; } = false;
        public bool PromptInd { get; set; } = false;
        public bool QuickChartInd { get; set; } = false;
        public int? RefTextMask { get; set; }
        public long RequisitionFormatCd { get; set; } = 0;
        public long RequisitionRoutingCd { get; set; } = 0;
        public long ResourceRouteCd { get; set; } = 0;
        public int? ResourceRouteLvl { get; set; }
        public long ReviewHierarchyId { get; set; } = 0;
        public bool ScheduleInd { get; set; } = false;
        [MaxLength(50)]
        public string? SourceVocabIdent { get; set; }
        [MaxLength(12)]
        public string? SourceVocabMean { get; set; }
        public int StopDuration { get; set; } = 0;
        public long StopDurationUnitCd { get; set; } = 0;
        public long StopTypeCd { get; set; } = 0;
        [MaxLength(200)]
        public string? TxnIdText { get; set; }
        public bool VettingApprovalFlag { get; set; } = false;
        public long UpdtApplctx { get; set; } = 0;
        public int UpdtCnt { get; set; } = 0;
        public DateTime UpdtDtTm { get; set; } = DateTime.UtcNow;
        public long UpdtId { get; set; } = 0;
        public int UpdtTask { get; set; } = 0;


        public override string ToString()
        {
            return $"OrderCatalog: PrimaryMnemonic={PrimaryMnemonic}, CatalogCd={CatalogCd}";
        }
    }
}
