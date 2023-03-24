using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataLogic.Entities;

public partial class PatientInfoServiceDbContext : DbContext
{
    public PatientInfoServiceDbContext()
    {
    }

    public PatientInfoServiceDbContext(DbContextOptions<PatientInfoServiceDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Patientinfo> Patientinfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=tcp:patientinfoservice.database.windows.net,1433;Initial Catalog=PatientInfoServiceDb; User ID=Prasanna;Password=Admin123;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patientinfo>(entity =>
        {
            entity.HasKey(e => e.PatId).HasName("PK__Patienti__B0CC418803C25EA3");

            entity.ToTable("Patientinfo", "PIS");

            entity.Property(e => e.PatId)
                .ValueGeneratedNever()
                .HasColumnName("Pat_id");
            entity.Property(e => e.Adress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("adress");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Country)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Fullname)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("fullname");
            entity.Property(e => e.Gender)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Pasword)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pasword");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.State)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
