using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TPQR_Session1_01082022_BlazorWeb
{
    public partial class Session1Context : DbContext
    {
        public Session1Context()
        {
        }

        public Session1Context(DbContextOptions<Session1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<ResourceAllocation> ResourceAllocations { get; set; }
        public virtual DbSet<ResourceType> ResourceTypes { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=JORDY-DESKTOP\\SQLEXPRESS;Trusted_Connection=True;database=Session1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(e => e.ResId);

                entity.ToTable("Resource");

                entity.Property(e => e.ResId).HasColumnName("resId");

                entity.Property(e => e.RemainingQuantity).HasColumnName("remainingQuantity");

                entity.Property(e => e.ResName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("resName");

                entity.Property(e => e.ResTypeIdFk).HasColumnName("resTypeIdFK");

                entity.HasOne(d => d.ResTypeIdFkNavigation)
                    .WithMany(p => p.Resources)
                    .HasForeignKey(d => d.ResTypeIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Resource_Resource_Type");
            });

            modelBuilder.Entity<ResourceAllocation>(entity =>
            {
                entity.HasKey(e => e.AllocId);

                entity.ToTable("Resource_Allocation");

                entity.Property(e => e.AllocId).HasColumnName("allocId");

                entity.Property(e => e.ResIdFk).HasColumnName("resIdFK");

                entity.Property(e => e.SkillIdFk).HasColumnName("skillIdFK");

                entity.HasOne(d => d.ResIdFkNavigation)
                    .WithMany(p => p.ResourceAllocations)
                    .HasForeignKey(d => d.ResIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Resource_Allocation_Resource");

                entity.HasOne(d => d.SkillIdFkNavigation)
                    .WithMany(p => p.ResourceAllocations)
                    .HasForeignKey(d => d.SkillIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Resource_Allocation_Skill1");
            });

            modelBuilder.Entity<ResourceType>(entity =>
            {
                entity.HasKey(e => e.ResTypeId);

                entity.ToTable("Resource_Type");

                entity.Property(e => e.ResTypeId).HasColumnName("resTypeId");

                entity.Property(e => e.ResTypeName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("resTypeName");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.ToTable("Skill");

                entity.Property(e => e.SkillId).HasColumnName("skillId");

                entity.Property(e => e.SkillName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("skillName");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userId");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userName");

                entity.Property(e => e.UserPw)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userPw");

                entity.Property(e => e.UserTypeIdFk).HasColumnName("userTypeIdFK");

                entity.HasOne(d => d.UserTypeIdFkNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserTypeIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_User_Type");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.ToTable("User_Type");

                entity.Property(e => e.UserTypeId).HasColumnName("userTypeId");

                entity.Property(e => e.UserTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userTypeName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
