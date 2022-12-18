using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KazanS5Backend
{
    public partial class Session5Context : DbContext
    {
        public Session5Context()
        {
        }

        public Session5Context(DbContextOptions<Session5Context> options)
            : base(options)
        {
        }

        public virtual DbSet<RockType> RockTypes { get; set; } = null!;
        public virtual DbSet<Well> Wells { get; set; } = null!;
        public virtual DbSet<WellLayer> WellLayers { get; set; } = null!;
        public virtual DbSet<WellType> WellTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=JORDY-DESKTOP\\SQLEXPRESS;user=sa;password=1234567890;database=Session5");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RockType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BackgroundColor).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Well>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.WellName).HasMaxLength(50);

                entity.Property(e => e.WellTypeId).HasColumnName("WellTypeID");

                entity.HasOne(d => d.WellType)
                    .WithMany(p => p.Wells)
                    .HasForeignKey(d => d.WellTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Wells_WellTypes");
            });

            modelBuilder.Entity<WellLayer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RockTypeId).HasColumnName("RockTypeID");

                entity.Property(e => e.WellId).HasColumnName("WellID");

                entity.HasOne(d => d.RockType)
                    .WithMany(p => p.WellLayers)
                    .HasForeignKey(d => d.RockTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WellLayers_RockTypes");

                entity.HasOne(d => d.Well)
                    .WithMany(p => p.WellLayers)
                    .HasForeignKey(d => d.WellId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WellLayers_Wells");
            });

            modelBuilder.Entity<WellType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
