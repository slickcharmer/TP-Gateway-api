using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PHREntityFrame.Entities;

public partial class PatientHealthDbContext : DbContext
{
    public PatientHealthDbContext()
    {
    }

    public PatientHealthDbContext(DbContextOptions<PatientHealthDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PatientAllergy> PatientAllergies { get; set; }

    public virtual DbSet<PatientBasicRecord> PatientBasicRecords { get; set; }

    public virtual DbSet<PatientHealthRecord> PatientHealthRecords { get; set; }

    public virtual DbSet<PatientMedication> PatientMedications { get; set; }

    public virtual DbSet<PatientTest> PatientTests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:yashu-db-server.database.windows.net,1433;Initial Catalog=Patient_Health_DB; User ID=yashu;Password=Yash@123;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PatientAllergy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PatientA__3214EC077C77ECBE");

            entity.ToTable("PatientAllergy");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AppointmentId)
                .HasMaxLength(100)
                .HasColumnName("Appointment_Id");
            entity.Property(e => e.HealthId).HasColumnName("Health_Id");

            entity.HasOne(d => d.Appointment).WithMany(p => p.PatientAllergies)
                .HasForeignKey(d => d.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Fk_PatientAllergy");
        });

        modelBuilder.Entity<PatientBasicRecord>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__PatientB__FD01B523DCBCD2B7");

            entity.ToTable("PatientBasicRecord");

            entity.Property(e => e.AppointmentId)
                .HasMaxLength(100)
                .HasColumnName("Appointment_Id");
            entity.Property(e => e.BloodGroup).HasColumnName("Blood_Group");
            entity.Property(e => e.DateTime).HasColumnType("smalldatetime");
            entity.Property(e => e.HeartRate).HasColumnName("Heart_Rate");
            entity.Property(e => e.NurseId).HasColumnName("Nurse_Id");
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
        });

        modelBuilder.Entity<PatientHealthRecord>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__PatientH__FD01B52394F0B579");

            entity.ToTable("PatientHealthRecord");

            entity.Property(e => e.AppointmentId)
                .HasMaxLength(100)
                .HasColumnName("Appointment_Id");
            entity.Property(e => e.DateTime).HasColumnType("smalldatetime");
            entity.Property(e => e.DoctorId).HasColumnName("Doctor_Id");
            entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
        });

        modelBuilder.Entity<PatientMedication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PatientM__3214EC078E5ADDEC");

            entity.ToTable("PatientMedication");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AppointmentId)
                .HasMaxLength(100)
                .HasColumnName("Appointment_Id");
            entity.Property(e => e.HealthId).HasColumnName("Health_Id");

            entity.HasOne(d => d.Appointment).WithMany(p => p.PatientMedications)
                .HasForeignKey(d => d.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Fk_patientmedication");
        });

        modelBuilder.Entity<PatientTest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PatientT__3214EC079EDCFE1D");

            entity.ToTable("PatientTest");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AppointmentId)
                .HasMaxLength(100)
                .HasColumnName("Appointment_Id");
            entity.Property(e => e.HealthId).HasColumnName("Health_Id");

            entity.HasOne(d => d.Appointment).WithMany(p => p.PatientTests)
                .HasForeignKey(d => d.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Fk_patientTest");
        });
        modelBuilder.HasSequence<int>("SalesOrderNumber", "SalesLT");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
