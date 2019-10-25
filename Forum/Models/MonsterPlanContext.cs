using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Forum.Models
{
    public partial class MonsterPlanContext : DbContext
    {
        public MonsterPlanContext()
        {
        }

        public MonsterPlanContext(DbContextOptions<MonsterPlanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCategories> TblCategories { get; set; }
        public virtual DbSet<TblPosts> TblPosts { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MonsterPlan;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCategories>(entity =>
            {
                entity.HasKey(e => e.CaId);

                entity.ToTable("Tbl_Categories");

                entity.HasIndex(e => e.CaName)
                    .HasName("UQ__Tbl_Cate__A786B716E59EF8A1")
                    .IsUnique();

                entity.Property(e => e.CaId).HasColumnName("Ca_ID");

                entity.Property(e => e.CaName)
                    .IsRequired()
                    .HasColumnName("Ca_Name")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<TblPosts>(entity =>
            {
                entity.HasKey(e => e.PoId);

                entity.ToTable("Tbl_Posts");

                entity.Property(e => e.PoId).HasColumnName("Po_ID");

                entity.Property(e => e.PoAuthor).HasColumnName("Po_Author");

                entity.Property(e => e.PoCategory).HasColumnName("Po_Category");

                entity.Property(e => e.PoContent)
                    .IsRequired()
                    .HasColumnName("Po_Content")
                    .HasMaxLength(1000);

                entity.Property(e => e.PoDate)
                    .HasColumnName("Po_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PoName)
                    .IsRequired()
                    .HasColumnName("Po_Name")
                    .HasMaxLength(20);

                entity.HasOne(d => d.PoAuthorNavigation)
                    .WithMany(p => p.TblPosts)
                    .HasForeignKey(d => d.PoAuthor)
                    .HasConstraintName("FK_Tbl_Us");

                entity.HasOne(d => d.PoCategoryNavigation)
                    .WithMany(p => p.TblPosts)
                    .HasForeignKey(d => d.PoCategory)
                    .HasConstraintName("FK_Tbl_Po");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UsId);

                entity.ToTable("Tbl_User");

                entity.HasIndex(e => e.UsEmail)
                    .HasName("UQ__Tbl_User__C342A07AACC1A113")
                    .IsUnique();

                entity.HasIndex(e => e.UsName)
                    .HasName("UQ__Tbl_User__065679CCF6FB3019")
                    .IsUnique();

                entity.Property(e => e.UsId).HasColumnName("Us_ID");

                entity.Property(e => e.UsEmail)
                    .IsRequired()
                    .HasColumnName("Us_Email")
                    .HasMaxLength(40);

                entity.Property(e => e.UsHash)
                    .IsRequired()
                    .HasColumnName("US_Hash")
                    .HasMaxLength(64);

                entity.Property(e => e.UsName)
                    .IsRequired()
                    .HasColumnName("Us_Name")
                    .HasMaxLength(20);

                entity.Property(e => e.UsSalt)
                    .IsRequired()
                    .HasColumnName("US_Salt")
                    .HasMaxLength(64);
            });
        }
    }
}
