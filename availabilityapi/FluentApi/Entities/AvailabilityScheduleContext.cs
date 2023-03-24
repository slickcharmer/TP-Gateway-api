
using Microsoft.EntityFrameworkCore;


namespace FluentApi.Entities;

public partial class AvailabilityScheduleContext : DbContext
{
    public AvailabilityScheduleContext()
    {
    }

    public AvailabilityScheduleContext(DbContextOptions<AvailabilityScheduleContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
     => optionsBuilder.UseSqlServer("Server=doctor-availability-server.database.windows.net,1433;Initial Catalog=AvailabilitySchedule;Persist Security Info=False;User ID=Srinu;Password=Doctor@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");


    public virtual DbSet<DoctorSchedule> DoctorSchedules { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DoctorSchedule>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("PK__doctor_s__E5AB9877AA5DE297");

            entity.ToTable("doctor_schedule");

            entity.Property(e => e.DoctorId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("Doctor_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
