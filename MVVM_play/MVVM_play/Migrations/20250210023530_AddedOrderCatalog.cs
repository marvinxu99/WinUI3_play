using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace MVVM_play.Migrations
{
    /// <inheritdoc />
    public partial class AddedOrderCatalog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("PRAGMA foreign_keys = OFF;"); // Disable foreign keys before migration

            migrationBuilder.DropPrimaryKey(
                name: "PK_clinical_event",
                table: "clinical_event");

            migrationBuilder.DropColumn(
                name: "updt_applctx",
                table: "clinical_event");

            migrationBuilder.DropColumn(
                name: "updt_cnt",
                table: "clinical_event");

            migrationBuilder.DropColumn(
                name: "updt_id",
                table: "clinical_event");

            migrationBuilder.DropColumn(
                name: "updt_task",
                table: "clinical_event");

            migrationBuilder.RenameTable(
                name: "clinical_event",
                newName: "ClinicalEvent");

            migrationBuilder.RenameColumn(
                name: "view_level",
                table: "ClinicalEvent",
                newName: "ViewLevel");

            migrationBuilder.RenameColumn(
                name: "verified_prsnl_id",
                table: "ClinicalEvent",
                newName: "VerifiedPrsnlId");

            migrationBuilder.RenameColumn(
                name: "verified_dt_tm",
                table: "ClinicalEvent",
                newName: "VerifiedDtTm");

            migrationBuilder.RenameColumn(
                name: "valid_until_dt_tm",
                table: "ClinicalEvent",
                newName: "ValidUntilDtTm");

            migrationBuilder.RenameColumn(
                name: "valid_from_dt_tm",
                table: "ClinicalEvent",
                newName: "ValidFromDtTm");

            migrationBuilder.RenameColumn(
                name: "task_assay_version_nbr",
                table: "ClinicalEvent",
                newName: "TaskAssayVersionNbr");

            migrationBuilder.RenameColumn(
                name: "task_assay_cd",
                table: "ClinicalEvent",
                newName: "TaskAssayCd");

            migrationBuilder.RenameColumn(
                name: "subtable_bit_map",
                table: "ClinicalEvent",
                newName: "SubtableBitMap");

            migrationBuilder.RenameColumn(
                name: "src_event_id",
                table: "ClinicalEvent",
                newName: "SrcEventId");

            migrationBuilder.RenameColumn(
                name: "src_clinsig_updt_dt_tm",
                table: "ClinicalEvent",
                newName: "SrcClinsigUpdtDtTm");

            migrationBuilder.RenameColumn(
                name: "source_cd",
                table: "ClinicalEvent",
                newName: "SourceCd");

            migrationBuilder.RenameColumn(
                name: "series_ref_nbr",
                table: "ClinicalEvent",
                newName: "SeriesRefNbr");

            migrationBuilder.RenameColumn(
                name: "result_val",
                table: "ClinicalEvent",
                newName: "ResultVal");

            migrationBuilder.RenameColumn(
                name: "result_units_cd",
                table: "ClinicalEvent",
                newName: "ResultUnitsCd");

            migrationBuilder.RenameColumn(
                name: "result_time_units_cd",
                table: "ClinicalEvent",
                newName: "ResultTimeUnitsCd");

            migrationBuilder.RenameColumn(
                name: "result_status_cd",
                table: "ClinicalEvent",
                newName: "ResultStatusCd");

            migrationBuilder.RenameColumn(
                name: "resource_group_cd",
                table: "ClinicalEvent",
                newName: "ResourceGroupCd");

            migrationBuilder.RenameColumn(
                name: "resource_cd",
                table: "ClinicalEvent",
                newName: "ResourceCd");

            migrationBuilder.RenameColumn(
                name: "reference_nbr",
                table: "ClinicalEvent",
                newName: "ReferenceNbr");

            migrationBuilder.RenameColumn(
                name: "record_status_cd",
                table: "ClinicalEvent",
                newName: "RecordStatusCd");

            migrationBuilder.RenameColumn(
                name: "qc_review_cd",
                table: "ClinicalEvent",
                newName: "QcReviewCd");

            migrationBuilder.RenameColumn(
                name: "publish_flag",
                table: "ClinicalEvent",
                newName: "PublishFlag");

            migrationBuilder.RenameColumn(
                name: "person_id",
                table: "ClinicalEvent",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "performed_tz",
                table: "ClinicalEvent",
                newName: "PerformedTz");

            migrationBuilder.RenameColumn(
                name: "performed_prsnl_id",
                table: "ClinicalEvent",
                newName: "PerformedPrsnlId");

            migrationBuilder.RenameColumn(
                name: "performed_dt_tm",
                table: "ClinicalEvent",
                newName: "PerformedDtTm");

            migrationBuilder.RenameColumn(
                name: "parent_event_id",
                table: "ClinicalEvent",
                newName: "ParentEventId");

            migrationBuilder.RenameColumn(
                name: "order_id",
                table: "ClinicalEvent",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "order_action_sequence",
                table: "ClinicalEvent",
                newName: "OrderActionSequence");

            migrationBuilder.RenameColumn(
                name: "note_importance_bit_map",
                table: "ClinicalEvent",
                newName: "NoteImportanceBitMap");

            migrationBuilder.RenameColumn(
                name: "normalcy_method_cd",
                table: "ClinicalEvent",
                newName: "NormalcyMethodCd");

            migrationBuilder.RenameColumn(
                name: "normalcy_cd",
                table: "ClinicalEvent",
                newName: "NormalcyCd");

            migrationBuilder.RenameColumn(
                name: "normal_ref_range_txt",
                table: "ClinicalEvent",
                newName: "NormalRefRangeTxt");

            migrationBuilder.RenameColumn(
                name: "normal_low",
                table: "ClinicalEvent",
                newName: "NormalLow");

            migrationBuilder.RenameColumn(
                name: "normal_high",
                table: "ClinicalEvent",
                newName: "NormalHigh");

            migrationBuilder.RenameColumn(
                name: "nomen_string_flag",
                table: "ClinicalEvent",
                newName: "NomenStringFlag");

            migrationBuilder.RenameColumn(
                name: "modifier_long_text_id",
                table: "ClinicalEvent",
                newName: "ModifierLongTextId");

            migrationBuilder.RenameColumn(
                name: "inst_id",
                table: "ClinicalEvent",
                newName: "InstId");

            migrationBuilder.RenameColumn(
                name: "inquire_security_cd",
                table: "ClinicalEvent",
                newName: "InquireSecurityCd");

            migrationBuilder.RenameColumn(
                name: "expiration_dt_tm",
                table: "ClinicalEvent",
                newName: "ExpirationDtTm");

            migrationBuilder.RenameColumn(
                name: "event_title_text",
                table: "ClinicalEvent",
                newName: "EventTitleText");

            migrationBuilder.RenameColumn(
                name: "event_tag_set_flag",
                table: "ClinicalEvent",
                newName: "EventTagSetFlag");

            migrationBuilder.RenameColumn(
                name: "event_tag",
                table: "ClinicalEvent",
                newName: "EventTag");

            migrationBuilder.RenameColumn(
                name: "event_start_tz",
                table: "ClinicalEvent",
                newName: "EventStartTz");

            migrationBuilder.RenameColumn(
                name: "event_start_dt_tm",
                table: "ClinicalEvent",
                newName: "EventStartDtTm");

            migrationBuilder.RenameColumn(
                name: "event_reltn_cd",
                table: "ClinicalEvent",
                newName: "EventReltnCd");

            migrationBuilder.RenameColumn(
                name: "event_id",
                table: "ClinicalEvent",
                newName: "EventId");

            migrationBuilder.RenameColumn(
                name: "event_end_tz",
                table: "ClinicalEvent",
                newName: "EventEndTz");

            migrationBuilder.RenameColumn(
                name: "event_end_dt_tm_os",
                table: "ClinicalEvent",
                newName: "EventEndDtTmOs");

            migrationBuilder.RenameColumn(
                name: "event_end_dt_tm",
                table: "ClinicalEvent",
                newName: "EventEndDtTm");

            migrationBuilder.RenameColumn(
                name: "event_class_cd",
                table: "ClinicalEvent",
                newName: "EventClassCd");

            migrationBuilder.RenameColumn(
                name: "event_cd",
                table: "ClinicalEvent",
                newName: "EventCd");

            migrationBuilder.RenameColumn(
                name: "entry_mode_cd",
                table: "ClinicalEvent",
                newName: "EntryModeCd");

            migrationBuilder.RenameColumn(
                name: "encntr_id",
                table: "ClinicalEvent",
                newName: "EncntrId");

            migrationBuilder.RenameColumn(
                name: "encntr_financial_id",
                table: "ClinicalEvent",
                newName: "EncntrFinancialId");

            migrationBuilder.RenameColumn(
                name: "device_free_txt",
                table: "ClinicalEvent",
                newName: "DeviceFreeTxt");

            migrationBuilder.RenameColumn(
                name: "critical_low",
                table: "ClinicalEvent",
                newName: "CriticalLow");

            migrationBuilder.RenameColumn(
                name: "critical_high",
                table: "ClinicalEvent",
                newName: "CriticalHigh");

            migrationBuilder.RenameColumn(
                name: "contributor_system_cd",
                table: "ClinicalEvent",
                newName: "ContributorSystemCd");

            migrationBuilder.RenameColumn(
                name: "collating_seq",
                table: "ClinicalEvent",
                newName: "CollatingSeq");

            migrationBuilder.RenameColumn(
                name: "clu_subkey1_flag",
                table: "ClinicalEvent",
                newName: "CluSubkey1Flag");

            migrationBuilder.RenameColumn(
                name: "clinsig_updt_dt_tm",
                table: "ClinicalEvent",
                newName: "ClinsigUpdtDtTm");

            migrationBuilder.RenameColumn(
                name: "clinical_seq",
                table: "ClinicalEvent",
                newName: "ClinicalSeq");

            migrationBuilder.RenameColumn(
                name: "ce_dynamic_label_id",
                table: "ClinicalEvent",
                newName: "CeDynamicLabelId");

            migrationBuilder.RenameColumn(
                name: "catalog_cd",
                table: "ClinicalEvent",
                newName: "CatalogCd");

            migrationBuilder.RenameColumn(
                name: "authentic_flag",
                table: "ClinicalEvent",
                newName: "AuthenticFlag");

            migrationBuilder.RenameColumn(
                name: "accession_nbr",
                table: "ClinicalEvent",
                newName: "AccessionNbr");

            migrationBuilder.RenameColumn(
                name: "clinical_event_id",
                table: "ClinicalEvent",
                newName: "ClinicalEventId");

            migrationBuilder.RenameColumn(
                name: "updt_dt_tm",
                table: "ClinicalEvent",
                newName: "UpdatedDateTime");

            migrationBuilder.AlterColumn<string>(
                name: "SeriesRefNbr",
                table: "ClinicalEvent",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ResultVal",
                table: "ClinicalEvent",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReferenceNbr",
                table: "ClinicalEvent",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalRefRangeTxt",
                table: "ClinicalEvent",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalLow",
                table: "ClinicalEvent",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalHigh",
                table: "ClinicalEvent",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EventTitleText",
                table: "ClinicalEvent",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EventTag",
                table: "ClinicalEvent",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "DeviceFreeTxt",
                table: "ClinicalEvent",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CriticalLow",
                table: "ClinicalEvent",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CriticalHigh",
                table: "ClinicalEvent",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CollatingSeq",
                table: "ClinicalEvent",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(40)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClinicalSeq",
                table: "ClinicalEvent",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(40)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AccessionNbr",
                table: "ClinicalEvent",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ClinicalEvent",
                type: "TEXT",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "ClinicalEvent",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ClinicalEvent",
                type: "TEXT",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<uint>(
                name: "xmin",
                table: "ClinicalEvent",
                type: "xid",
                rowVersion: true,
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClinicalEvent",
                table: "ClinicalEvent",
                column: "ClinicalEventId");

            migrationBuilder.CreateTable(
                name: "OrderCatalog",
                columns: table => new
                {
                    CatalogCd = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PrimaryMnemonic = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    AbnReviewInd = table.Column<bool>(type: "INTEGER", nullable: true),
                    ActiveInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    ActivityTypeCd = table.Column<long>(type: "INTEGER", nullable: false),
                    ActivitySubtypeCd = table.Column<long>(type: "INTEGER", nullable: false),
                    AutoCancelInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    BillOnlyInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    CatalogTypeCd = table.Column<long>(type: "INTEGER", nullable: false),
                    Cki = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    CommentTemplateFlag = table.Column<short>(type: "INTEGER", nullable: true),
                    CompleteUponOrderInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    ConceptCki = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    ConsentFormFormatCd = table.Column<long>(type: "INTEGER", nullable: true),
                    ConsentFormInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    ConsentFormRoutingCd = table.Column<long>(type: "INTEGER", nullable: true),
                    ContOrderMethodFlag = table.Column<short>(type: "INTEGER", nullable: false),
                    DcpClinCatCd = table.Column<long>(type: "INTEGER", nullable: false),
                    DcDisplayDays = table.Column<int>(type: "INTEGER", nullable: false),
                    DcInteractionDays = table.Column<int>(type: "INTEGER", nullable: false),
                    DeptDisplayName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    DeptDupCheckInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    DisableOrderCommentInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    DiscernAutoVerifyFlag = table.Column<bool>(type: "INTEGER", nullable: false),
                    DosingActIngredCode = table.Column<int>(type: "INTEGER", nullable: true),
                    DosingAllIngredInd = table.Column<bool>(type: "INTEGER", nullable: true),
                    DupCheckInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    EventCd = table.Column<long>(type: "INTEGER", nullable: false),
                    FormId = table.Column<long>(type: "INTEGER", nullable: false),
                    FormLevel = table.Column<short>(type: "INTEGER", nullable: true),
                    InstId = table.Column<long>(type: "INTEGER", nullable: true),
                    InstRestrictionInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    ModifiableFlag = table.Column<int>(type: "INTEGER", nullable: false),
                    OeFormatId = table.Column<long>(type: "INTEGER", nullable: false),
                    OpDcDisplayDays = table.Column<int>(type: "INTEGER", nullable: false),
                    OpDcInteractionDays = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderableTypeFlag = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderReviewInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    OrdComTemplateLongTextId = table.Column<long>(type: "INTEGER", nullable: false),
                    PrepInfoFlag = table.Column<int>(type: "INTEGER", nullable: true),
                    PrintReqInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    PromptInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    QuickChartInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    RefTextMask = table.Column<int>(type: "INTEGER", nullable: true),
                    RequisitionFormatCd = table.Column<long>(type: "INTEGER", nullable: false),
                    RequisitionRoutingCd = table.Column<long>(type: "INTEGER", nullable: false),
                    ResourceRouteCd = table.Column<long>(type: "INTEGER", nullable: false),
                    ResourceRouteLvl = table.Column<int>(type: "INTEGER", nullable: true),
                    ReviewHierarchyId = table.Column<long>(type: "INTEGER", nullable: false),
                    ScheduleInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    SourceVocabIdent = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    SourceVocabMean = table.Column<string>(type: "TEXT", maxLength: 12, nullable: true),
                    StopDuration = table.Column<int>(type: "INTEGER", nullable: false),
                    StopDurationUnitCd = table.Column<long>(type: "INTEGER", nullable: false),
                    StopTypeCd = table.Column<long>(type: "INTEGER", nullable: false),
                    TxnIdText = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    VettingApprovalFlag = table.Column<bool>(type: "INTEGER", nullable: false),
                    UpdtApplctx = table.Column<long>(type: "INTEGER", nullable: false),
                    UpdtCnt = table.Column<int>(type: "INTEGER", nullable: false),
                    UpdtDtTm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdtId = table.Column<long>(type: "INTEGER", nullable: false),
                    UpdtTask = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderCatalog", x => x.CatalogCd);
                });

            migrationBuilder.CreateIndex(
                name: "ix_primary_mnemonic",
                table: "OrderCatalog",
                column: "PrimaryMnemonic");

            migrationBuilder.Sql("PRAGMA foreign_keys = ON;");  // Re-enable after migration
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("PRAGMA foreign_keys = OFF;"); // Disable foreign keys before migration

            migrationBuilder.DropTable(
                name: "OrderCatalog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClinicalEvent",
                table: "ClinicalEvent");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ClinicalEvent");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "ClinicalEvent");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ClinicalEvent");

            migrationBuilder.DropColumn(
                name: "xmin",
                table: "ClinicalEvent");

            migrationBuilder.RenameTable(
                name: "ClinicalEvent",
                newName: "clinical_event");

            migrationBuilder.RenameColumn(
                name: "ViewLevel",
                table: "clinical_event",
                newName: "view_level");

            migrationBuilder.RenameColumn(
                name: "VerifiedPrsnlId",
                table: "clinical_event",
                newName: "verified_prsnl_id");

            migrationBuilder.RenameColumn(
                name: "VerifiedDtTm",
                table: "clinical_event",
                newName: "verified_dt_tm");

            migrationBuilder.RenameColumn(
                name: "ValidUntilDtTm",
                table: "clinical_event",
                newName: "valid_until_dt_tm");

            migrationBuilder.RenameColumn(
                name: "ValidFromDtTm",
                table: "clinical_event",
                newName: "valid_from_dt_tm");

            migrationBuilder.RenameColumn(
                name: "TaskAssayVersionNbr",
                table: "clinical_event",
                newName: "task_assay_version_nbr");

            migrationBuilder.RenameColumn(
                name: "TaskAssayCd",
                table: "clinical_event",
                newName: "task_assay_cd");

            migrationBuilder.RenameColumn(
                name: "SubtableBitMap",
                table: "clinical_event",
                newName: "subtable_bit_map");

            migrationBuilder.RenameColumn(
                name: "SrcEventId",
                table: "clinical_event",
                newName: "src_event_id");

            migrationBuilder.RenameColumn(
                name: "SrcClinsigUpdtDtTm",
                table: "clinical_event",
                newName: "src_clinsig_updt_dt_tm");

            migrationBuilder.RenameColumn(
                name: "SourceCd",
                table: "clinical_event",
                newName: "source_cd");

            migrationBuilder.RenameColumn(
                name: "SeriesRefNbr",
                table: "clinical_event",
                newName: "series_ref_nbr");

            migrationBuilder.RenameColumn(
                name: "ResultVal",
                table: "clinical_event",
                newName: "result_val");

            migrationBuilder.RenameColumn(
                name: "ResultUnitsCd",
                table: "clinical_event",
                newName: "result_units_cd");

            migrationBuilder.RenameColumn(
                name: "ResultTimeUnitsCd",
                table: "clinical_event",
                newName: "result_time_units_cd");

            migrationBuilder.RenameColumn(
                name: "ResultStatusCd",
                table: "clinical_event",
                newName: "result_status_cd");

            migrationBuilder.RenameColumn(
                name: "ResourceGroupCd",
                table: "clinical_event",
                newName: "resource_group_cd");

            migrationBuilder.RenameColumn(
                name: "ResourceCd",
                table: "clinical_event",
                newName: "resource_cd");

            migrationBuilder.RenameColumn(
                name: "ReferenceNbr",
                table: "clinical_event",
                newName: "reference_nbr");

            migrationBuilder.RenameColumn(
                name: "RecordStatusCd",
                table: "clinical_event",
                newName: "record_status_cd");

            migrationBuilder.RenameColumn(
                name: "QcReviewCd",
                table: "clinical_event",
                newName: "qc_review_cd");

            migrationBuilder.RenameColumn(
                name: "PublishFlag",
                table: "clinical_event",
                newName: "publish_flag");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "clinical_event",
                newName: "person_id");

            migrationBuilder.RenameColumn(
                name: "PerformedTz",
                table: "clinical_event",
                newName: "performed_tz");

            migrationBuilder.RenameColumn(
                name: "PerformedPrsnlId",
                table: "clinical_event",
                newName: "performed_prsnl_id");

            migrationBuilder.RenameColumn(
                name: "PerformedDtTm",
                table: "clinical_event",
                newName: "performed_dt_tm");

            migrationBuilder.RenameColumn(
                name: "ParentEventId",
                table: "clinical_event",
                newName: "parent_event_id");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "clinical_event",
                newName: "order_id");

            migrationBuilder.RenameColumn(
                name: "OrderActionSequence",
                table: "clinical_event",
                newName: "order_action_sequence");

            migrationBuilder.RenameColumn(
                name: "NoteImportanceBitMap",
                table: "clinical_event",
                newName: "note_importance_bit_map");

            migrationBuilder.RenameColumn(
                name: "NormalcyMethodCd",
                table: "clinical_event",
                newName: "normalcy_method_cd");

            migrationBuilder.RenameColumn(
                name: "NormalcyCd",
                table: "clinical_event",
                newName: "normalcy_cd");

            migrationBuilder.RenameColumn(
                name: "NormalRefRangeTxt",
                table: "clinical_event",
                newName: "normal_ref_range_txt");

            migrationBuilder.RenameColumn(
                name: "NormalLow",
                table: "clinical_event",
                newName: "normal_low");

            migrationBuilder.RenameColumn(
                name: "NormalHigh",
                table: "clinical_event",
                newName: "normal_high");

            migrationBuilder.RenameColumn(
                name: "NomenStringFlag",
                table: "clinical_event",
                newName: "nomen_string_flag");

            migrationBuilder.RenameColumn(
                name: "ModifierLongTextId",
                table: "clinical_event",
                newName: "modifier_long_text_id");

            migrationBuilder.RenameColumn(
                name: "InstId",
                table: "clinical_event",
                newName: "inst_id");

            migrationBuilder.RenameColumn(
                name: "InquireSecurityCd",
                table: "clinical_event",
                newName: "inquire_security_cd");

            migrationBuilder.RenameColumn(
                name: "ExpirationDtTm",
                table: "clinical_event",
                newName: "expiration_dt_tm");

            migrationBuilder.RenameColumn(
                name: "EventTitleText",
                table: "clinical_event",
                newName: "event_title_text");

            migrationBuilder.RenameColumn(
                name: "EventTagSetFlag",
                table: "clinical_event",
                newName: "event_tag_set_flag");

            migrationBuilder.RenameColumn(
                name: "EventTag",
                table: "clinical_event",
                newName: "event_tag");

            migrationBuilder.RenameColumn(
                name: "EventStartTz",
                table: "clinical_event",
                newName: "event_start_tz");

            migrationBuilder.RenameColumn(
                name: "EventStartDtTm",
                table: "clinical_event",
                newName: "event_start_dt_tm");

            migrationBuilder.RenameColumn(
                name: "EventReltnCd",
                table: "clinical_event",
                newName: "event_reltn_cd");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "clinical_event",
                newName: "event_id");

            migrationBuilder.RenameColumn(
                name: "EventEndTz",
                table: "clinical_event",
                newName: "event_end_tz");

            migrationBuilder.RenameColumn(
                name: "EventEndDtTmOs",
                table: "clinical_event",
                newName: "event_end_dt_tm_os");

            migrationBuilder.RenameColumn(
                name: "EventEndDtTm",
                table: "clinical_event",
                newName: "event_end_dt_tm");

            migrationBuilder.RenameColumn(
                name: "EventClassCd",
                table: "clinical_event",
                newName: "event_class_cd");

            migrationBuilder.RenameColumn(
                name: "EventCd",
                table: "clinical_event",
                newName: "event_cd");

            migrationBuilder.RenameColumn(
                name: "EntryModeCd",
                table: "clinical_event",
                newName: "entry_mode_cd");

            migrationBuilder.RenameColumn(
                name: "EncntrId",
                table: "clinical_event",
                newName: "encntr_id");

            migrationBuilder.RenameColumn(
                name: "EncntrFinancialId",
                table: "clinical_event",
                newName: "encntr_financial_id");

            migrationBuilder.RenameColumn(
                name: "DeviceFreeTxt",
                table: "clinical_event",
                newName: "device_free_txt");

            migrationBuilder.RenameColumn(
                name: "CriticalLow",
                table: "clinical_event",
                newName: "critical_low");

            migrationBuilder.RenameColumn(
                name: "CriticalHigh",
                table: "clinical_event",
                newName: "critical_high");

            migrationBuilder.RenameColumn(
                name: "ContributorSystemCd",
                table: "clinical_event",
                newName: "contributor_system_cd");

            migrationBuilder.RenameColumn(
                name: "CollatingSeq",
                table: "clinical_event",
                newName: "collating_seq");

            migrationBuilder.RenameColumn(
                name: "CluSubkey1Flag",
                table: "clinical_event",
                newName: "clu_subkey1_flag");

            migrationBuilder.RenameColumn(
                name: "ClinsigUpdtDtTm",
                table: "clinical_event",
                newName: "clinsig_updt_dt_tm");

            migrationBuilder.RenameColumn(
                name: "ClinicalSeq",
                table: "clinical_event",
                newName: "clinical_seq");

            migrationBuilder.RenameColumn(
                name: "CeDynamicLabelId",
                table: "clinical_event",
                newName: "ce_dynamic_label_id");

            migrationBuilder.RenameColumn(
                name: "CatalogCd",
                table: "clinical_event",
                newName: "catalog_cd");

            migrationBuilder.RenameColumn(
                name: "AuthenticFlag",
                table: "clinical_event",
                newName: "authentic_flag");

            migrationBuilder.RenameColumn(
                name: "AccessionNbr",
                table: "clinical_event",
                newName: "accession_nbr");

            migrationBuilder.RenameColumn(
                name: "ClinicalEventId",
                table: "clinical_event",
                newName: "clinical_event_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedDateTime",
                table: "clinical_event",
                newName: "updt_dt_tm");

            migrationBuilder.AlterColumn<string>(
                name: "series_ref_nbr",
                table: "clinical_event",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "result_val",
                table: "clinical_event",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "reference_nbr",
                table: "clinical_event",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "normal_ref_range_txt",
                table: "clinical_event",
                type: "varchar(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "normal_low",
                table: "clinical_event",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "normal_high",
                table: "clinical_event",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "event_title_text",
                table: "clinical_event",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "event_tag",
                table: "clinical_event",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "device_free_txt",
                table: "clinical_event",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "critical_low",
                table: "clinical_event",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "critical_high",
                table: "clinical_event",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "collating_seq",
                table: "clinical_event",
                type: "varchar(40)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "clinical_seq",
                table: "clinical_event",
                type: "varchar(40)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "accession_nbr",
                table: "clinical_event",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "updt_applctx",
                table: "clinical_event",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "updt_cnt",
                table: "clinical_event",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "updt_id",
                table: "clinical_event",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "updt_task",
                table: "clinical_event",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_clinical_event",
                table: "clinical_event",
                column: "clinical_event_id");

            migrationBuilder.Sql("PRAGMA foreign_keys = ON;");  // Re-enable after migration
        }
    }
}
