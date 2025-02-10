using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVVM_play.Migrations
{
    /// <inheritdoc />
    public partial class AddedClinicalEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clinical_event",
                columns: table => new
                {
                    clinical_event_id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    accession_nbr = table.Column<string>(type: "varchar(20)", nullable: true),
                    authentic_flag = table.Column<short>(type: "INTEGER", nullable: false),
                    catalog_cd = table.Column<long>(type: "INTEGER", nullable: false),
                    ce_dynamic_label_id = table.Column<long>(type: "INTEGER", nullable: false),
                    clinical_seq = table.Column<string>(type: "varchar(40)", nullable: true),
                    clinsig_updt_dt_tm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    clu_subkey1_flag = table.Column<short>(type: "INTEGER", nullable: true),
                    collating_seq = table.Column<string>(type: "varchar(40)", nullable: true),
                    contributor_system_cd = table.Column<short>(type: "INTEGER", nullable: false),
                    critical_high = table.Column<string>(type: "varchar(20)", nullable: true),
                    critical_low = table.Column<string>(type: "varchar(20)", nullable: true),
                    device_free_txt = table.Column<string>(type: "varchar(255)", nullable: true),
                    encntr_financial_id = table.Column<long>(type: "INTEGER", nullable: false),
                    encntr_id = table.Column<long>(type: "INTEGER", nullable: false),
                    entry_mode_cd = table.Column<long>(type: "INTEGER", nullable: false),
                    event_cd = table.Column<long>(type: "INTEGER", nullable: false),
                    event_class_cd = table.Column<long>(type: "INTEGER", nullable: false),
                    event_end_dt_tm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    event_end_dt_tm_os = table.Column<decimal>(type: "TEXT", nullable: true),
                    event_end_tz = table.Column<int>(type: "INTEGER", nullable: true),
                    event_id = table.Column<long>(type: "INTEGER", nullable: false),
                    event_reltn_cd = table.Column<long>(type: "INTEGER", nullable: false),
                    event_start_dt_tm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    event_start_tz = table.Column<int>(type: "INTEGER", nullable: true),
                    event_tag = table.Column<string>(type: "varchar(255)", nullable: false),
                    event_tag_set_flag = table.Column<short>(type: "INTEGER", nullable: true),
                    event_title_text = table.Column<string>(type: "varchar(255)", nullable: true),
                    expiration_dt_tm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    inquire_security_cd = table.Column<long>(type: "INTEGER", nullable: false),
                    inst_id = table.Column<long>(type: "INTEGER", nullable: true),
                    modifier_long_text_id = table.Column<long>(type: "INTEGER", nullable: false),
                    nomen_string_flag = table.Column<short>(type: "INTEGER", nullable: true),
                    normalcy_cd = table.Column<long>(type: "INTEGER", nullable: false),
                    normalcy_method_cd = table.Column<long>(type: "INTEGER", nullable: false),
                    normal_high = table.Column<string>(type: "varchar(20)", nullable: true),
                    normal_low = table.Column<string>(type: "varchar(20)", nullable: true),
                    normal_ref_range_txt = table.Column<string>(type: "varchar(2000)", nullable: true),
                    note_importance_bit_map = table.Column<long>(type: "INTEGER", nullable: true),
                    order_action_sequence = table.Column<long>(type: "INTEGER", nullable: false),
                    order_id = table.Column<long>(type: "INTEGER", nullable: false),
                    parent_event_id = table.Column<long>(type: "INTEGER", nullable: false),
                    performed_dt_tm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    performed_tz = table.Column<int>(type: "INTEGER", nullable: true),
                    performed_prsnl_id = table.Column<long>(type: "INTEGER", nullable: false),
                    person_id = table.Column<long>(type: "INTEGER", nullable: false),
                    publish_flag = table.Column<short>(type: "INTEGER", nullable: false),
                    qc_review_cd = table.Column<long>(type: "INTEGER", nullable: false),
                    record_status_cd = table.Column<long>(type: "INTEGER", nullable: false),
                    reference_nbr = table.Column<string>(type: "varchar(100)", nullable: true),
                    resource_cd = table.Column<long>(type: "INTEGER", nullable: true),
                    resource_group_cd = table.Column<long>(type: "INTEGER", nullable: true),
                    result_status_cd = table.Column<long>(type: "INTEGER", nullable: false),
                    result_time_units_cd = table.Column<long>(type: "INTEGER", nullable: true),
                    result_units_cd = table.Column<long>(type: "INTEGER", nullable: true),
                    result_val = table.Column<string>(type: "varchar(255)", nullable: true),
                    series_ref_nbr = table.Column<string>(type: "varchar(100)", nullable: true),
                    source_cd = table.Column<long>(type: "INTEGER", nullable: true),
                    src_event_id = table.Column<long>(type: "INTEGER", nullable: false),
                    src_clinsig_updt_dt_tm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    subtable_bit_map = table.Column<int>(type: "INTEGER", nullable: true),
                    task_assay_cd = table.Column<long>(type: "INTEGER", nullable: true),
                    task_assay_version_nbr = table.Column<long>(type: "INTEGER", nullable: true),
                    updt_applctx = table.Column<long>(type: "INTEGER", nullable: false),
                    updt_cnt = table.Column<int>(type: "INTEGER", nullable: false),
                    updt_dt_tm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updt_id = table.Column<long>(type: "INTEGER", nullable: false),
                    updt_task = table.Column<int>(type: "INTEGER", nullable: false),
                    valid_from_dt_tm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    valid_until_dt_tm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    verified_dt_tm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    verified_prsnl_id = table.Column<long>(type: "INTEGER", nullable: false),
                    view_level = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clinical_event", x => x.clinical_event_id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_ce_dynamic_label_id_valid_until",
                table: "clinical_event",
                columns: new[] { "ce_dynamic_label_id", "valid_until_dt_tm" });

            migrationBuilder.CreateIndex(
                name: "ix_encntr_id_clinsig_updt_dttm",
                table: "clinical_event",
                columns: new[] { "encntr_id", "clinsig_updt_dt_tm" });

            migrationBuilder.CreateIndex(
                name: "ix_encntr_id_event_class_cd",
                table: "clinical_event",
                columns: new[] { "encntr_id", "event_class_cd" });

            migrationBuilder.CreateIndex(
                name: "ix_encntr_id_result_status",
                table: "clinical_event",
                columns: new[] { "encntr_id", "result_status_cd" });

            migrationBuilder.CreateIndex(
                name: "ix_event_cd_event_end_dt_tm",
                table: "clinical_event",
                columns: new[] { "event_cd", "event_end_dt_tm" });

            migrationBuilder.CreateIndex(
                name: "ix_event_id_validate_until",
                table: "clinical_event",
                columns: new[] { "event_id", "valid_until_dt_tm" });

            migrationBuilder.CreateIndex(
                name: "ix_order_id_valid_from",
                table: "clinical_event",
                columns: new[] { "order_id", "valid_from_dt_tm" });

            migrationBuilder.CreateIndex(
                name: "ix_parent_event_id_valid_until",
                table: "clinical_event",
                columns: new[] { "parent_event_id", "valid_until_dt_tm" });

            migrationBuilder.CreateIndex(
                name: "ix_performed_dttm_event_cd",
                table: "clinical_event",
                columns: new[] { "performed_dt_tm", "event_cd" });

            migrationBuilder.CreateIndex(
                name: "ix_person_id_event_cd_valid_until",
                table: "clinical_event",
                columns: new[] { "person_id", "event_cd", "clinsig_updt_dt_tm", "valid_until_dt_tm" });

            migrationBuilder.CreateIndex(
                name: "ix_person_id_updat_dttm",
                table: "clinical_event",
                columns: new[] { "person_id", "updt_dt_tm" });

            migrationBuilder.CreateIndex(
                name: "ix_person_id_valid_from",
                table: "clinical_event",
                columns: new[] { "person_id", "valid_from_dt_tm" });

            migrationBuilder.CreateIndex(
                name: "ix_personid_event_cd_event_end_dttm_valid_until",
                table: "clinical_event",
                columns: new[] { "person_id", "event_cd", "event_end_dt_tm", "valid_until_dt_tm" });

            migrationBuilder.CreateIndex(
                name: "ix_personid_event_end_dttm_valid_encntrid",
                table: "clinical_event",
                columns: new[] { "person_id", "event_end_dt_tm", "valid_until_dt_tm", "encntr_id", "result_status_cd", "performed_prsnl_id" });

            migrationBuilder.CreateIndex(
                name: "ix_ref_num_validate_dttm_contrib",
                table: "clinical_event",
                columns: new[] { "reference_nbr", "valid_from_dt_tm", "contributor_system_cd" });

            migrationBuilder.CreateIndex(
                name: "ix_series_ref_nbr",
                table: "clinical_event",
                column: "series_ref_nbr");

            migrationBuilder.CreateIndex(
                name: "ix_src_event_id_valid_until",
                table: "clinical_event",
                columns: new[] { "src_event_id", "valid_until_dt_tm" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clinical_event");
        }
    }
}
