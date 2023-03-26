using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PatientFluentApi.Entities;

public partial class PhysicianAvailabilityServiceDbContext : DbContext
{
    public PhysicianAvailabilityServiceDbContext()
    {
    }

    public PhysicianAvailabilityServiceDbContext(DbContextOptions<PhysicianAvailabilityServiceDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PatientLogin> PatientLogins { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:physicianavailabilityservice.database.windows.net,1433;Initial Catalog=PhysicianAvailabilityServiceDb;Persist Security Info=False;User ID=Srinu;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PatientLogin>(entity =>
        {
            entity.HasKey(e => e.LoginId).HasName("PK__patient___1F5EF4CFD3C0989D");

            entity.ToTable("patient_login");

            entity.HasIndex(e => e.Email, "UQ_email").IsUnique();

            entity.Property(e => e.LoginId)
                .HasMaxLength(38)
                .IsUnicode(false)
                .HasColumnName("loginId");
            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
