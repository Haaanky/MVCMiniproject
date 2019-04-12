using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MVCMiniproject.Models.Entities
{
    public partial class BeerDBContext : DbContext
    {
        public BeerDBContext()
        {
        }

        public BeerDBContext(DbContextOptions<BeerDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Beer> Beer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BeerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Beer>(entity =>
            {
                entity.HasIndex(e => new { e.Name, e.CompanyName, e.Container })
                    .HasName("UQ__Beer__276B87EAF6850291")
                    .IsUnique();

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Container)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OriginCountry).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("money");
            });
        }
    }
}
