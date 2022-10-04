using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BreweryAPI
{
    public partial class BreweryDBContext : DbContext
    {
        public BreweryDBContext()
        {
        }

        public BreweryDBContext(DbContextOptions<BreweryDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brew> Brews { get; set; } = null!;
        public virtual DbSet<Brewery> Breweries { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=Waldo;Initial Catalog=BreweryDB;Integrated Security=SSPI");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brew>(entity =>
            {
                entity.ToTable("Brew");

                entity.Property(e => e.Abv).HasColumnName("ABV");

                entity.Property(e => e.BrewName).HasMaxLength(50);

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(100);
            });

            modelBuilder.Entity<Brewery>(entity =>
            {
                entity.ToTable("Brewery");

                entity.Property(e => e.BreweryName).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.HasOne(d => d.Brew)
                    .WithMany(p => p.Breweries)
                    .HasForeignKey(d => d.BrewId)
                    .HasConstraintName("FK__Brewery__BrewId__398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
