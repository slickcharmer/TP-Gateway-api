using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PIDataLogic.Entities;

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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:patientinfoservice.database.windows.net,1433;Initial Catalog=PatientInfoServiceDb;Persist Security Info=False;User ID=Prasanna;Password=Admin123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patientinfo>(entity =>
        {
            entity.HasKey(e => e.PatId).HasName("PK__Patienti__B0CC4188D73A8C42");

            entity.ToTable("Patientinfo", "PIS");

            entity.Property(e => e.PatId)
                .ValueGeneratedNever()
                .HasColumnName("Pat_id");
            entity.Property(e => e.AdressLine)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("adress_line");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.City)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Created)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("created");
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
