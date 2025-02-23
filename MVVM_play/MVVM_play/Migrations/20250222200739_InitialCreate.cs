using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MVVM_play.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClinicalEvent",
                columns: table => new
                {
                    ClinicalEventId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccessionNbr = table.Column<string>(type: "text", nullable: true),
                    AuthenticFlag = table.Column<short>(type: "smallint", nullable: false),
                    CatalogCd = table.Column<long>(type: "bigint", nullable: false),
                    CeDynamicLabelId = table.Column<long>(type: "bigint", nullable: false),
                    ClinicalSeq = table.Column<string>(type: "text", nullable: true),
                    ClinsigUpdtDtTm = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CluSubkey1Flag = table.Column<short>(type: "smallint", nullable: true),
                    CollatingSeq = table.Column<string>(type: "text", nullable: true),
                    ContributorSystemCd = table.Column<short>(type: "smallint", nullable: false),
                    CriticalHigh = table.Column<string>(type: "text", nullable: true),
                    CriticalLow = table.Column<string>(type: "text", nullable: true),
                    DeviceFreeTxt = table.Column<string>(type: "text", nullable: true),
                    EncntrFinancialId = table.Column<long>(type: "bigint", nullable: false),
                    EncntrId = table.Column<long>(type: "bigint", nullable: false),
                    EntryModeCd = table.Column<long>(type: "bigint", nullable: false),
                    EventCd = table.Column<long>(type: "bigint", nullable: false),
                    EventClassCd = table.Column<long>(type: "bigint", nullable: false),
                    EventEndDtTm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EventEndDtTmOs = table.Column<decimal>(type: "numeric", nullable: true),
                    EventEndTz = table.Column<int>(type: "integer", nullable: true),
                    EventId = table.Column<long>(type: "bigint", nullable: false),
                    EventReltnCd = table.Column<long>(type: "bigint", nullable: false),
                    EventStartDtTm = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EventStartTz = table.Column<int>(type: "integer", nullable: true),
                    EventTag = table.Column<string>(type: "text", nullable: false),
                    EventTagSetFlag = table.Column<short>(type: "smallint", nullable: true),
                    EventTitleText = table.Column<string>(type: "text", nullable: true),
                    ExpirationDtTm = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    InquireSecurityCd = table.Column<long>(type: "bigint", nullable: false),
                    InstId = table.Column<long>(type: "bigint", nullable: true),
                    ModifierLongTextId = table.Column<long>(type: "bigint", nullable: false),
                    NomenStringFlag = table.Column<short>(type: "smallint", nullable: true),
                    NormalcyCd = table.Column<long>(type: "bigint", nullable: false),
                    NormalcyMethodCd = table.Column<long>(type: "bigint", nullable: false),
                    NormalHigh = table.Column<string>(type: "text", nullable: true),
                    NormalLow = table.Column<string>(type: "text", nullable: true),
                    NormalRefRangeTxt = table.Column<string>(type: "text", nullable: true),
                    NoteImportanceBitMap = table.Column<long>(type: "bigint", nullable: true),
                    OrderActionSequence = table.Column<long>(type: "bigint", nullable: false),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    ParentEventId = table.Column<long>(type: "bigint", nullable: false),
                    PerformedDtTm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PerformedTz = table.Column<int>(type: "integer", nullable: true),
                    PerformedPrsnlId = table.Column<long>(type: "bigint", nullable: false),
                    PersonId = table.Column<long>(type: "bigint", nullable: false),
                    PublishFlag = table.Column<short>(type: "smallint", nullable: false),
                    QcReviewCd = table.Column<long>(type: "bigint", nullable: false),
                    RecordStatusCd = table.Column<long>(type: "bigint", nullable: false),
                    ReferenceNbr = table.Column<string>(type: "text", nullable: true),
                    ResourceCd = table.Column<long>(type: "bigint", nullable: true),
                    ResourceGroupCd = table.Column<long>(type: "bigint", nullable: true),
                    ResultStatusCd = table.Column<long>(type: "bigint", nullable: false),
                    ResultTimeUnitsCd = table.Column<long>(type: "bigint", nullable: true),
                    ResultUnitsCd = table.Column<long>(type: "bigint", nullable: true),
                    ResultVal = table.Column<string>(type: "text", nullable: true),
                    SeriesRefNbr = table.Column<string>(type: "text", nullable: true),
                    SourceCd = table.Column<long>(type: "bigint", nullable: true),
                    SrcEventId = table.Column<long>(type: "bigint", nullable: false),
                    SrcClinsigUpdtDtTm = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SubtableBitMap = table.Column<int>(type: "integer", nullable: true),
                    TaskAssayCd = table.Column<long>(type: "bigint", nullable: true),
                    TaskAssayVersionNbr = table.Column<long>(type: "bigint", nullable: true),
                    ValidFromDtTm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ValidUntilDtTm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VerifiedDtTm = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    VerifiedPrsnlId = table.Column<long>(type: "bigint", nullable: false),
                    ViewLevel = table.Column<int>(type: "integer", nullable: true),
                    CreatedBy = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicalEvent", x => x.ClinicalEventId);
                });

            migrationBuilder.CreateTable(
                name: "CodeValue",
                columns: table => new
                {
                    CodeValueId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ActiveInd = table.Column<bool>(type: "boolean", nullable: false),
                    ActiveTypeCd = table.Column<long>(type: "bigint", nullable: true),
                    ActiveStatusPrsnlId = table.Column<long>(type: "bigint", nullable: true),
                    BeginEffectiveDtTm = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Meaning = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    Cki = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CodeSet = table.Column<int>(type: "integer", nullable: false),
                    CollationSeq = table.Column<int>(type: "integer", nullable: false),
                    ConceptCki = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    DataStatusCd = table.Column<long>(type: "bigint", nullable: false),
                    DataStatusDtTm = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DataStatusPrsnlId = table.Column<long>(type: "bigint", nullable: true),
                    Definition = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    Display = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    DisplayKey = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    EndEffectiveDtTm = table.Column<DateTime>(type: "timestamp", nullable: false),
                    InactiveDtTm = table.Column<DateTime>(type: "timestamp", nullable: true),
                    InstId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
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
                    CodeSet = table.Column<long>(type: "bigint", nullable: false),
                    ActiveInd = table.Column<bool>(type: "boolean", nullable: false),
                    AddAccessInd = table.Column<bool>(type: "boolean", nullable: false),
                    AliasDupInd = table.Column<bool>(type: "boolean", nullable: false),
                    CacheInd = table.Column<bool>(type: "boolean", nullable: false),
                    MeaningDupInd = table.Column<bool>(type: "boolean", nullable: false),
                    ChangeAccessInd = table.Column<bool>(type: "boolean", nullable: false),
                    CodeSetHits = table.Column<int>(type: "integer", nullable: true),
                    CodeValueCnt = table.Column<int>(type: "integer", nullable: false),
                    Contributor = table.Column<string>(type: "text", nullable: true),
                    Definition = table.Column<string>(type: "text", nullable: true),
                    DefinitionDupInd = table.Column<bool>(type: "boolean", nullable: false),
                    DelAccessInd = table.Column<bool>(type: "boolean", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Display = table.Column<string>(type: "text", nullable: false),
                    DisplayDupInd = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayKey = table.Column<string>(type: "text", nullable: true),
                    DisplayKeyDupInd = table.Column<bool>(type: "boolean", nullable: false),
                    DomainCodeSet = table.Column<int>(type: "integer", nullable: false),
                    DomainQualifierInd = table.Column<bool>(type: "boolean", nullable: false),
                    ExtensionInd = table.Column<bool>(type: "boolean", nullable: false),
                    InqAccessInd = table.Column<bool>(type: "boolean", nullable: false),
                    InstId = table.Column<long>(type: "bigint", nullable: false),
                    OwnerModule = table.Column<string>(type: "text", nullable: true),
                    TableName = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeValueSet", x => x.CodeSet);
                });

            migrationBuilder.CreateTable(
                name: "OrderAction",
                columns: table => new
                {
                    OrderActionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ActionDtTm = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ActionTz = table.Column<int>(type: "integer", nullable: true),
                    ActionInitiatedDtTm = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ActionPersonnelId = table.Column<long>(type: "bigint", nullable: false),
                    ActionQualifierCd = table.Column<long>(type: "bigint", nullable: true),
                    ActionRejectedInd = table.Column<bool>(type: "boolean", nullable: true),
                    ActionSequence = table.Column<int>(type: "integer", nullable: false),
                    ActionTypeCd = table.Column<long>(type: "bigint", nullable: false),
                    BillingProviderFlag = table.Column<short>(type: "smallint", nullable: true),
                    ClinicalDisplayLine = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CommunicationTypeCd = table.Column<long>(type: "bigint", nullable: true),
                    ConstantInd = table.Column<bool>(type: "boolean", nullable: true),
                    ContributorSystemCd = table.Column<long>(type: "bigint", nullable: true),
                    CoreInd = table.Column<bool>(type: "boolean", nullable: true),
                    CurrentStartDtTm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CurrentStartTz = table.Column<int>(type: "integer", nullable: true),
                    DeptStatusCd = table.Column<long>(type: "bigint", nullable: true),
                    DigitalSignatureIdent = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    EffectiveDtTm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EffectiveTz = table.Column<int>(type: "integer", nullable: true),
                    EsoActionCd = table.Column<long>(type: "bigint", nullable: true),
                    FormularyStatusCd = table.Column<long>(type: "bigint", nullable: true),
                    FrequencyId = table.Column<long>(type: "bigint", nullable: false),
                    IncompleteOrderInd = table.Column<bool>(type: "boolean", nullable: true),
                    MedstudentActionInd = table.Column<bool>(type: "boolean", nullable: true),
                    NeedsVerifyInd = table.Column<bool>(type: "boolean", nullable: false),
                    NeedClinReviewFlag = table.Column<bool>(type: "boolean", nullable: false),
                    NextDoseDtTm = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    OrderAppNbr = table.Column<int>(type: "integer", nullable: true),
                    OrderConversationId = table.Column<long>(type: "bigint", nullable: true),
                    OrderConvsSeq = table.Column<int>(type: "integer", nullable: true),
                    OrderDetailDisplayLine = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    OrderDtTm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OrderTz = table.Column<int>(type: "integer", nullable: true),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    OrderLocnCd = table.Column<long>(type: "bigint", nullable: true),
                    OrderProviderId = table.Column<long>(type: "bigint", nullable: true),
                    OrderReviewStatusReasonBit = table.Column<int>(type: "integer", nullable: true),
                    OrderSchedulePrecisionBit = table.Column<int>(type: "integer", nullable: true),
                    OrderStatusCd = table.Column<long>(type: "bigint", nullable: false),
                    OrderStatusReasonBit = table.Column<int>(type: "integer", nullable: true),
                    PrnInd = table.Column<bool>(type: "boolean", nullable: true),
                    ProjectedStopDtTm = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ProjectedStopTz = table.Column<int>(type: "integer", nullable: true),
                    SchStateCd = table.Column<long>(type: "bigint", nullable: true),
                    SimplifiedDisplayLine = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    SourceDotActionSeq = table.Column<int>(type: "integer", nullable: false),
                    SourceDotOrderId = table.Column<long>(type: "bigint", nullable: true),
                    SourceProtocolActionSeq = table.Column<int>(type: "integer", nullable: true),
                    StartRangeNbr = table.Column<int>(type: "integer", nullable: true),
                    StartRangeUnitFlag = table.Column<short>(type: "smallint", nullable: true),
                    StopTypeCd = table.Column<long>(type: "bigint", nullable: true),
                    SupervisingProviderId = table.Column<long>(type: "bigint", nullable: true),
                    SynonymId = table.Column<long>(type: "bigint", nullable: true),
                    TemplateOrderFlag = table.Column<short>(type: "smallint", nullable: false),
                    UndoActionTypeCd = table.Column<long>(type: "bigint", nullable: true),
                    ValidDoseDtTm = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderAction", x => x.OrderActionId);
                });

            migrationBuilder.CreateTable(
                name: "OrderCatalog",
                columns: table => new
                {
                    CatalogCd = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PrimaryMnemonic = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    AbnReviewInd = table.Column<bool>(type: "boolean", nullable: true),
                    ActiveInd = table.Column<bool>(type: "boolean", nullable: false),
                    ActivityTypeCd = table.Column<long>(type: "bigint", nullable: false),
                    ActivitySubtypeCd = table.Column<long>(type: "bigint", nullable: false),
                    AutoCancelInd = table.Column<bool>(type: "boolean", nullable: false),
                    BillOnlyInd = table.Column<bool>(type: "boolean", nullable: false),
                    CatalogTypeCd = table.Column<long>(type: "bigint", nullable: false),
                    Cki = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CommentTemplateFlag = table.Column<short>(type: "smallint", nullable: true),
                    CompleteUponOrderInd = table.Column<bool>(type: "boolean", nullable: false),
                    ConceptCki = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    ConsentFormFormatCd = table.Column<long>(type: "bigint", nullable: true),
                    ConsentFormInd = table.Column<bool>(type: "boolean", nullable: false),
                    ConsentFormRoutingCd = table.Column<long>(type: "bigint", nullable: true),
                    ContOrderMethodFlag = table.Column<short>(type: "smallint", nullable: false),
                    DcpClinCatCd = table.Column<long>(type: "bigint", nullable: false),
                    DcDisplayDays = table.Column<int>(type: "integer", nullable: false),
                    DcInteractionDays = table.Column<int>(type: "integer", nullable: false),
                    DeptDisplayName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeptDupCheckInd = table.Column<bool>(type: "boolean", nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DisableOrderCommentInd = table.Column<bool>(type: "boolean", nullable: false),
                    DiscernAutoVerifyFlag = table.Column<bool>(type: "boolean", nullable: false),
                    DosingActIngredCode = table.Column<int>(type: "integer", nullable: true),
                    DosingAllIngredInd = table.Column<bool>(type: "boolean", nullable: true),
                    DupCheckInd = table.Column<bool>(type: "boolean", nullable: false),
                    EventCd = table.Column<long>(type: "bigint", nullable: false),
                    FormId = table.Column<long>(type: "bigint", nullable: false),
                    FormLevel = table.Column<short>(type: "smallint", nullable: true),
                    InstId = table.Column<long>(type: "bigint", nullable: true),
                    InstRestrictionInd = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiableFlag = table.Column<int>(type: "integer", nullable: false),
                    OeFormatId = table.Column<long>(type: "bigint", nullable: false),
                    OpDcDisplayDays = table.Column<int>(type: "integer", nullable: false),
                    OpDcInteractionDays = table.Column<int>(type: "integer", nullable: false),
                    OrderableTypeFlag = table.Column<int>(type: "integer", nullable: false),
                    OrderReviewInd = table.Column<bool>(type: "boolean", nullable: false),
                    OrdComTemplateLongTextId = table.Column<long>(type: "bigint", nullable: false),
                    PrepInfoFlag = table.Column<int>(type: "integer", nullable: true),
                    PrintReqInd = table.Column<bool>(type: "boolean", nullable: false),
                    PromptInd = table.Column<bool>(type: "boolean", nullable: false),
                    QuickChartInd = table.Column<bool>(type: "boolean", nullable: false),
                    RefTextMask = table.Column<int>(type: "integer", nullable: true),
                    RequisitionFormatCd = table.Column<long>(type: "bigint", nullable: false),
                    RequisitionRoutingCd = table.Column<long>(type: "bigint", nullable: false),
                    ResourceRouteCd = table.Column<long>(type: "bigint", nullable: false),
                    ResourceRouteLvl = table.Column<int>(type: "integer", nullable: true),
                    ReviewHierarchyId = table.Column<long>(type: "bigint", nullable: false),
                    ScheduleInd = table.Column<bool>(type: "boolean", nullable: false),
                    SourceVocabIdent = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    SourceVocabMean = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    StopDuration = table.Column<int>(type: "integer", nullable: false),
                    StopDurationUnitCd = table.Column<long>(type: "bigint", nullable: false),
                    StopTypeCd = table.Column<long>(type: "bigint", nullable: false),
                    TxnIdText = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    VettingApprovalFlag = table.Column<bool>(type: "boolean", nullable: false),
                    UpdtApplctx = table.Column<long>(type: "bigint", nullable: false),
                    UpdtCnt = table.Column<int>(type: "integer", nullable: false),
                    UpdtDtTm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdtId = table.Column<long>(type: "bigint", nullable: false),
                    UpdtTask = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderCatalog", x => x.CatalogCd);
                });

            migrationBuilder.CreateTable(
                name: "OrderCatalogSynonym",
                columns: table => new
                {
                    SynonymId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ActiveInd = table.Column<bool>(type: "boolean", nullable: false),
                    ActiveStatusCd = table.Column<long>(type: "bigint", nullable: false),
                    ActiveStatusDtTm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ActiveStatusPrsnlId = table.Column<long>(type: "bigint", nullable: true),
                    ActivitySubtypeCd = table.Column<long>(type: "bigint", nullable: true),
                    ActivityTypeCd = table.Column<long>(type: "bigint", nullable: true),
                    AuthorizationReviewFlag = table.Column<short>(type: "smallint", nullable: false),
                    AutoprogSynInd = table.Column<bool>(type: "boolean", nullable: true),
                    CatalogCd = table.Column<long>(type: "bigint", nullable: false),
                    CatalogTypeCd = table.Column<long>(type: "bigint", nullable: false),
                    Cki = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    ConcentrationStrength = table.Column<decimal>(type: "numeric", nullable: true),
                    ConcentrationStrengthUnitCd = table.Column<long>(type: "bigint", nullable: true),
                    ConcentrationVolume = table.Column<decimal>(type: "numeric", nullable: true),
                    ConcentrationVolumeUnitCd = table.Column<long>(type: "bigint", nullable: true),
                    ConceptCki = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CsIndexCd = table.Column<long>(type: "bigint", nullable: true),
                    DcpClinCatCd = table.Column<long>(type: "bigint", nullable: false),
                    DisplayAdditivesFirstInd = table.Column<bool>(type: "boolean", nullable: true),
                    FilteredOdInd = table.Column<bool>(type: "boolean", nullable: true),
                    HealthPlanView = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    HideFlag = table.Column<short>(type: "smallint", nullable: false),
                    HighAlertInd = table.Column<bool>(type: "boolean", nullable: true),
                    HighAlertLongTextId = table.Column<long>(type: "bigint", nullable: true),
                    HighAlertRequiredNtfyInd = table.Column<bool>(type: "boolean", nullable: true),
                    IgnoreHideConvertInd = table.Column<bool>(type: "boolean", nullable: true),
                    IngredientRateConversionInd = table.Column<bool>(type: "boolean", nullable: true),
                    InstId = table.Column<long>(type: "bigint", nullable: true),
                    IntermittentInd = table.Column<bool>(type: "boolean", nullable: true),
                    ItemId = table.Column<long>(type: "bigint", nullable: true),
                    LastAdminDispBasisFlag = table.Column<short>(type: "smallint", nullable: true),
                    LockTargetDoseInd = table.Column<bool>(type: "boolean", nullable: true),
                    MaxDoseCalcBsaValue = table.Column<decimal>(type: "numeric", nullable: true),
                    MaxFinalDose = table.Column<decimal>(type: "numeric", nullable: true),
                    MaxFinalDoseUnitCd = table.Column<long>(type: "bigint", nullable: true),
                    MedIntervalWarnFlag = table.Column<short>(type: "smallint", nullable: false),
                    Mnemonic = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    MnemonicKeyCap = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    MnemonicKeyCapANls = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: false),
                    MnemonicKeyCapNls = table.Column<string>(type: "character varying(405)", maxLength: 405, nullable: false),
                    MnemonicTypeCd = table.Column<long>(type: "bigint", nullable: false),
                    MultipleOrdSentInd = table.Column<bool>(type: "boolean", nullable: true),
                    OeFormatId = table.Column<long>(type: "bigint", nullable: false),
                    OrderableTypeFlag = table.Column<short>(type: "smallint", nullable: false),
                    OrderSentenceId = table.Column<long>(type: "bigint", nullable: true),
                    PreferredDoseFlag = table.Column<short>(type: "smallint", nullable: true),
                    RefTextMask = table.Column<int>(type: "integer", nullable: true),
                    RoundingRuleCd = table.Column<long>(type: "bigint", nullable: true),
                    RxMask = table.Column<int>(type: "integer", nullable: true),
                    VirtualView = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    WitnessFlag = table.Column<short>(type: "smallint", nullable: true),
                    CreatedBy = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderCatalogSynonym", x => x.SynonymId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ActiveInd = table.Column<bool>(type: "boolean", nullable: false),
                    ActiveStatusCd = table.Column<long>(type: "bigint", nullable: false),
                    ActiveStatusDtTm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ActiveStatusPrsnlId = table.Column<long>(type: "bigint", nullable: false),
                    ActivityTypeCd = table.Column<long>(type: "bigint", nullable: false),
                    AdHocOrderFlag = table.Column<short>(type: "smallint", nullable: false),
                    CatalogCd = table.Column<long>(type: "bigint", nullable: false),
                    CatalogTypeCd = table.Column<long>(type: "bigint", nullable: false),
                    Cki = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    ClinicalDisplayLine = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    ClinRelevantUpdtDtTm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ClinRelevantUpdtTz = table.Column<int>(type: "integer", nullable: false),
                    CluSubkeyFlag = table.Column<short>(type: "smallint", nullable: false),
                    CommentTypeMask = table.Column<int>(type: "integer", nullable: false),
                    ConstantInd = table.Column<bool>(type: "boolean", nullable: false),
                    ContributorSystemCd = table.Column<long>(type: "bigint", nullable: false),
                    CsFlag = table.Column<short>(type: "smallint", nullable: true),
                    CsOrderId = table.Column<long>(type: "bigint", nullable: false),
                    CurrentStartDtTm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CurrentStartTz = table.Column<int>(type: "integer", nullable: false),
                    DayOfTreatmentSequence = table.Column<int>(type: "integer", nullable: false),
                    DcpClinCatCd = table.Column<long>(type: "bigint", nullable: false),
                    DeptMiscLine = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    DeptStatusCd = table.Column<long>(type: "bigint", nullable: true),
                    DiscontinueEffectiveDtTm = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DiscontinueEffectiveTz = table.Column<int>(type: "integer", nullable: true),
                    DiscontinueInd = table.Column<bool>(type: "boolean", nullable: false),
                    DiscontinueTypeCd = table.Column<long>(type: "bigint", nullable: true),
                    DosingMethodFlag = table.Column<short>(type: "smallint", nullable: true),
                    EncounterFinancialId = table.Column<long>(type: "bigint", nullable: true),
                    EncntrId = table.Column<long>(type: "bigint", nullable: false),
                    EsoNewOrderInd = table.Column<bool>(type: "boolean", nullable: false),
                    FormularyStatusCd = table.Column<long>(type: "bigint", nullable: true),
                    FrequencyId = table.Column<long>(type: "bigint", nullable: false),
                    FreqTypeFlag = table.Column<short>(type: "smallint", nullable: false),
                    FutureLocationFacilityCd = table.Column<long>(type: "bigint", nullable: true),
                    FutureLocationNurseUnitCd = table.Column<long>(type: "bigint", nullable: true),
                    GroupOrderFlag = table.Column<short>(type: "smallint", nullable: true),
                    GroupOrderId = table.Column<long>(type: "bigint", nullable: false),
                    HideFlag = table.Column<short>(type: "smallint", nullable: false),
                    HnaOrderMnemonic = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    IncompleteOrderInd = table.Column<bool>(type: "boolean", nullable: false),
                    IngredientInd = table.Column<bool>(type: "boolean", nullable: true),
                    InstId = table.Column<long>(type: "bigint", nullable: true),
                    IntervalInd = table.Column<bool>(type: "boolean", nullable: true),
                    IVInd = table.Column<bool>(type: "boolean", nullable: true),
                    IvSetSynonymId = table.Column<long>(type: "bigint", nullable: false),
                    LastActionSequence = table.Column<int>(type: "integer", nullable: false),
                    LastCoreActionSequence = table.Column<int>(type: "integer", nullable: true),
                    LastIngredActionSequence = table.Column<int>(type: "integer", nullable: true),
                    LastUpdateProviderId = table.Column<long>(type: "bigint", nullable: true),
                    LatestCommunicationTypeCd = table.Column<long>(type: "bigint", nullable: true),
                    LinkNbr = table.Column<long>(type: "bigint", nullable: true),
                    LinkOrderFlag = table.Column<short>(type: "smallint", nullable: true),
                    LinkOrderId = table.Column<long>(type: "bigint", nullable: true),
                    LinkTypeFlag = table.Column<short>(type: "smallint", nullable: true),
                    MedOrderTypeCd = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedStartDtTm = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NeedDoctorCosignInd = table.Column<bool>(type: "boolean", nullable: false),
                    NeedNurseReviewInd = table.Column<bool>(type: "boolean", nullable: false),
                    NeedPhysicianValidateInd = table.Column<bool>(type: "boolean", nullable: false),
                    NeedRxClinReviewFlag = table.Column<short>(type: "smallint", nullable: false),
                    NeedRxVerifyFlag = table.Column<short>(type: "smallint", nullable: false),
                    OeFormatId = table.Column<long>(type: "bigint", nullable: false),
                    OrderableTypeFlag = table.Column<short>(type: "smallint", nullable: false),
                    OrderedAsMnemonic = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    OrderCommentInd = table.Column<bool>(type: "boolean", nullable: false),
                    OrderDetailDisplayLine = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    OrderMnemonic = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    OrderStatusCd = table.Column<long>(type: "bigint", nullable: false),
                    StatusDtTm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StatusPrsnlId = table.Column<long>(type: "bigint", nullable: true),
                    OrderStatusReasonBit = table.Column<int>(type: "integer", nullable: true),
                    OriginatingEncntrId = table.Column<long>(type: "bigint", nullable: true),
                    OrigOrderConvsSeq = table.Column<int>(type: "integer", nullable: true),
                    OrigOrderDtTm = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    OrigOrderTz = table.Column<int>(type: "integer", nullable: true),
                    OrigOrderAsFlag = table.Column<short>(type: "smallint", nullable: true),
                    OverrideFlag = table.Column<short>(type: "smallint", nullable: true),
                    PathwayCatalogId = table.Column<long>(type: "bigint", nullable: false),
                    PersonId = table.Column<long>(type: "bigint", nullable: false),
                    PrescriptionGroupValue = table.Column<long>(type: "bigint", nullable: true),
                    PrescriptionOrderId = table.Column<long>(type: "bigint", nullable: true),
                    PrnInd = table.Column<bool>(type: "boolean", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    ProjectedStopDtTm = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ProjectedStopTz = table.Column<int>(type: "integer", nullable: true),
                    ProtocolOrderId = table.Column<long>(type: "bigint", nullable: true),
                    RefTextMask = table.Column<int>(type: "integer", nullable: true),
                    ResumeEffectiveDtTm = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ResumeEffectiveTz = table.Column<int>(type: "integer", nullable: true),
                    ResumeInd = table.Column<bool>(type: "boolean", nullable: true),
                    RxMask = table.Column<int>(type: "integer", nullable: true),
                    SchStateCd = table.Column<long>(type: "bigint", nullable: true),
                    SimplifiedDisplayLine = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    SoftStopDtTm = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SoftStopTz = table.Column<int>(type: "integer", nullable: true),
                    SourceCd = table.Column<long>(type: "bigint", nullable: true),
                    StopTypeCd = table.Column<long>(type: "bigint", nullable: true),
                    SuspendEffectiveDtTm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SuspendEffectiveTz = table.Column<int>(type: "integer", nullable: true),
                    SuspendInd = table.Column<bool>(type: "boolean", nullable: true),
                    SynonymId = table.Column<long>(type: "bigint", nullable: true),
                    TemplateCoreActionSequence = table.Column<int>(type: "integer", nullable: true),
                    TemplateDoseSequence = table.Column<int>(type: "integer", nullable: true),
                    TemplateOrderFlag = table.Column<short>(type: "smallint", nullable: true),
                    TemplateOrderId = table.Column<long>(type: "bigint", nullable: false),
                    VettingApprovalFlag = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "OrderTask",
                columns: table => new
                {
                    ReferenceTaskId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TaskDescription = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TaskDescriptionKey = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TaskTypeCd = table.Column<long>(type: "bigint", nullable: false),
                    TaskActivityCd = table.Column<long>(type: "bigint", nullable: false),
                    ActiveInd = table.Column<bool>(type: "boolean", nullable: false),
                    AllPositionChartInd = table.Column<bool>(type: "boolean", nullable: false),
                    AppObjectName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CaptureBillInfoInd = table.Column<bool>(type: "boolean", nullable: false),
                    SystemUseTaskFlag = table.Column<short>(type: "smallint", nullable: true),
                    ChartNotDoneInd = table.Column<bool>(type: "boolean", nullable: false),
                    DcpFormRefId = table.Column<long>(type: "bigint", nullable: true),
                    EventCd = table.Column<long>(type: "bigint", nullable: true),
                    GracePeriodMins = table.Column<int>(type: "integer", nullable: false),
                    IgnoreFreqInd = table.Column<bool>(type: "boolean", nullable: false),
                    InstId = table.Column<long>(type: "bigint", nullable: true),
                    OverdueMins = table.Column<int>(type: "integer", nullable: false),
                    ProcessLocationCd = table.Column<long>(type: "bigint", nullable: true),
                    QuickChartDoneInd = table.Column<bool>(type: "boolean", nullable: false),
                    RescheduleTime = table.Column<int>(type: "integer", nullable: false),
                    RetainTime = table.Column<int>(type: "integer", nullable: false),
                    RetainUnits = table.Column<int>(type: "integer", nullable: false),
                    TxnIdText = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTask", x => x.ReferenceTaskId);
                });

            migrationBuilder.CreateTable(
                name: "TaskActivity",
                columns: table => new
                {
                    TaskId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ActiveInd = table.Column<bool>(type: "boolean", nullable: false),
                    ActiveStatusCd = table.Column<long>(type: "bigint", nullable: false),
                    ActiveStatusDtTm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ActiveStatusPrsnlId = table.Column<long>(type: "bigint", nullable: true),
                    BroadcastMessageUuid = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CallerContactTxt = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CallerName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CaresetId = table.Column<long>(type: "bigint", nullable: true),
                    CatalogCd = table.Column<long>(type: "bigint", nullable: true),
                    CatalogTypeCd = table.Column<long>(type: "bigint", nullable: false),
                    ChartedByAgentCd = table.Column<long>(type: "bigint", nullable: true),
                    ChartedByAgentIdentifier = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    ChartingContextReference = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Comments = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    ConfidentialInd = table.Column<bool>(type: "boolean", nullable: false),
                    ContainerId = table.Column<long>(type: "bigint", nullable: true),
                    ContinuousInd = table.Column<bool>(type: "boolean", nullable: false),
                    ContributorSystemCd = table.Column<long>(type: "bigint", nullable: true),
                    ConversationId = table.Column<long>(type: "bigint", nullable: true),
                    DeliveryInd = table.Column<bool>(type: "boolean", nullable: true),
                    EmailMessageIdent = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    EncounterId = table.Column<long>(type: "bigint", nullable: false),
                    EventCd = table.Column<long>(type: "bigint", nullable: true),
                    EventClassCd = table.Column<long>(type: "bigint", nullable: true),
                    EventId = table.Column<long>(type: "bigint", nullable: false),
                    ExternalReferenceNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    FormatCd = table.Column<long>(type: "bigint", nullable: true),
                    IbRxReqPersonDemogId = table.Column<long>(type: "bigint", nullable: true),
                    InstId = table.Column<long>(type: "bigint", nullable: true),
                    IvInd = table.Column<bool>(type: "boolean", nullable: true),
                    LinkedOrderInd = table.Column<bool>(type: "boolean", nullable: true),
                    LocationCd = table.Column<long>(type: "bigint", nullable: true),
                    LocRoomCd = table.Column<long>(type: "bigint", nullable: true),
                    LocBedCd = table.Column<long>(type: "bigint", nullable: true),
                    MedOrderTypeCd = table.Column<long>(type: "bigint", nullable: true),
                    MessageText = table.Column<string>(type: "character varying(32000)", maxLength: 32000, nullable: true),
                    MsgSenderEmailInfoId = table.Column<long>(type: "bigint", nullable: true),
                    MsgSenderId = table.Column<long>(type: "bigint", nullable: true),
                    MsgSenderPersonId = table.Column<long>(type: "bigint", nullable: true),
                    MsgSenderPrsnlGroupId = table.Column<long>(type: "bigint", nullable: true),
                    MsgSubject = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    MsgSubjectCd = table.Column<long>(type: "bigint", nullable: true),
                    MsgTextId = table.Column<long>(type: "bigint", nullable: true),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    OrigPoolTaskId = table.Column<long>(type: "bigint", nullable: true),
                    PerformedPrsnlId = table.Column<long>(type: "bigint", nullable: true),
                    PersonId = table.Column<long>(type: "bigint", nullable: false),
                    PftQueueItemWfHistId = table.Column<long>(type: "bigint", nullable: true),
                    PhysicianOrderInd = table.Column<bool>(type: "boolean", nullable: false),
                    ReadInd = table.Column<bool>(type: "boolean", nullable: false),
                    ReferenceTaskId = table.Column<long>(type: "bigint", nullable: false),
                    RemindDtTm = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RescheduleInd = table.Column<bool>(type: "boolean", nullable: false),
                    RescheduleReasonCd = table.Column<long>(type: "bigint", nullable: true),
                    ResponsiblePrsnlId = table.Column<long>(type: "bigint", nullable: true),
                    ResultSetId = table.Column<long>(type: "bigint", nullable: true),
                    RoutineInd = table.Column<bool>(type: "boolean", nullable: false),
                    ScheduledDtTm = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SendEventValidFromDtTm = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SourceTag = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    StatInd = table.Column<bool>(type: "boolean", nullable: false),
                    SuggestedEntityId = table.Column<long>(type: "bigint", nullable: true),
                    SuggestedEntityName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    TaskActivityCd = table.Column<long>(type: "bigint", nullable: false),
                    TaskActivityClassCd = table.Column<long>(type: "bigint", nullable: true),
                    TaskClassCd = table.Column<long>(type: "bigint", nullable: false),
                    TaskCreatedDtTm = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TaskDtTm = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TaskPriorityCd = table.Column<long>(type: "bigint", nullable: false),
                    TaskRoutingId = table.Column<long>(type: "bigint", nullable: true),
                    TaskStatusCd = table.Column<long>(type: "bigint", nullable: false),
                    TaskStatusReasonCd = table.Column<long>(type: "bigint", nullable: true),
                    TaskSubtypeCd = table.Column<long>(type: "bigint", nullable: true),
                    TaskTypeCd = table.Column<long>(type: "bigint", nullable: false),
                    TaskTz = table.Column<int>(type: "integer", nullable: true),
                    TemplateTaskFlag = table.Column<short>(type: "smallint", nullable: true),
                    TpnInd = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskActivity", x => x.TaskId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    City = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    PrimaryAddress = table.Column<string>(type: "text", nullable: true),
                    SecondaryAddress = table.Column<string>(type: "text", nullable: true),
                    AvatarUrl = table.Column<string>(type: "text", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfilesHx",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    PrimaryAddress = table.Column<string>(type: "text", nullable: true),
                    SecondaryAddress = table.Column<string>(type: "text", nullable: true),
                    AvatarUrl = table.Column<string>(type: "text", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfilesHx", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfilesHx_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_ce_dynamic_label_id_valid_until",
                table: "ClinicalEvent",
                columns: new[] { "CeDynamicLabelId", "ValidUntilDtTm" });

            migrationBuilder.CreateIndex(
                name: "ix_encntr_id_clinsig_updt_dttm",
                table: "ClinicalEvent",
                columns: new[] { "EncntrId", "ClinsigUpdtDtTm" });

            migrationBuilder.CreateIndex(
                name: "ix_encntr_id_event_class_cd",
                table: "ClinicalEvent",
                columns: new[] { "EncntrId", "EventClassCd" });

            migrationBuilder.CreateIndex(
                name: "ix_encntr_id_result_status",
                table: "ClinicalEvent",
                columns: new[] { "EncntrId", "ResultStatusCd" });

            migrationBuilder.CreateIndex(
                name: "ix_event_cd_event_end_dt_tm",
                table: "ClinicalEvent",
                columns: new[] { "EventCd", "EventEndDtTm" });

            migrationBuilder.CreateIndex(
                name: "ix_event_id_validate_until",
                table: "ClinicalEvent",
                columns: new[] { "EventId", "ValidUntilDtTm" });

            migrationBuilder.CreateIndex(
                name: "ix_order_id_valid_from",
                table: "ClinicalEvent",
                columns: new[] { "OrderId", "ValidFromDtTm" });

            migrationBuilder.CreateIndex(
                name: "ix_parent_event_id_valid_until",
                table: "ClinicalEvent",
                columns: new[] { "ParentEventId", "ValidUntilDtTm" });

            migrationBuilder.CreateIndex(
                name: "ix_performed_dttm_event_cd",
                table: "ClinicalEvent",
                columns: new[] { "PerformedDtTm", "EventCd" });

            migrationBuilder.CreateIndex(
                name: "ix_person_id_event_cd_valid_until",
                table: "ClinicalEvent",
                columns: new[] { "PersonId", "EventCd", "ClinsigUpdtDtTm", "ValidUntilDtTm" });

            migrationBuilder.CreateIndex(
                name: "ix_person_id_updat_dttm",
                table: "ClinicalEvent",
                columns: new[] { "PersonId", "UpdatedDateTime" });

            migrationBuilder.CreateIndex(
                name: "ix_person_id_valid_from",
                table: "ClinicalEvent",
                columns: new[] { "PersonId", "ValidFromDtTm" });

            migrationBuilder.CreateIndex(
                name: "ix_personid_event_cd_event_end_dttm_valid_until",
                table: "ClinicalEvent",
                columns: new[] { "PersonId", "EventCd", "EventEndDtTm", "ValidUntilDtTm" });

            migrationBuilder.CreateIndex(
                name: "ix_personid_event_end_dttm_valid_encntrid",
                table: "ClinicalEvent",
                columns: new[] { "PersonId", "EventEndDtTm", "ValidUntilDtTm", "EncntrId", "ResultStatusCd", "PerformedPrsnlId" });

            migrationBuilder.CreateIndex(
                name: "ix_ref_num_validate_dttm_contrib",
                table: "ClinicalEvent",
                columns: new[] { "ReferenceNbr", "ValidFromDtTm", "ContributorSystemCd" });

            migrationBuilder.CreateIndex(
                name: "ix_series_ref_nbr",
                table: "ClinicalEvent",
                column: "SeriesRefNbr");

            migrationBuilder.CreateIndex(
                name: "ix_src_event_id_valid_until",
                table: "ClinicalEvent",
                columns: new[] { "SrcEventId", "ValidUntilDtTm" });

            migrationBuilder.CreateIndex(
                name: "IX_CodeValueSet_CodeSet",
                table: "CodeValueSet",
                column: "CodeSet",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_orderid_actionseq",
                table: "OrderAction",
                columns: new[] { "OrderId", "ActionSequence" });

            migrationBuilder.CreateIndex(
                name: "ix_provider_actiondttm_actionseq",
                table: "OrderAction",
                columns: new[] { "OrderProviderId", "ActionDtTm", "ActionSequence" });

            migrationBuilder.CreateIndex(
                name: "ix_prsnl_actiondttm_actionseq",
                table: "OrderAction",
                columns: new[] { "ActionPersonnelId", "ActionDtTm", "ActionSequence" });

            migrationBuilder.CreateIndex(
                name: "ix_primary_mnemonic",
                table: "OrderCatalog",
                column: "PrimaryMnemonic");

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
                name: "IX_OrderCatalogSynonym_MnemonicKeyCap_MnemonicTypeCd_CatalogTy~",
                table: "OrderCatalogSynonym",
                columns: new[] { "MnemonicKeyCap", "MnemonicTypeCd", "CatalogTypeCd", "OrderableTypeFlag" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderCatalogSynonym_MnemonicKeyCap_SynonymId",
                table: "OrderCatalogSynonym",
                columns: new[] { "MnemonicKeyCap", "SynonymId" });

            migrationBuilder.CreateIndex(
                name: "ix_encntr_catalogtype_catalog",
                table: "Orders",
                columns: new[] { "EncntrId", "CatalogTypeCd", "CatalogCd" });

            migrationBuilder.CreateIndex(
                name: "ix_orderstatus_statusdttm",
                table: "Orders",
                columns: new[] { "OrderStatusCd", "StatusDtTm" });

            migrationBuilder.CreateIndex(
                name: "ix_origdttm_prodid_status_etc",
                table: "Orders",
                columns: new[] { "OrigOrderDtTm", "ProductId", "OrderStatusCd", "ActivityTypeCd", "SynonymId" });

            migrationBuilder.CreateIndex(
                name: "ix_person_catalog",
                table: "Orders",
                columns: new[] { "PersonId", "CatalogCd" });

            migrationBuilder.CreateIndex(
                name: "ix_person_catalogtype",
                table: "Orders",
                columns: new[] { "PersonId", "CatalogTypeCd" });

            migrationBuilder.CreateIndex(
                name: "ix_person_curstart_tflag_catalogtype",
                table: "Orders",
                columns: new[] { "PersonId", "CurrentStartDtTm", "TemplateOrderFlag", "CatalogTypeCd" });

            migrationBuilder.CreateIndex(
                name: "ix_person_encntr_start_projstop",
                table: "Orders",
                columns: new[] { "PersonId", "EncntrId", "HideFlag", "CurrentStartDtTm", "ProjectedStopDtTm" });

            migrationBuilder.CreateIndex(
                name: "ix_person_orderstatus_catalogtype",
                table: "Orders",
                columns: new[] { "PersonId", "OrderStatusCd", "CatalogTypeCd" });

            migrationBuilder.CreateIndex(
                name: "ix_person_ordestatus_tflag",
                table: "Orders",
                columns: new[] { "PersonId", "OrderStatusCd", "TemplateOrderFlag" });

            migrationBuilder.CreateIndex(
                name: "ix_person_projstop_catalogtype_encntr",
                table: "Orders",
                columns: new[] { "PersonId", "ProjectedStopDtTm", "CatalogTypeCd", "TemplateOrderFlag", "EncntrId" });

            migrationBuilder.CreateIndex(
                name: "ix_person_updtdttm",
                table: "Orders",
                columns: new[] { "PersonId", "UpdatedDateTime" });

            migrationBuilder.CreateIndex(
                name: "ix_rxverify_acttype_catalogtype_encntr",
                table: "Orders",
                columns: new[] { "NeedRxVerifyFlag", "ActivityTypeCd", "CatalogTypeCd", "EncntrId" });

            migrationBuilder.CreateIndex(
                name: "ix_updtdttm_orderid",
                table: "Orders",
                columns: new[] { "UpdatedDateTime", "OrderId" });

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
                name: "IX_TaskActivity_PersonId_TaskTypeCd_TaskStatusCd_TaskDtTm_Task~",
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

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_UserId",
                table: "UserProfiles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProfilesHx_UserId",
                table: "UserProfilesHx",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClinicalEvent");

            migrationBuilder.DropTable(
                name: "CodeValue");

            migrationBuilder.DropTable(
                name: "CodeValueSet");

            migrationBuilder.DropTable(
                name: "OrderAction");

            migrationBuilder.DropTable(
                name: "OrderCatalog");

            migrationBuilder.DropTable(
                name: "OrderCatalogSynonym");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "OrderTask");

            migrationBuilder.DropTable(
                name: "TaskActivity");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "UserProfilesHx");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
