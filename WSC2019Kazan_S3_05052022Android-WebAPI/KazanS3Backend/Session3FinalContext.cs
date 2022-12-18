using Microsoft.EntityFrameworkCore;

namespace KazanS3Backend
{
    public partial class Session3FinalContext : DbContext
    {
        public Session3FinalContext()
        {
        }

        public Session3FinalContext(DbContextOptions<Session3FinalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asset> Assets { get; set; } = null!;
        public virtual DbSet<AssetOdometer> AssetOdometers { get; set; } = null!;
        public virtual DbSet<PmscheduleModel> PmscheduleModels { get; set; } = null!;
        public virtual DbSet<PmscheduleType> PmscheduleTypes { get; set; } = null!;
        public virtual DbSet<Pmtask> Pmtasks { get; set; } = null!;
        public virtual DbSet<Task> Tasks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=JORDY-DESKTOP\\SQLEXPRESS;user=sa;password=1234567890;database=Session3Final");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asset>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AssetGroupId).HasColumnName("AssetGroupID");

                entity.Property(e => e.AssetName).HasMaxLength(150);

                entity.Property(e => e.AssetSn)
                    .HasMaxLength(20)
                    .HasColumnName("AssetSN");

                entity.Property(e => e.DepartmentLocationId).HasColumnName("DepartmentLocationID");

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.WarrantyDate).HasColumnType("date");
            });

            modelBuilder.Entity<AssetOdometer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AssetId).HasColumnName("AssetID");

                entity.Property(e => e.ReadDate).HasColumnType("date");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.AssetOdometers)
                    .HasForeignKey(d => d.AssetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AssetOdometers_Assets");
            });

            modelBuilder.Entity<PmscheduleModel>(entity =>
            {
                entity.ToTable("PMScheduleModels");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PmscheduleTypeId).HasColumnName("PMScheduleTypeID");

                entity.HasOne(d => d.PmscheduleType)
                    .WithMany(p => p.PmscheduleModels)
                    .HasForeignKey(d => d.PmscheduleTypeId)
                    .HasConstraintName("FK_PMScheduleModels_PMScheduleTypes");
            });

            modelBuilder.Entity<PmscheduleType>(entity =>
            {
                entity.ToTable("PMScheduleTypes");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Pmtask>(entity =>
            {
                entity.ToTable("PMTasks");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AssetId).HasColumnName("AssetID");

                entity.Property(e => e.PmscheduleTypeId).HasColumnName("PMScheduleTypeID");

                entity.Property(e => e.ScheduleDate).HasColumnType("date");

                entity.Property(e => e.TaskId).HasColumnName("TaskID");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.Pmtasks)
                    .HasForeignKey(d => d.AssetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PMTasks_Assets");

                entity.HasOne(d => d.PmscheduleType)
                    .WithMany(p => p.Pmtasks)
                    .HasForeignKey(d => d.PmscheduleTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PMTasks_PMScheduleTypes");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Pmtasks)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PMTasks_Tasks");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
