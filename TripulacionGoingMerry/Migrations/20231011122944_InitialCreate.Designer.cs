﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TripulacionGoingMerry.Models;

#nullable disable

namespace TripulacionGoingMerry.Migrations
{
    [DbContext(typeof(NombreDeTuBaseDeDatosContext))]
    [Migration("20231011122944_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TripulacionGoingMerry.Models.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EnrollmentID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnrollmentId"));

                    b.Property<int>("TripulantId")
                        .HasColumnType("int")
                        .HasColumnName("TripulantID");

                    b.HasKey("EnrollmentId")
                        .HasName("PK_dbo.Enrollment");

                    b.HasIndex(new[] { "TripulantId" }, "IX_TripulantID");

                    b.ToTable("Enrollment", (string)null);
                });

            modelBuilder.Entity("TripulacionGoingMerry.Models.MigrationHistory", b =>
                {
                    b.Property<string>("MigrationId")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("ContextKey")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<byte[]>("Model")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ProductVersion")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("MigrationId", "ContextKey")
                        .HasName("PK_dbo.__MigrationHistory");

                    b.ToTable("__MigrationHistory", (string)null);
                });

            modelBuilder.Entity("TripulacionGoingMerry.Models.Tripulant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_dbo.Tripulant");

                    b.ToTable("Tripulant", (string)null);
                });

            modelBuilder.Entity("TripulacionGoingMerry.Models.Enrollment", b =>
                {
                    b.HasOne("TripulacionGoingMerry.Models.Tripulant", "Tripulant")
                        .WithMany("Enrollments")
                        .HasForeignKey("TripulantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_dbo.Enrollment_dbo.Tripulant_TripulantID");

                    b.Navigation("Tripulant");
                });

            modelBuilder.Entity("TripulacionGoingMerry.Models.Tripulant", b =>
                {
                    b.Navigation("Enrollments");
                });
#pragma warning restore 612, 618
        }
    }
}
