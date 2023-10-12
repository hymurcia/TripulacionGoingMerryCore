using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TripulacionGoingMerry.Models;

public partial class NombreDeTuBaseDeDatosContext : DbContext
{
    public NombreDeTuBaseDeDatosContext()
    {
    }

    public NombreDeTuBaseDeDatosContext(DbContextOptions<NombreDeTuBaseDeDatosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    //public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }

    public virtual DbSet<Tripulant> Tripulants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=NombreDeTuBaseDeDatos;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.EnrollmentId).HasName("PK_dbo.Enrollment");

            entity.ToTable("Enrollment");

            entity.HasIndex(e => e.TripulantId, "IX_TripulantID");

            entity.Property(e => e.EnrollmentId).HasColumnName("EnrollmentID");
            entity.Property(e => e.TripulantId).HasColumnName("TripulantID");

            entity.HasOne(d => d.Tripulant).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.TripulantId)
                .HasConstraintName("FK_dbo.Enrollment_dbo.Tripulant_TripulantID");
        });

        /*modelBuilder.Entity<MigrationHistory>(entity =>
        {
            entity.HasKey(e => new { e.MigrationId, e.ContextKey }).HasName("PK_dbo.__MigrationHistory");

            entity.ToTable("__MigrationHistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ContextKey).HasMaxLength(300);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });
        */
        modelBuilder.Entity<Tripulant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Tripulant");

            entity.ToTable("Tripulant");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EnrollmentDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
