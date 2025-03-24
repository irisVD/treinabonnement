using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace TreinAbo.Persistence;

public partial class TreinabonnementenContext : DbContext
{
    public TreinabonnementenContext()
    {
    }

    public TreinabonnementenContext(DbContextOptions<TreinabonnementenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Abonnement> Abonnementen { get; set; }

    public virtual DbSet<Klant> Klanten { get; set; }

    public virtual DbSet<Station> Stations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;port=3306;database=treinabonnementen;user=root;password=koalabeer", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.22-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Abonnement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Abonnementen");

            entity.HasIndex(e => e.Id, "idAbonnementen_UNIQUE").IsUnique();

            entity.HasIndex(e => e.IdKlant, "idKlant_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdKlant).HasColumnName("idKlant");
            entity.Property(e => e.Klasse).HasColumnName("klasse");
            entity.Property(e => e.EindDatum)
                .HasColumnType("datetime")
                .HasColumnName("periodeGeldig");
            entity.Property(e => e.StartDatum)
                .HasColumnType("datetime")
                .HasColumnName("startDatum");

            entity.HasOne(d => d.Klant).WithMany(p => p.Abonnementen)
                .HasForeignKey(d => d.IdKlant)
                .HasConstraintName("idKlant");

            entity.HasMany(d => d.Stations).WithMany(p => p.Abonnementen)
                .UsingEntity<Dictionary<string, object>>(
                    "AbonnementenStations",
                    r => r.HasOne<Station>().WithMany()
                        .HasForeignKey("IdStation")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_idStation"),
                    l => l.HasOne<Abonnement>().WithMany()
                        .HasForeignKey("IdAbonnement")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_idAbonnement"),
                    j =>
                    {
                        j.HasKey("IdAbonnement", "IdStation")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("AbonnementenStations");
                        j.HasIndex(new[] { "IdStation" }, "idStation_idx");
                        j.IndexerProperty<int>("IdAbonnement").HasColumnName("idAbonnement");
                        j.IndexerProperty<int>("IdStation").HasColumnName("idStation");
                    });
        });

        modelBuilder.Entity<Klant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Klanten");

            entity.HasIndex(e => e.Email, "Emailadres_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Id, "idKlanten_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .HasColumnName("email");
            entity.Property(e => e.Naam)
                .HasMaxLength(45)
                .HasColumnName("naam");
            entity.Property(e => e.Voornaam)
                .HasMaxLength(45)
                .HasColumnName("voornaam");
        });

        modelBuilder.Entity<Station>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Naam)
                .HasMaxLength(45)
                .HasColumnName("naam");
            entity.Property(e => e.VerwarmdeWachtruimte)
                .HasColumnType("blob")
                .HasConversion(v => v ? new byte[] { 1 } : new byte[] { 0 }, v => v[0] == 1)
                .HasColumnName("verwarmdeWachtruimte");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
