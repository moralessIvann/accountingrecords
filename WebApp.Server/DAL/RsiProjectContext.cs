using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApp.Server.Models;

namespace WebApp.Server.DAL;

public partial class RsiProjectContext : DbContext
{
    public RsiProjectContext()
    {
    }

    public RsiProjectContext(DbContextOptions<RsiProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActivoFijo> ActivoFijos { get; set; }

    public virtual DbSet<Categoria> Categoria { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActivoFijo>(entity =>
        {
            entity.HasKey(e => e.IdActivoFijo).HasName("PK__activoFi__54C168221DFCEF3F");

            entity.ToTable("activoFijo");

            entity.Property(e => e.IdActivoFijo).HasColumnName("idActivoFijo");
            entity.Property(e => e.CodigoRsi)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("codigoRSI");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("marca");
            entity.Property(e => e.Modelo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modelo");
            entity.Property(e => e.NombreActivoFijo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreActivoFijo");
            entity.Property(e => e.NumeroSerie)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("numeroSerie");
            entity.Property(e => e.ValorAdquisicion)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("valorAdquisicion");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.ActivoFijos)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__activoFij__idCat__3F466844");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__categori__8A3D240C7987909E");

            entity.ToTable("categoria");

            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.NombreCategoria)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreCategoria");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
