using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Entities;

public partial class AppointmentServiceDbContext : DbContext
{
    public AppointmentServiceDbContext()
    {
    }

    public AppointmentServiceDbContext(DbContextOptions<AppointmentServiceDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:appointmentservice.database.windows.net,1433;Initial Catalog=AppointmentServiceDb;Persist Security Info=False;User ID=Geff;Password=Geoffrey2001;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("Pk_Appointment");

            entity.ToTable("Appointment", tb => tb.HasTrigger("status3"));

            entity.Property(e => e.AppointmentId)
                .ValueGeneratedNever()
                .HasColumnName("appointment_id");
            entity.Property(e => e.Date)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("date");
            entity.Property(e => e.DoctorId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("doctor_id");
            entity.Property(e => e.NurseId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("nurse_id");
            entity.Property(e => e.PatientId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("patient_id");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
