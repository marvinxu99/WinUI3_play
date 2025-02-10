using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MVVM_play.Models;

[Index(nameof(TaskTypeCd), Name = "ix_task_type_cd")]
[Index(nameof(DcpFormRefId), Name = "ix_dcp_form_ref_id")]
public class OrderTask
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long ReferenceTaskId { get; set; }

    [Required]
    [MaxLength(100)]
    public string TaskDescription { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string TaskDescriptionKey { get; set; } = string.Empty;

    public long TaskTypeCd { get; set; }  // Codeset 6026

    public long TaskActivityCd { get; set; }  // Codeset 6027

    public bool ActiveInd { get; set; } = true;
    public bool AllPositionChartInd { get; set; } = false;

    [MaxLength(255)]
    public string? AppObjectName { get; set; }

    public bool CaptureBillInfoInd { get; set; } = false;

    public short? SystemUseTaskFlag { get; set; }
    public bool ChartNotDoneInd { get; set; } = false;

    public long? DcpFormRefId { get; set; }

    public long? EventCd { get; set; }
    public int GracePeriodMins { get; set; } = 30;
    public bool IgnoreFreqInd { get; set; } = false;
    public long? InstId { get; set; }
    public int OverdueMins { get; set; } = 60;
    public long? ProcessLocationCd { get; set; }
    public bool QuickChartDoneInd { get; set; } = false;
    public int RescheduleTime { get; set; } = 72;
    public int RetainTime { get; set; } = 7;
    public int RetainUnits { get; set; } = 2; // 1-minute, 2-day, 3-week, 4-month

    [MaxLength(200)]
    public string? TxnIdText { get; set; }

    public override string ToString()
    {
        return $"<OrderTask(ReferenceTaskId={ReferenceTaskId}, TaskDescription={TaskDescription})>";
    }
}
