using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVVM_play.Models
{
    [Index(nameof(ActionPersonnelId), nameof(ActionDtTm), nameof(ActionSequence), Name = "ix_prsnl_actiondttm_actionseq")]
    [Index(nameof(OrderProviderId), nameof(ActionDtTm), nameof(ActionSequence), Name = "ix_provider_actiondttm_actionseq")]
    [Index(nameof(OrderId), nameof(ActionSequence), Name = "ix_orderid_actionseq")]
    public class OrderAction : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OrderActionId { get; set; }

        public DateTime? ActionDtTm { get; set; }
        public int? ActionTz { get; set; }
        public DateTime? ActionInitiatedDtTm { get; set; }
        public long ActionPersonnelId { get; set; }
        public long? ActionQualifierCd { get; set; }
        public bool? ActionRejectedInd { get; set; }
        public int ActionSequence { get; set; }
        public long ActionTypeCd { get; set; }
        public short? BillingProviderFlag { get; set; }

        [MaxLength(255)]
        public string? ClinicalDisplayLine { get; set; }

        public long? CommunicationTypeCd { get; set; }
        public bool? ConstantInd { get; set; }
        public long? ContributorSystemCd { get; set; }
        public bool? CoreInd { get; set; }
        public DateTime CurrentStartDtTm { get; set; }
        public int? CurrentStartTz { get; set; }
        public long? DeptStatusCd { get; set; }

        [MaxLength(64)]
        public string? DigitalSignatureIdent { get; set; }

        public DateTime EffectiveDtTm { get; set; } = DateTime.Now;
        public int? EffectiveTz { get; set; }
        public long? EsoActionCd { get; set; }
        public long? FormularyStatusCd { get; set; }

        // This property is a foreign key to the frequency_schedule table.
        public long FrequencyId { get; set; }

        public bool? IncompleteOrderInd { get; set; }
        public bool? MedstudentActionInd { get; set; }
        public bool NeedsVerifyInd { get; set; }
        public bool NeedClinReviewFlag { get; set; }
        public DateTime? NextDoseDtTm { get; set; }
        public int? OrderAppNbr { get; set; }

        // This property is marked as indexed.
        public long? OrderConversationId { get; set; }

        public int? OrderConvsSeq { get; set; }

        [MaxLength(255)]
        public string? OrderDetailDisplayLine { get; set; }

        public DateTime OrderDtTm { get; set; } = DateTime.Now;
        public int? OrderTz { get; set; }

        // This property is a foreign key to the orders table.
        public long OrderId { get; set; }

        public long? OrderLocnCd { get; set; }
        public long? OrderProviderId { get; set; }
        public int? OrderReviewStatusReasonBit { get; set; }
        public int? OrderSchedulePrecisionBit { get; set; }
        public long OrderStatusCd { get; set; }
        public int? OrderStatusReasonBit { get; set; }
        public bool? PrnInd { get; set; }
        public DateTime? ProjectedStopDtTm { get; set; }
        public int? ProjectedStopTz { get; set; }
        public long? SchStateCd { get; set; }

        [MaxLength(1000)]
        public string? SimplifiedDisplayLine { get; set; }

        public int SourceDotActionSeq { get; set; } = 0;
        public long? SourceDotOrderId { get; set; }
        public int? SourceProtocolActionSeq { get; set; }
        public int? StartRangeNbr { get; set; }
        public short? StartRangeUnitFlag { get; set; }
        public long? StopTypeCd { get; set; }

        // This property is marked as indexed.
        public long? SupervisingProviderId { get; set; }

        // This property is a foreign key to the order_catalog_synonym table and is indexed.
        public long? SynonymId { get; set; }

        //#      0.00	None
        //#      1.00	Template
        //#      2.00	Order Based Instance
        //#      3.00	Task Based Instance
        //#      4.00	Rx Based Instance
        //#      5.00	Future Recurring Template
        //#      6.00	Future Recurring Instance
        public short TemplateOrderFlag { get; set; } = 0;
        public long? UndoActionTypeCd { get; set; }

        public DateTime? ValidDoseDtTm { get; set; }

        public override string ToString()
        {
            return $"<OrderAction(OrderActionId={OrderActionId}, ActionSequence={ActionSequence})>";
        }
    }
}
