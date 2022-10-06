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
                optionsBuilder.UseSqlServer("Server=localhost;Database=BreweryDB;Integrated Security=SSPI;");
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

                entity.HasOne(d => d.Brewery)
                    .WithMany(p => p.Brews)
                    .HasForeignKey(d => d.BreweryId)
                    .HasConstraintName("FK__Brew__BreweryId__3E52440B");
            });

            modelBuilder.Entity<Brewery>(entity =>
            {
                entity.ToTable("Brewery");

                entity.Property(e => e.BreweryName).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
