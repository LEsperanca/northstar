﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NorthStar.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NorthStar.Infrastructure.Migrations
{
    [DbContext(typeof(NorthStarEfCoreDbContext))]
    [Migration("20240316174311_AddUserIdentityId")]
    partial class AddUserIdentityId
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NorthStar.Domain.People.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("IdentityId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("identity_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("name");

                    b.Property<int>("Role")
                        .HasColumnType("integer")
                        .HasColumnName("role");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated");

                    b.HasKey("Id")
                        .HasName("pk_people");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("ix_people_email");

                    b.HasIndex("IdentityId")
                        .IsUnique()
                        .HasDatabaseName("ix_people_identity_id");

                    b.ToTable("people", (string)null);
                });

            modelBuilder.Entity("NorthStar.Domain.Projects.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("begin_date");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)")
                        .HasColumnName("description");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("end_date");

                    b.Property<Guid?>("LeadId")
                        .HasColumnType("uuid")
                        .HasColumnName("lead_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("name");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated");

                    b.HasKey("Id")
                        .HasName("pk_project");

                    b.HasIndex("LeadId")
                        .HasDatabaseName("ix_project_lead_id");

                    b.ToTable("project", (string)null);
                });

            modelBuilder.Entity("NorthStar.Domain.WorkItems.WorkItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("AssigneeId")
                        .HasColumnType("uuid")
                        .HasColumnName("assignee_id");

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("begin_date");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("end_date");

                    b.Property<int>("Priority")
                        .HasColumnType("integer")
                        .HasColumnName("priority");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid")
                        .HasColumnName("project_id");

                    b.Property<Guid>("ReporterId")
                        .HasColumnType("uuid")
                        .HasColumnName("reporter_id");

                    b.Property<int>("Resolution")
                        .HasColumnType("integer")
                        .HasColumnName("resolution");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("summary");

                    b.Property<int>("Type")
                        .HasColumnType("integer")
                        .HasColumnName("type");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated");

                    b.Property<uint>("version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("xid")
                        .HasColumnName("xmin");

                    b.HasKey("Id")
                        .HasName("pk_workitem");

                    b.HasIndex("AssigneeId")
                        .HasDatabaseName("ix_workitem_assignee_id");

                    b.HasIndex("ProjectId")
                        .HasDatabaseName("ix_workitem_project_id");

                    b.HasIndex("ReporterId")
                        .HasDatabaseName("ix_workitem_reporter_id");

                    b.ToTable("workitem", (string)null);
                });

            modelBuilder.Entity("NorthStar.Domain.People.Person", b =>
                {
                    b.OwnsOne("NorthStar.Domain.People.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("PersonId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.HasKey("PersonId");

                            b1.ToTable("people");

                            b1.WithOwner()
                                .HasForeignKey("PersonId")
                                .HasConstraintName("fk_people_people_id");
                        });

                    b.Navigation("Address");
                });

            modelBuilder.Entity("NorthStar.Domain.Projects.Project", b =>
                {
                    b.HasOne("NorthStar.Domain.People.Person", "Lead")
                        .WithMany()
                        .HasForeignKey("LeadId")
                        .HasConstraintName("fk_project_people_lead_id");

                    b.Navigation("Lead");
                });

            modelBuilder.Entity("NorthStar.Domain.WorkItems.WorkItem", b =>
                {
                    b.HasOne("NorthStar.Domain.People.Person", "Assignee")
                        .WithMany()
                        .HasForeignKey("AssigneeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_workitem_people_assignee_id");

                    b.HasOne("NorthStar.Domain.Projects.Project", "Project")
                        .WithMany("WorkItems")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_workitem_project_project_id");

                    b.HasOne("NorthStar.Domain.People.Person", "Reporter")
                        .WithMany()
                        .HasForeignKey("ReporterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_workitem_people_reporter_id");

                    b.Navigation("Assignee");

                    b.Navigation("Project");

                    b.Navigation("Reporter");
                });

            modelBuilder.Entity("NorthStar.Domain.Projects.Project", b =>
                {
                    b.Navigation("WorkItems");
                });
#pragma warning restore 612, 618
        }
    }
}
