using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVVM_play.Migrations
{
    /// <inheritdoc />
    public partial class AddedCodeValueAndMore2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CodeValue",
                columns: table => new
                {
                    CodeValueId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ActiveInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    ActiveTypeCd = table.Column<long>(type: "INTEGER", nullable: true),
                    ActiveStatusPrsnlId = table.Column<long>(type: "INTEGER", nullable: true),
                    BeginEffectiveDtTm = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Meaning = table.Column<string>(type: "TEXT", maxLength: 12, nullable: true),
                    Cki = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    CodeSet = table.Column<int>(type: "INTEGER", nullable: false),
                    CollationSeq = table.Column<int>(type: "INTEGER", nullable: false),
                    ConceptCki = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    DataStatusCd = table.Column<long>(type: "INTEGER", nullable: false),
                    DataStatusDtTm = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DataStatusPrsnlId = table.Column<long>(type: "INTEGER", nullable: true),
                    Definition = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Display = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    DisplayKey = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    EndEffectiveDtTm = table.Column<DateTime>(type: "timestamp", nullable: false),
                    InactiveDtTm = table.Column<DateTime>(type: "timestamp", nullable: true),
                    InstId = table.Column<long>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeValue", x => x.CodeValueId);
                });

            migrationBuilder.CreateTable(
                name: "CodeValueSet",
                columns: table => new
                {
                    CodeSet = table.Column<long>(type: "INTEGER", nullable: false),
                    ActiveInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    AddAccessInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    AliasDupInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    CacheInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    MeaningDupInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    ChangeAccessInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    CodeSetHits = table.Column<int>(type: "INTEGER", nullable: true),
                    CodeValueCnt = table.Column<int>(type: "INTEGER", nullable: false),
                    Contributor = table.Column<string>(type: "TEXT", nullable: true),
                    Definition = table.Column<string>(type: "TEXT", nullable: true),
                    DefinitionDupInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    DelAccessInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Display = table.Column<string>(type: "TEXT", nullable: false),
                    DisplayDupInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    DisplayKey = table.Column<string>(type: "TEXT", nullable: true),
                    DisplayKeyDupInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    DomainCodeSet = table.Column<int>(type: "INTEGER", nullable: false),
                    DomainQualifierInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    ExtensionInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    InqAccessInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    InstId = table.Column<long>(type: "INTEGER", nullable: false),
                    OwnerModule = table.Column<string>(type: "TEXT", nullable: true),
                    TableName = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeValueSet", x => x.CodeSet);
                });

            migrationBuilder.CreateTable(
                name: "OrderCatalogSynonym",
                columns: table => new
                {
                    SynonymId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ActiveInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    ActiveStatusCd = table.Column<long>(type: "INTEGER", nullable: false),
                    ActiveStatusDtTm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ActiveStatusPrsnlId = table.Column<long>(type: "INTEGER", nullable: true),
                    ActivitySubtypeCd = table.Column<long>(type: "INTEGER", nullable: true),
                    ActivityTypeCd = table.Column<long>(type: "INTEGER", nullable: true),
                    AuthorizationReviewFlag = table.Column<short>(type: "INTEGER", nullable: false),
                    AutoprogSynInd = table.Column<bool>(type: "INTEGER", nullable: true),
                    CatalogCd = table.Column<long>(type: "INTEGER", nullable: false),
                    CatalogTypeCd = table.Column<long>(type: "INTEGER", nullable: false),
                    Cki = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    ConcentrationStrength = table.Column<decimal>(type: "TEXT", nullable: true),
                    ConcentrationStrengthUnitCd = table.Column<long>(type: "INTEGER", nullable: true),
                    ConcentrationVolume = table.Column<decimal>(type: "TEXT", nullable: true),
                    ConcentrationVolumeUnitCd = table.Column<long>(type: "INTEGER", nullable: true),
                    ConceptCki = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    CsIndexCd = table.Column<long>(type: "INTEGER", nullable: true),
                    DcpClinCatCd = table.Column<long>(type: "INTEGER", nullable: false),
                    DisplayAdditivesFirstInd = table.Column<bool>(type: "INTEGER", nullable: true),
                    FilteredOdInd = table.Column<bool>(type: "INTEGER", nullable: true),
                    HealthPlanView = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    HideFlag = table.Column<short>(type: "INTEGER", nullable: false),
                    HighAlertInd = table.Column<bool>(type: "INTEGER", nullable: true),
                    HighAlertLongTextId = table.Column<long>(type: "INTEGER", nullable: true),
                    HighAlertRequiredNtfyInd = table.Column<bool>(type: "INTEGER", nullable: true),
                    IgnoreHideConvertInd = table.Column<bool>(type: "INTEGER", nullable: true),
                    IngredientRateConversionInd = table.Column<bool>(type: "INTEGER", nullable: true),
                    InstId = table.Column<long>(type: "INTEGER", nullable: true),
                    IntermittentInd = table.Column<bool>(type: "INTEGER", nullable: true),
                    ItemId = table.Column<long>(type: "INTEGER", nullable: true),
                    LastAdminDispBasisFlag = table.Column<short>(type: "INTEGER", nullable: true),
                    LockTargetDoseInd = table.Column<bool>(type: "INTEGER", nullable: true),
                    MaxDoseCalcBsaValue = table.Column<decimal>(type: "TEXT", nullable: true),
                    MaxFinalDose = table.Column<decimal>(type: "TEXT", nullable: true),
                    MaxFinalDoseUnitCd = table.Column<long>(type: "INTEGER", nullable: true),
                    MedIntervalWarnFlag = table.Column<short>(type: "INTEGER", nullable: false),
                    Mnemonic = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    MnemonicKeyCap = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    MnemonicKeyCapANls = table.Column<string>(type: "TEXT", maxLength: 400, nullable: false),
                    MnemonicKeyCapNls = table.Column<string>(type: "TEXT", maxLength: 405, nullable: false),
                    MnemonicTypeCd = table.Column<long>(type: "INTEGER", nullable: false),
                    MultipleOrdSentInd = table.Column<bool>(type: "INTEGER", nullable: true),
                    OeFormatId = table.Column<long>(type: "INTEGER", nullable: false),
                    OrderableTypeFlag = table.Column<short>(type: "INTEGER", nullable: false),
                    OrderSentenceId = table.Column<long>(type: "INTEGER", nullable: true),
                    PreferredDoseFlag = table.Column<short>(type: "INTEGER", nullable: true),
                    RefTextMask = table.Column<int>(type: "INTEGER", nullable: true),
                    RoundingRuleCd = table.Column<long>(type: "INTEGER", nullable: true),
                    RxMask = table.Column<int>(type: "INTEGER", nullable: true),
                    VirtualView = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    WitnessFlag = table.Column<short>(type: "INTEGER", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderCatalogSynonym", x => x.SynonymId);
                });

            migrationBuilder.CreateTable(
                name: "OrderTask",
                columns: table => new
                {
                    ReferenceTaskId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TaskDescription = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    TaskDescriptionKey = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    TaskTypeCd = table.Column<long>(type: "INTEGER", nullable: false),
                    TaskActivityCd = table.Column<long>(type: "INTEGER", nullable: false),
                    ActiveInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    AllPositionChartInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    AppObjectName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    CaptureBillInfoInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    SystemUseTaskFlag = table.Column<short>(type: "INTEGER", nullable: true),
                    ChartNotDoneInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    DcpFormRefId = table.Column<long>(type: "INTEGER", nullable: true),
                    EventCd = table.Column<long>(type: "INTEGER", nullable: true),
                    GracePeriodMins = table.Column<int>(type: "INTEGER", nullable: false),
                    IgnoreFreqInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    InstId = table.Column<long>(type: "INTEGER", nullable: true),
                    OverdueMins = table.Column<int>(type: "INTEGER", nullable: false),
                    ProcessLocationCd = table.Column<long>(type: "INTEGER", nullable: true),
                    QuickChartDoneInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    RescheduleTime = table.Column<int>(type: "INTEGER", nullable: false),
                    RetainTime = table.Column<int>(type: "INTEGER", nullable: false),
                    RetainUnits = table.Column<int>(type: "INTEGER", nullable: false),
                    TxnIdText = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTask", x => x.ReferenceTaskId);
                });

            migrationBuilder.CreateTable(
                name: "TaskActivity",
                columns: table => new
                {
                    TaskId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ActiveInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    ActiveStatusCd = table.Column<long>(type: "INTEGER", nullable: false),
                    ActiveStatusDtTm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ActiveStatusPrsnlId = table.Column<long>(type: "INTEGER", nullable: true),
                    BroadcastMessageUuid = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    CallerContactTxt = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    CallerName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    CaresetId = table.Column<long>(type: "INTEGER", nullable: true),
                    CatalogCd = table.Column<long>(type: "INTEGER", nullable: true),
                    CatalogTypeCd = table.Column<long>(type: "INTEGER", nullable: false),
                    ChartedByAgentCd = table.Column<long>(type: "INTEGER", nullable: true),
                    ChartedByAgentIdentifier = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    ChartingContextReference = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Comments = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    ConfidentialInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    ContainerId = table.Column<long>(type: "INTEGER", nullable: true),
                    ContinuousInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    ContributorSystemCd = table.Column<long>(type: "INTEGER", nullable: true),
                    ConversationId = table.Column<long>(type: "INTEGER", nullable: true),
                    DeliveryInd = table.Column<bool>(type: "INTEGER", nullable: true),
                    EmailMessageIdent = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    EncounterId = table.Column<long>(type: "INTEGER", nullable: false),
                    EventCd = table.Column<long>(type: "INTEGER", nullable: true),
                    EventClassCd = table.Column<long>(type: "INTEGER", nullable: true),
                    EventId = table.Column<long>(type: "INTEGER", nullable: false),
                    ExternalReferenceNumber = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    FormatCd = table.Column<long>(type: "INTEGER", nullable: true),
                    IbRxReqPersonDemogId = table.Column<long>(type: "INTEGER", nullable: true),
                    InstId = table.Column<long>(type: "INTEGER", nullable: true),
                    IvInd = table.Column<bool>(type: "INTEGER", nullable: true),
                    LinkedOrderInd = table.Column<bool>(type: "INTEGER", nullable: true),
                    LocationCd = table.Column<long>(type: "INTEGER", nullable: true),
                    LocRoomCd = table.Column<long>(type: "INTEGER", nullable: true),
                    LocBedCd = table.Column<long>(type: "INTEGER", nullable: true),
                    MedOrderTypeCd = table.Column<long>(type: "INTEGER", nullable: true),
                    MessageText = table.Column<string>(type: "TEXT", maxLength: 32000, nullable: true),
                    MsgSenderEmailInfoId = table.Column<long>(type: "INTEGER", nullable: true),
                    MsgSenderId = table.Column<long>(type: "INTEGER", nullable: true),
                    MsgSenderPersonId = table.Column<long>(type: "INTEGER", nullable: true),
                    MsgSenderPrsnlGroupId = table.Column<long>(type: "INTEGER", nullable: true),
                    MsgSubject = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    MsgSubjectCd = table.Column<long>(type: "INTEGER", nullable: true),
                    MsgTextId = table.Column<long>(type: "INTEGER", nullable: true),
                    OrderId = table.Column<long>(type: "INTEGER", nullable: false),
                    OrigPoolTaskId = table.Column<long>(type: "INTEGER", nullable: true),
                    PerformedPrsnlId = table.Column<long>(type: "INTEGER", nullable: true),
                    PersonId = table.Column<long>(type: "INTEGER", nullable: false),
                    PftQueueItemWfHistId = table.Column<long>(type: "INTEGER", nullable: true),
                    PhysicianOrderInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    ReadInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    ReferenceTaskId = table.Column<long>(type: "INTEGER", nullable: false),
                    RemindDtTm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    RescheduleInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    RescheduleReasonCd = table.Column<long>(type: "INTEGER", nullable: true),
                    ResponsiblePrsnlId = table.Column<long>(type: "INTEGER", nullable: true),
                    ResultSetId = table.Column<long>(type: "INTEGER", nullable: true),
                    RoutineInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    ScheduledDtTm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    SendEventValidFromDtTm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    SourceTag = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    StatInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    SuggestedEntityId = table.Column<long>(type: "INTEGER", nullable: true),
                    SuggestedEntityName = table.Column<string>(type: "TEXT", maxLength: 32, nullable: true),
                    TaskActivityCd = table.Column<long>(type: "INTEGER", nullable: false),
                    TaskActivityClassCd = table.Column<long>(type: "INTEGER", nullable: true),
                    TaskClassCd = table.Column<long>(type: "INTEGER", nullable: false),
                    TaskCreatedDtTm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    TaskDtTm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    TaskPriorityCd = table.Column<long>(type: "INTEGER", nullable: false),
                    TaskRoutingId = table.Column<long>(type: "INTEGER", nullable: true),
                    TaskStatusCd = table.Column<long>(type: "INTEGER", nullable: false),
                    TaskStatusReasonCd = table.Column<long>(type: "INTEGER", nullable: true),
                    TaskSubtypeCd = table.Column<long>(type: "INTEGER", nullable: true),
                    TaskTypeCd = table.Column<long>(type: "INTEGER", nullable: false),
                    TaskTz = table.Column<int>(type: "INTEGER", nullable: true),
                    TemplateTaskFlag = table.Column<short>(type: "INTEGER", nullable: true),
                    TpnInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskActivity", x => x.TaskId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CodeValueSet_CodeSet",
                table: "CodeValueSet",
                column: "CodeSet",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderCatalogSynonym_ActivityTypeCd_MnemonicKeyCap",
                table: "OrderCatalogSynonym",
                columns: new[] { "ActivityTypeCd", "MnemonicKeyCap" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderCatalogSynonym_CatalogCd_MnemonicKeyCap_ItemId",
                table: "OrderCatalogSynonym",
                columns: new[] { "CatalogCd", "MnemonicKeyCap", "ItemId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderCatalogSynonym_CatalogTypeCd_MnemonicKeyCap",
                table: "OrderCatalogSynonym",
                columns: new[] { "CatalogTypeCd", "MnemonicKeyCap" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderCatalogSynonym_MnemonicKeyCap_MnemonicTypeCd_CatalogTypeCd_OrderableTypeFlag",
                table: "OrderCatalogSynonym",
                columns: new[] { "MnemonicKeyCap", "MnemonicTypeCd", "CatalogTypeCd", "OrderableTypeFlag" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderCatalogSynonym_MnemonicKeyCap_SynonymId",
                table: "OrderCatalogSynonym",
                columns: new[] { "MnemonicKeyCap", "SynonymId" });

            migrationBuilder.CreateIndex(
                name: "ix_dcp_form_ref_id",
                table: "OrderTask",
                column: "DcpFormRefId");

            migrationBuilder.CreateIndex(
                name: "ix_task_type_cd",
                table: "OrderTask",
                column: "TaskTypeCd");

            migrationBuilder.CreateIndex(
                name: "IX_TaskActivity_EncounterId_TaskTypeCd_TaskStatusCd",
                table: "TaskActivity",
                columns: new[] { "EncounterId", "TaskTypeCd", "TaskStatusCd" });

            migrationBuilder.CreateIndex(
                name: "IX_TaskActivity_LocationCd_TaskStatusCd_TaskTypeCd_TaskDtTm",
                table: "TaskActivity",
                columns: new[] { "LocationCd", "TaskStatusCd", "TaskTypeCd", "TaskDtTm" });

            migrationBuilder.CreateIndex(
                name: "IX_TaskActivity_PersonId_TaskTypeCd_TaskStatusCd_TaskDtTm_TaskClassCd_OrderId",
                table: "TaskActivity",
                columns: new[] { "PersonId", "TaskTypeCd", "TaskStatusCd", "TaskDtTm", "TaskClassCd", "OrderId" });

            migrationBuilder.CreateIndex(
                name: "IX_TaskActivity_TaskClassCd_TaskStatusCd",
                table: "TaskActivity",
                columns: new[] { "TaskClassCd", "TaskStatusCd" });

            migrationBuilder.CreateIndex(
                name: "IX_TaskActivity_TaskStatusCd_TaskTypeCd_TaskClassCd",
                table: "TaskActivity",
                columns: new[] { "TaskStatusCd", "TaskTypeCd", "TaskClassCd" });

            migrationBuilder.CreateIndex(
                name: "IX_TaskActivity_TaskTypeCd_TaskStatusCd",
                table: "TaskActivity",
                columns: new[] { "TaskTypeCd", "TaskStatusCd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodeValue");

            migrationBuilder.DropTable(
                name: "CodeValueSet");

            migrationBuilder.DropTable(
                name: "OrderCatalogSynonym");

            migrationBuilder.DropTable(
                name: "OrderTask");

            migrationBuilder.DropTable(
                name: "TaskActivity");
        }
    }
}
