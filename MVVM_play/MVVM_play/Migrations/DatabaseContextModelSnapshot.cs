﻿// <auto-generated />
using System;
using MVVM_play.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVVM_play.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("MVVM_play.Models.ClinicalEvent", b =>
                {
                    b.Property<long>("ClinicalEventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AccessionNbr")
                        .HasColumnType("TEXT");

                    b.Property<short>("AuthenticFlag")
                        .HasColumnType("INTEGER");

                    b.Property<long>("CatalogCd")
                        .HasColumnType("INTEGER");

                    b.Property<long>("CeDynamicLabelId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClinicalSeq")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ClinsigUpdtDtTm")
                        .HasColumnType("TEXT");

                    b.Property<short?>("CluSubkey1Flag")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CollatingSeq")
                        .HasColumnType("TEXT");

                    b.Property<short>("ContributorSystemCd")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("CriticalHigh")
                        .HasColumnType("TEXT");

                    b.Property<string>("CriticalLow")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeviceFreeTxt")
                        .HasColumnType("TEXT");

                    b.Property<long>("EncntrFinancialId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("EncntrId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("EntryModeCd")
                        .HasColumnType("INTEGER");

                    b.Property<long>("EventCd")
                        .HasColumnType("INTEGER");

                    b.Property<long>("EventClassCd")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EventEndDtTm")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("EventEndDtTmOs")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EventEndTz")
                        .HasColumnType("INTEGER");

                    b.Property<long>("EventId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("EventReltnCd")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("EventStartDtTm")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EventStartTz")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EventTag")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<short?>("EventTagSetFlag")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EventTitleText")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ExpirationDtTm")
                        .HasColumnType("TEXT");

                    b.Property<long>("InquireSecurityCd")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("InstId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("ModifierLongTextId")
                        .HasColumnType("INTEGER");

                    b.Property<short?>("NomenStringFlag")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NormalHigh")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalLow")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalRefRangeTxt")
                        .HasColumnType("TEXT");

                    b.Property<long>("NormalcyCd")
                        .HasColumnType("INTEGER");

                    b.Property<long>("NormalcyMethodCd")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("NoteImportanceBitMap")
                        .HasColumnType("INTEGER");

                    b.Property<long>("OrderActionSequence")
                        .HasColumnType("INTEGER");

                    b.Property<long>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("ParentEventId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("PerformedDtTm")
                        .HasColumnType("TEXT");

                    b.Property<long>("PerformedPrsnlId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PerformedTz")
                        .HasColumnType("INTEGER");

                    b.Property<long>("PersonId")
                        .HasColumnType("INTEGER");

                    b.Property<short>("PublishFlag")
                        .HasColumnType("INTEGER");

                    b.Property<long>("QcReviewCd")
                        .HasColumnType("INTEGER");

                    b.Property<long>("RecordStatusCd")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ReferenceNbr")
                        .HasColumnType("TEXT");

                    b.Property<long?>("ResourceCd")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("ResourceGroupCd")
                        .HasColumnType("INTEGER");

                    b.Property<long>("ResultStatusCd")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("ResultTimeUnitsCd")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("ResultUnitsCd")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ResultVal")
                        .HasColumnType("TEXT");

                    b.Property<string>("SeriesRefNbr")
                        .HasColumnType("TEXT");

                    b.Property<long?>("SourceCd")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("SrcClinsigUpdtDtTm")
                        .HasColumnType("TEXT");

                    b.Property<long>("SrcEventId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SubtableBitMap")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("TaskAssayCd")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("TaskAssayVersionNbr")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ValidFromDtTm")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ValidUntilDtTm")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("VerifiedDtTm")
                        .HasColumnType("TEXT");

                    b.Property<long>("VerifiedPrsnlId")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("xid")
                        .HasColumnName("xmin");

                    b.Property<int?>("ViewLevel")
                        .HasColumnType("INTEGER");

                    b.HasKey("ClinicalEventId");

                    b.HasIndex(new[] { "CeDynamicLabelId", "ValidUntilDtTm" }, "ix_ce_dynamic_label_id_valid_until");

                    b.HasIndex(new[] { "EncntrId", "ClinsigUpdtDtTm" }, "ix_encntr_id_clinsig_updt_dttm");

                    b.HasIndex(new[] { "EncntrId", "EventClassCd" }, "ix_encntr_id_event_class_cd");

                    b.HasIndex(new[] { "EncntrId", "ResultStatusCd" }, "ix_encntr_id_result_status");

                    b.HasIndex(new[] { "EventCd", "EventEndDtTm" }, "ix_event_cd_event_end_dt_tm");

                    b.HasIndex(new[] { "EventId", "ValidUntilDtTm" }, "ix_event_id_validate_until");

                    b.HasIndex(new[] { "OrderId", "ValidFromDtTm" }, "ix_order_id_valid_from");

                    b.HasIndex(new[] { "ParentEventId", "ValidUntilDtTm" }, "ix_parent_event_id_valid_until");

                    b.HasIndex(new[] { "PerformedDtTm", "EventCd" }, "ix_performed_dttm_event_cd");

                    b.HasIndex(new[] { "PersonId", "EventCd", "ClinsigUpdtDtTm", "ValidUntilDtTm" }, "ix_person_id_event_cd_valid_until");

                    b.HasIndex(new[] { "PersonId", "UpdatedDateTime" }, "ix_person_id_updat_dttm");

                    b.HasIndex(new[] { "PersonId", "ValidFromDtTm" }, "ix_person_id_valid_from");

                    b.HasIndex(new[] { "PersonId", "EventCd", "EventEndDtTm", "ValidUntilDtTm" }, "ix_personid_event_cd_event_end_dttm_valid_until");

                    b.HasIndex(new[] { "PersonId", "EventEndDtTm", "ValidUntilDtTm", "EncntrId", "ResultStatusCd", "PerformedPrsnlId" }, "ix_personid_event_end_dttm_valid_encntrid");

                    b.HasIndex(new[] { "ReferenceNbr", "ValidFromDtTm", "ContributorSystemCd" }, "ix_ref_num_validate_dttm_contrib");

                    b.HasIndex(new[] { "SeriesRefNbr" }, "ix_series_ref_nbr");

                    b.HasIndex(new[] { "SrcEventId", "ValidUntilDtTm" }, "ix_src_event_id_valid_until");

                    b.ToTable("ClinicalEvent");
                });

            modelBuilder.Entity("MVVM_play.Models.OrderCatalog", b =>
                {
                    b.Property<long>("CatalogCd")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("AbnReviewInd")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ActiveInd")
                        .HasColumnType("INTEGER");

                    b.Property<long>("ActivitySubtypeCd")
                        .HasColumnType("INTEGER");

                    b.Property<long>("ActivityTypeCd")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AutoCancelInd")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("BillOnlyInd")
                        .HasColumnType("INTEGER");

                    b.Property<long>("CatalogTypeCd")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cki")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<short?>("CommentTemplateFlag")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("CompleteUponOrderInd")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConceptCki")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<long?>("ConsentFormFormatCd")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ConsentFormInd")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("ConsentFormRoutingCd")
                        .HasColumnType("INTEGER");

                    b.Property<short>("ContOrderMethodFlag")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("DcDisplayDays")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DcInteractionDays")
                        .HasColumnType("INTEGER");

                    b.Property<long>("DcpClinCatCd")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DeptDisplayName")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<bool>("DeptDupCheckInd")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<bool>("DisableOrderCommentInd")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("DiscernAutoVerifyFlag")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DosingActIngredCode")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("DosingAllIngredInd")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("DupCheckInd")
                        .HasColumnType("INTEGER");

                    b.Property<long>("EventCd")
                        .HasColumnType("INTEGER");

                    b.Property<long>("FormId")
                        .HasColumnType("INTEGER");

                    b.Property<short?>("FormLevel")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("InstId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("InstRestrictionInd")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ModifiableFlag")
                        .HasColumnType("INTEGER");

                    b.Property<long>("OeFormatId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OpDcDisplayDays")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OpDcInteractionDays")
                        .HasColumnType("INTEGER");

                    b.Property<long>("OrdComTemplateLongTextId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("OrderReviewInd")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderableTypeFlag")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PrepInfoFlag")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PrimaryMnemonic")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<bool>("PrintReqInd")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("PromptInd")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("QuickChartInd")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RefTextMask")
                        .HasColumnType("INTEGER");

                    b.Property<long>("RequisitionFormatCd")
                        .HasColumnType("INTEGER");

                    b.Property<long>("RequisitionRoutingCd")
                        .HasColumnType("INTEGER");

                    b.Property<long>("ResourceRouteCd")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ResourceRouteLvl")
                        .HasColumnType("INTEGER");

                    b.Property<long>("ReviewHierarchyId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ScheduleInd")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SourceVocabIdent")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("SourceVocabMean")
                        .HasMaxLength(12)
                        .HasColumnType("TEXT");

                    b.Property<int>("StopDuration")
                        .HasColumnType("INTEGER");

                    b.Property<long>("StopDurationUnitCd")
                        .HasColumnType("INTEGER");

                    b.Property<long>("StopTypeCd")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TxnIdText")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<long>("UpdtApplctx")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UpdtCnt")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdtDtTm")
                        .HasColumnType("TEXT");

                    b.Property<long>("UpdtId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UpdtTask")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("xid")
                        .HasColumnName("xmin");

                    b.Property<bool>("VettingApprovalFlag")
                        .HasColumnType("INTEGER");

                    b.HasKey("CatalogCd");

                    b.HasIndex(new[] { "PrimaryMnemonic" }, "ix_primary_mnemonic");

                    b.ToTable("OrderCatalog");
                });

            modelBuilder.Entity("MVVM_play.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MVVM_play.Models.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .HasColumnType("TEXT");

                    b.Property<string>("PrimaryAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("SecondaryAddress")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("MVVM_play.Models.UserProfileHx", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PrimaryAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("SecondaryAddress")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserProfilesHx");
                });

            modelBuilder.Entity("MVVM_play.Models.UserProfile", b =>
                {
                    b.HasOne("MVVM_play.Models.User", "User")
                        .WithOne("UserProfile")
                        .HasForeignKey("MVVM_play.Models.UserProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MVVM_play.Models.UserProfileHx", b =>
                {
                    b.HasOne("MVVM_play.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MVVM_play.Models.User", b =>
                {
                    b.Navigation("UserProfile");
                });
#pragma warning restore 612, 618
        }
    }
}
