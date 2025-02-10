using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVVM_play.Models;


[Index(nameof(TaskStatusCd), nameof(TaskTypeCd), nameof(TaskClassCd))]
[Index(nameof(EncounterId), nameof(TaskTypeCd), nameof(TaskStatusCd))]
[Index(nameof(LocationCd), nameof(TaskStatusCd), nameof(TaskTypeCd), nameof(TaskDtTm))]
[Index(nameof(TaskTypeCd), nameof(TaskStatusCd))]
[Index(nameof(TaskClassCd), nameof(TaskStatusCd))]
[Index(nameof(PersonId), nameof(TaskTypeCd), nameof(TaskStatusCd), nameof(TaskDtTm), nameof(TaskClassCd), nameof(OrderId))]
public class TaskActivity : AuditableEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long TaskId { get; set; }

    public bool ActiveInd { get; set; } = true;
    public long ActiveStatusCd { get; set; } = 48; // Default Code
    public DateTime ActiveStatusDtTm { get; set; } = DateTime.Now;
    public long? ActiveStatusPrsnlId { get; set; }

    [MaxLength(255)]
    public string? BroadcastMessageUuid { get; set; }

    [MaxLength(255)]
    public string? CallerContactTxt { get; set; }

    [MaxLength(255)]
    public string? CallerName { get; set; }

    public long? CaresetId { get; set; }
    public long? CatalogCd { get; set; }
    public long CatalogTypeCd { get; set; }
    public long? ChartedByAgentCd { get; set; }

    [MaxLength(255)]
    public string? ChartedByAgentIdentifier { get; set; }

    [MaxLength(255)]
    public string? ChartingContextReference { get; set; }

    [MaxLength(255)]
    public string? Comments { get; set; }

    public bool ConfidentialInd { get; set; } = false;
    public long? ContainerId { get; set; }
    public bool ContinuousInd { get; set; } = false;
    public long? ContributorSystemCd { get; set; }
    public long? ConversationId { get; set; }
    public bool? DeliveryInd { get; set; }

    [MaxLength(255)]
    public string? EmailMessageIdent { get; set; }

    public long EncounterId { get; set; }
    public long? EventCd { get; set; }
    public long? EventClassCd { get; set; }
    public long EventId { get; set; } = 0;

    [MaxLength(100)]
    public string? ExternalReferenceNumber { get; set; }

    public long? FormatCd { get; set; }
    public long? IbRxReqPersonDemogId { get; set; }
    public long? InstId { get; set; }
    public bool? IvInd { get; set; }
    public bool? LinkedOrderInd { get; set; }
    public long? LocationCd { get; set; }
    public long? LocRoomCd { get; set; }
    public long? LocBedCd { get; set; }
    public long? MedOrderTypeCd { get; set; }

    [MaxLength(32000)]
    public string? MessageText { get; set; }

    public long? MsgSenderEmailInfoId { get; set; }
    public long? MsgSenderId { get; set; }
    public long? MsgSenderPersonId { get; set; }
    public long? MsgSenderPrsnlGroupId { get; set; }

    [MaxLength(255)]
    public string? MsgSubject { get; set; }
    public long? MsgSubjectCd { get; set; }
    public long? MsgTextId { get; set; }
    public long OrderId { get; set; }
    public long? OrigPoolTaskId { get; set; }
    public long? PerformedPrsnlId { get; set; }
    public long PersonId { get; set; }
    public long? PftQueueItemWfHistId { get; set; }
    public bool PhysicianOrderInd { get; set; } = false;
    public bool ReadInd { get; set; } = false;
    public long ReferenceTaskId { get; set; }
    public DateTime? RemindDtTm { get; set; }
    public bool RescheduleInd { get; set; } = false;
    public long? RescheduleReasonCd { get; set; }
    public long? ResponsiblePrsnlId { get; set; }
    public long? ResultSetId { get; set; }
    public bool RoutineInd { get; set; } = false;
    public DateTime? ScheduledDtTm { get; set; }
    public DateTime? SendEventValidFromDtTm { get; set; }

    [MaxLength(255)]
    public string? SourceTag { get; set; }

    public bool StatInd { get; set; } = false;
    public long? SuggestedEntityId { get; set; }

    [MaxLength(32)]
    public string? SuggestedEntityName { get; set; }

    public long TaskActivityCd { get; set; }
    public long? TaskActivityClassCd { get; set; }
    public long TaskClassCd { get; set; }
    public DateTime? TaskCreatedDtTm { get; set; }
    public DateTime? TaskDtTm { get; set; }
    public long TaskPriorityCd { get; set; } = 0;
    public long? TaskRoutingId { get; set; }
    public long TaskStatusCd { get; set; }
    public long? TaskStatusReasonCd { get; set; }
    public long? TaskSubtypeCd { get; set; }
    public long TaskTypeCd { get; set; }
    public int? TaskTz { get; set; }
    public short? TemplateTaskFlag { get; set; }
    public bool TpnInd { get; set; } = false;

    public override string ToString()
    {
        return $"<TaskActivity(TaskId={TaskId}, Status={TaskStatusCd}, ScheduledDtTm={ScheduledDtTm})>";
    }
}
