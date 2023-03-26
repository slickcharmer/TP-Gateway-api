using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AuditFluentApi.Entites;

public partial class AuditServiceContext : DbContext
{
    public AuditServiceContext()
    {
    }

    public AuditServiceContext(DbContextOptions<AuditServiceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Audit> Audits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:physicianavailabilityservice.database.windows.net,1433;Initial Catalog=audit_service;Persist Security Info=False;User ID=Srinu;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Audit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__audit__3214EC07F9CC5BFE");

            entity.ToTable("audit");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.AppointmentId)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Conclusion)
                .IsUnicode(false)
                .HasColumnName("conclusion");
            entity.Property(e => e.DateTime).IsUnicode(false);
            entity.Property(e => e.DoctorId)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Drug)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("drug");
            entity.Property(e => e.HealthId)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.PatientId)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Result)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("result");
            entity.Property(e => e.Test)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("test");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
