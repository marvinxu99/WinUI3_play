using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVVM_play.Migrations
{
    /// <inheritdoc />
    public partial class AddedOrdersAndOrderAction2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderAction",
                columns: table => new
                {
                    OrderActionId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ActionDtTm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ActionTz = table.Column<int>(type: "INTEGER", nullable: true),
                    ActionInitiatedDtTm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ActionPersonnelId = table.Column<long>(type: "INTEGER", nullable: false),
                    ActionQualifierCd = table.Column<long>(type: "INTEGER", nullable: true),
                    ActionRejectedInd = table.Column<bool>(type: "INTEGER", nullable: true),
                    ActionSequence = table.Column<int>(type: "INTEGER", nullable: false),
                    ActionTypeCd = table.Column<long>(type: "INTEGER", nullable: false),
                    BillingProviderFlag = table.Column<short>(type: "INTEGER", nullable: true),
                    ClinicalDisplayLine = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    CommunicationTypeCd = table.Column<long>(type: "INTEGER", nullable: true),
                    ConstantInd = table.Column<bool>(type: "INTEGER", nullable: true),
                    ContributorSystemCd = table.Column<long>(type: "INTEGER", nullable: true),
                    CoreInd = table.Column<bool>(type: "INTEGER", nullable: true),
                    CurrentStartDtTm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CurrentStartTz = table.Column<int>(type: "INTEGER", nullable: true),
                    DeptStatusCd = table.Column<long>(type: "INTEGER", nullable: true),
                    DigitalSignatureIdent = table.Column<string>(type: "TEXT", maxLength: 64, nullable: true),
                    EffectiveDtTm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EffectiveTz = table.Column<int>(type: "INTEGER", nullable: true),
                    EsoActionCd = table.Column<long>(type: "INTEGER", nullable: true),
                    FormularyStatusCd = table.Column<long>(type: "INTEGER", nullable: true),
                    FrequencyId = table.Column<long>(type: "INTEGER", nullable: false),
                    IncompleteOrderInd = table.Column<bool>(type: "INTEGER", nullable: true),
                    MedstudentActionInd = table.Column<bool>(type: "INTEGER", nullable: true),
                    NeedsVerifyInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    NeedClinReviewFlag = table.Column<bool>(type: "INTEGER", nullable: false),
                    NextDoseDtTm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    OrderAppNbr = table.Column<int>(type: "INTEGER", nullable: true),
                    OrderConversationId = table.Column<long>(type: "INTEGER", nullable: true),
                    OrderConvsSeq = table.Column<int>(type: "INTEGER", nullable: true),
                    OrderDetailDisplayLine = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    OrderDtTm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OrderTz = table.Column<int>(type: "INTEGER", nullable: true),
                    OrderId = table.Column<long>(type: "INTEGER", nullable: false),
                    OrderLocnCd = table.Column<long>(type: "INTEGER", nullable: true),
                    OrderProviderId = table.Column<long>(type: "INTEGER", nullable: true),
                    OrderReviewStatusReasonBit = table.Column<int>(type: "INTEGER", nullable: true),
                    OrderSchedulePrecisionBit = table.Column<int>(type: "INTEGER", nullable: true),
                    OrderStatusCd = table.Column<long>(type: "INTEGER", nullable: false),
                    OrderStatusReasonBit = table.Column<int>(type: "INTEGER", nullable: true),
                    PrnInd = table.Column<bool>(type: "INTEGER", nullable: true),
                    ProjectedStopDtTm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ProjectedStopTz = table.Column<int>(type: "INTEGER", nullable: true),
                    SchStateCd = table.Column<long>(type: "INTEGER", nullable: true),
                    SimplifiedDisplayLine = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    SourceDotActionSeq = table.Column<int>(type: "INTEGER", nullable: false),
                    SourceDotOrderId = table.Column<long>(type: "INTEGER", nullable: true),
                    SourceProtocolActionSeq = table.Column<int>(type: "INTEGER", nullable: true),
                    StartRangeNbr = table.Column<int>(type: "INTEGER", nullable: true),
                    StartRangeUnitFlag = table.Column<short>(type: "INTEGER", nullable: true),
                    StopTypeCd = table.Column<long>(type: "INTEGER", nullable: true),
                    SupervisingProviderId = table.Column<long>(type: "INTEGER", nullable: true),
                    SynonymId = table.Column<long>(type: "INTEGER", nullable: true),
                    TemplateOrderFlag = table.Column<short>(type: "INTEGER", nullable: false),
                    UndoActionTypeCd = table.Column<long>(type: "INTEGER", nullable: true),
                    ValidDoseDtTm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderAction", x => x.OrderActionId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ActiveInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    ActiveStatusCd = table.Column<long>(type: "INTEGER", nullable: false),
                    ActiveStatusDtTm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ActiveStatusPrsnlId = table.Column<long>(type: "INTEGER", nullable: false),
                    ActivityTypeCd = table.Column<long>(type: "INTEGER", nullable: false),
                    AdHocOrderFlag = table.Column<short>(type: "INTEGER", nullable: false),
                    CatalogCd = table.Column<long>(type: "INTEGER", nullable: false),
                    CatalogTypeCd = table.Column<long>(type: "INTEGER", nullable: false),
                    Cki = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    ClinicalDisplayLine = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    ClinRelevantUpdtDtTm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ClinRelevantUpdtTz = table.Column<int>(type: "INTEGER", nullable: false),
                    CluSubkeyFlag = table.Column<short>(type: "INTEGER", nullable: false),
                    CommentTypeMask = table.Column<int>(type: "INTEGER", nullable: false),
                    ConstantInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    ContributorSystemCd = table.Column<long>(type: "INTEGER", nullable: false),
                    CsFlag = table.Column<short>(type: "INTEGER", nullable: true),
                    CsOrderId = table.Column<long>(type: "INTEGER", nullable: false),
                    CurrentStartDtTm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CurrentStartTz = table.Column<int>(type: "INTEGER", nullable: false),
                    DayOfTreatmentSequence = table.Column<int>(type: "INTEGER", nullable: false),
                    DcpClinCatCd = table.Column<long>(type: "INTEGER", nullable: false),
                    DeptMiscLine = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    DeptStatusCd = table.Column<long>(type: "INTEGER", nullable: true),
                    DiscontinueEffectiveDtTm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DiscontinueEffectiveTz = table.Column<int>(type: "INTEGER", nullable: true),
                    DiscontinueInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    DiscontinueTypeCd = table.Column<long>(type: "INTEGER", nullable: true),
                    DosingMethodFlag = table.Column<short>(type: "INTEGER", nullable: true),
                    EncounterFinancialId = table.Column<long>(type: "INTEGER", nullable: true),
                    EncntrId = table.Column<long>(type: "INTEGER", nullable: false),
                    EsoNewOrderInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    FormularyStatusCd = table.Column<long>(type: "INTEGER", nullable: true),
                    FrequencyId = table.Column<long>(type: "INTEGER", nullable: false),
                    FreqTypeFlag = table.Column<short>(type: "INTEGER", nullable: false),
                    FutureLocationFacilityCd = table.Column<long>(type: "INTEGER", nullable: true),
                    FutureLocationNurseUnitCd = table.Column<long>(type: "INTEGER", nullable: true),
                    GroupOrderFlag = table.Column<short>(type: "INTEGER", nullable: true),
                    GroupOrderId = table.Column<long>(type: "INTEGER", nullable: false),
                    HideFlag = table.Column<short>(type: "INTEGER", nullable: false),
                    HnaOrderMnemonic = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    IncompleteOrderInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    IngredientInd = table.Column<bool>(type: "INTEGER", nullable: true),
                    InstId = table.Column<long>(type: "INTEGER", nullable: true),
                    IntervalInd = table.Column<bool>(type: "INTEGER", nullable: true),
                    IVInd = table.Column<bool>(type: "INTEGER", nullable: true),
                    IvSetSynonymId = table.Column<long>(type: "INTEGER", nullable: false),
                    LastActionSequence = table.Column<int>(type: "INTEGER", nullable: false),
                    LastCoreActionSequence = table.Column<int>(type: "INTEGER", nullable: true),
                    LastIngredActionSequence = table.Column<int>(type: "INTEGER", nullable: true),
                    LastUpdateProviderId = table.Column<long>(type: "INTEGER", nullable: true),
                    LatestCommunicationTypeCd = table.Column<long>(type: "INTEGER", nullable: true),
                    LinkNbr = table.Column<long>(type: "INTEGER", nullable: true),
                    LinkOrderFlag = table.Column<short>(type: "INTEGER", nullable: true),
                    LinkOrderId = table.Column<long>(type: "INTEGER", nullable: true),
                    LinkTypeFlag = table.Column<short>(type: "INTEGER", nullable: true),
                    MedOrderTypeCd = table.Column<long>(type: "INTEGER", nullable: true),
                    ModifiedStartDtTm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    NeedDoctorCosignInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    NeedNurseReviewInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    NeedPhysicianValidateInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    NeedRxClinReviewFlag = table.Column<short>(type: "INTEGER", nullable: false),
                    NeedRxVerifyFlag = table.Column<short>(type: "INTEGER", nullable: false),
                    OeFormatId = table.Column<long>(type: "INTEGER", nullable: false),
                    OrderableTypeFlag = table.Column<short>(type: "INTEGER", nullable: false),
                    OrderedAsMnemonic = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    OrderCommentInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    OrderDetailDisplayLine = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    OrderMnemonic = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    OrderStatusCd = table.Column<long>(type: "INTEGER", nullable: false),
                    StatusDtTm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StatusPrsnlId = table.Column<long>(type: "INTEGER", nullable: true),
                    OrderStatusReasonBit = table.Column<int>(type: "INTEGER", nullable: true),
                    OriginatingEncntrId = table.Column<long>(type: "INTEGER", nullable: true),
                    OrigOrderConvsSeq = table.Column<int>(type: "INTEGER", nullable: true),
                    OrigOrderDtTm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    OrigOrderTz = table.Column<int>(type: "INTEGER", nullable: true),
                    OrigOrderAsFlag = table.Column<short>(type: "INTEGER", nullable: true),
                    OverrideFlag = table.Column<short>(type: "INTEGER", nullable: true),
                    PathwayCatalogId = table.Column<long>(type: "INTEGER", nullable: false),
                    PersonId = table.Column<long>(type: "INTEGER", nullable: false),
                    PrescriptionGroupValue = table.Column<long>(type: "INTEGER", nullable: true),
                    PrescriptionOrderId = table.Column<long>(type: "INTEGER", nullable: true),
                    PrnInd = table.Column<bool>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<long>(type: "INTEGER", nullable: true),
                    ProjectedStopDtTm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ProjectedStopTz = table.Column<int>(type: "INTEGER", nullable: true),
                    ProtocolOrderId = table.Column<long>(type: "INTEGER", nullable: true),
                    RefTextMask = table.Column<int>(type: "INTEGER", nullable: true),
                    ResumeEffectiveDtTm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ResumeEffectiveTz = table.Column<int>(type: "INTEGER", nullable: true),
                    ResumeInd = table.Column<bool>(type: "INTEGER", nullable: true),
                    RxMask = table.Column<int>(type: "INTEGER", nullable: true),
                    SchStateCd = table.Column<long>(type: "INTEGER", nullable: true),
                    SimplifiedDisplayLine = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    SoftStopDtTm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    SoftStopTz = table.Column<int>(type: "INTEGER", nullable: true),
                    SourceCd = table.Column<long>(type: "INTEGER", nullable: true),
                    StopTypeCd = table.Column<long>(type: "INTEGER", nullable: true),
                    SuspendEffectiveDtTm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SuspendEffectiveTz = table.Column<int>(type: "INTEGER", nullable: true),
                    SuspendInd = table.Column<bool>(type: "INTEGER", nullable: true),
                    SynonymId = table.Column<long>(type: "INTEGER", nullable: true),
                    TemplateCoreActionSequence = table.Column<int>(type: "INTEGER", nullable: true),
                    TemplateDoseSequence = table.Column<int>(type: "INTEGER", nullable: true),
                    TemplateOrderFlag = table.Column<short>(type: "INTEGER", nullable: true),
                    TemplateOrderId = table.Column<long>(type: "INTEGER", nullable: false),
                    VettingApprovalFlag = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderAction");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
