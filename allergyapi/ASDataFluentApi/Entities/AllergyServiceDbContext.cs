using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataFluentApi.Entities;

public partial class AllergyServiceDbContext : DbContext
{
    public AllergyServiceDbContext()
    {
    }

    public AllergyServiceDbContext(DbContextOptions<AllergyServiceDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Allergy> Allergies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:allergyservice.database.windows.net,1433;Initial Catalog=AllergyServiceDb;Persist Security Info=False;User ID=Rizwan;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Allergy>(entity =>
        {
            entity.ToTable("Allergy");

            entity.Property(e => e.AllergyId)
                .ValueGeneratedNever()
                .HasColumnName("Allergy_Id");
            entity.Property(e => e.AllergyName)
                .IsUnicode(false)
                .HasColumnName("Allergy_Name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
