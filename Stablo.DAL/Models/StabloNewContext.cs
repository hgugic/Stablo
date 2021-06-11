using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Stablo.DAL;
using Stablo.Repository.Common;

#nullable disable

namespace Stablo.Repository
{
    public partial class StabloNewContext : DbContext, IDbContext
    {
        public StabloNewContext()
        {
        }

        public StabloNewContext(DbContextOptions<StabloNewContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dijete> Dijetes { get; set; }
        public virtual DbSet<Dogadjaj> Dogadjajs { get; set; }
        public virtual DbSet<DogadjajVrstum> DogadjajVrsta { get; set; }
        public virtual DbSet<Dokument> Dokuments { get; set; }
        public virtual DbSet<Lokacija> Lokacijas { get; set; }
        public virtual DbSet<LokacijaDodatno> LokacijaDodatnos { get; set; }
        public virtual DbSet<LokacijaGeografija> LokacijaGeografijas { get; set; }
        public virtual DbSet<Loza> Lozas { get; set; }
        public virtual DbSet<Obitelj> Obiteljs { get; set; }
        public virtual DbSet<ObiteljDodatno> ObiteljDodatnos { get; set; }
        public virtual DbSet<Osoba> Osobas { get; set; }
        public virtual DbSet<OsobaDodatno> OsobaDodatnos { get; set; }
        public virtual DbSet<OsobaDogadjaj> OsobaDogadjajs { get; set; }
        public virtual DbSet<OsobaDokument> OsobaDokuments { get; set; }
        public virtual DbSet<OsobaSlika> OsobaSlikas { get; set; }
        public virtual DbSet<Slika> Slikas { get; set; }
        public virtual DbSet<TocnostVremenaLookup> TocnostVremenaLookups { get; set; }
        public virtual DbSet<VrstaObiteljiLookup> VrstaObiteljiLookups { get; set; }

        public DbContext GetContext()
        {
            return this;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=StabloNew;Username=postgres;Password=postgresql");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("citext")
                .HasPostgresExtension("postgis")
                .HasAnnotation("Relational:Collation", "Croatian_Croatia.1250");

            modelBuilder.Entity<Dijete>(entity =>
            {
                entity.ToTable("Dijete");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Napomena).HasColumnType("citext");

                entity.Property(e => e.Opis).HasColumnType("citext");

                entity.HasOne(d => d.DijeteNavigation)
                    .WithMany(p => p.Dijetes)
                    .HasForeignKey(d => d.DijeteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dijete_Osoba");

                entity.HasOne(d => d.Obitelj)
                    .WithMany(p => p.Dijetes)
                    .HasForeignKey(d => d.ObiteljId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dijete_Obitelj");
            });

            modelBuilder.Entity<Dogadjaj>(entity =>
            {
                entity.ToTable("Dogadjaj");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Napomena).HasColumnType("citext");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasColumnType("citext");

                entity.Property(e => e.Opis).HasColumnType("citext");

                entity.HasOne(d => d.DatumTocnost)
                    .WithMany(p => p.Dogadjajs)
                    .HasForeignKey(d => d.DatumTocnostId)
                    .HasConstraintName("FK_Dogadjaj_DatumTocnostLookup");

                entity.HasOne(d => d.DogadjajVrsta)
                    .WithMany(p => p.Dogadjajs)
                    .HasForeignKey(d => d.DogadjajVrstaId)
                    .HasConstraintName("FK_Dogadjaj_DogadjajVrsta");

                entity.HasOne(d => d.Lokacija)
                    .WithMany(p => p.Dogadjajs)
                    .HasForeignKey(d => d.LokacijaId)
                    .HasConstraintName("FK_Dogadjaj_Lokacija");
            });

            modelBuilder.Entity<DogadjajVrstum>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Napomena).HasColumnType("citext");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasColumnType("citext");

                entity.Property(e => e.Opis).HasColumnType("citext");
            });

            modelBuilder.Entity<Dokument>(entity =>
            {
                entity.ToTable("Dokument");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FilePath)
                    .IsRequired()
                    .HasColumnType("citext");

                entity.Property(e => e.Naziv).HasColumnType("citext");

                entity.Property(e => e.Opis).HasColumnType("citext");

                entity.HasOne(d => d.DatumTocnost)
                    .WithMany(p => p.Dokuments)
                    .HasForeignKey(d => d.DatumTocnostId)
                    .HasConstraintName("FK_Dokument_DatumTocnost");

                entity.HasOne(d => d.Lokacija)
                    .WithMany(p => p.Dokuments)
                    .HasForeignKey(d => d.LokacijaId)
                    .HasConstraintName("FK_Dokument_Lokacija");
            });

            modelBuilder.Entity<Lokacija>(entity =>
            {
                entity.ToTable("Lokacija");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Mjesto).HasColumnType("citext");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasColumnType("citext");

                entity.Property(e => e.Opis).HasColumnType("citext");
            });

            modelBuilder.Entity<LokacijaDodatno>(entity =>
            {
                entity.ToTable("LokacijaDodatno");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NazivPolja)
                    .IsRequired()
                    .HasColumnType("citext");

                entity.Property(e => e.VrijednostPolja)
                    .IsRequired()
                    .HasColumnType("citext");

                entity.HasOne(d => d.Lokacija)
                    .WithMany(p => p.LokacijaDodatnos)
                    .HasForeignKey(d => d.LokacijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LokacijaDodatno_Lokacija");
            });

            modelBuilder.Entity<LokacijaGeografija>(entity =>
            {
                entity.ToTable("LokacijaGeografija");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Geografija)
                    .IsRequired()
                    .HasColumnType("citext");

                entity.Property(e => e.Opis).HasColumnType("citext");

                entity.HasOne(d => d.Lokacija)
                    .WithMany(p => p.LokacijaGeografijas)
                    .HasForeignKey(d => d.LokacijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LokacijaGeografija_Lokacija");
            });

            modelBuilder.Entity<Loza>(entity =>
            {
                entity.ToTable("Loza");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Naziv).HasColumnType("citext");

                entity.Property(e => e.Opis).HasColumnType("citext");
            });

            modelBuilder.Entity<Obitelj>(entity =>
            {
                entity.ToTable("Obitelj");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Naziv1).HasColumnType("citext");

                entity.Property(e => e.Naziv2).HasColumnType("citext");

                entity.Property(e => e.Opis1).HasColumnType("citext");

                entity.Property(e => e.Opis2).HasColumnType("citext");

                entity.HasOne(d => d.Osoba1)
                    .WithMany(p => p.ObiteljOsoba1s)
                    .HasForeignKey(d => d.Osoba1Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Obitelj_Osoba1");

                entity.HasOne(d => d.Osoba2)
                    .WithMany(p => p.ObiteljOsoba2s)
                    .HasForeignKey(d => d.Osoba2Id)
                    .HasConstraintName("FK_Obitelj_Osoba2");

                entity.HasOne(d => d.Vrsta)
                    .WithMany(p => p.Obiteljs)
                    .HasForeignKey(d => d.VrstaId)
                    .HasConstraintName("FK_Obitelj_VrstaObitelji");
            });

            modelBuilder.Entity<ObiteljDodatno>(entity =>
            {
                entity.ToTable("ObiteljDodatno");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NazivPolja)
                    .IsRequired()
                    .HasColumnType("citext");

                entity.Property(e => e.VrijednostPolja)
                    .IsRequired()
                    .HasColumnType("citext");

                entity.HasOne(d => d.Obitelj)
                    .WithMany(p => p.ObiteljDodatnos)
                    .HasForeignKey(d => d.ObiteljId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ObiteljDodatno_Obitelj");
            });

            modelBuilder.Entity<Osoba>(entity =>
            {
                entity.ToTable("Osoba");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasColumnType("citext");

                entity.Property(e => e.Nadimak).HasColumnType("citext");

                entity.Property(e => e.ObiteljskiNadimak).HasColumnType("citext");

                entity.Property(e => e.Prezime).HasColumnType("citext");

                entity.Property(e => e.Spol).HasMaxLength(8);

                entity.HasOne(d => d.BioloskaMajka)
                    .WithMany(p => p.InverseBioloskaMajka)
                    .HasForeignKey(d => d.BioloskaMajkaId)
                    .HasConstraintName("FK_Osoba_BioloskaMajka");

                entity.HasOne(d => d.BioloskiOtac)
                    .WithMany(p => p.InverseBioloskiOtac)
                    .HasForeignKey(d => d.BioloskiOtacId)
                    .HasConstraintName("FK_Osoba_BioloskiOtac");

                entity.HasOne(d => d.DatumRodenjaTocnost)
                    .WithMany(p => p.OsobaDatumRodenjaTocnosts)
                    .HasForeignKey(d => d.DatumRodenjaTocnostId)
                    .HasConstraintName("FK_Slike_DatumRodenjaTocnost");

                entity.HasOne(d => d.DatumSmrtiTocnost)
                    .WithMany(p => p.OsobaDatumSmrtiTocnosts)
                    .HasForeignKey(d => d.DatumSmrtiTocnostId)
                    .HasConstraintName("FK_Slike_DatumSmrtiTocnost");

                entity.HasOne(d => d.Loza)
                    .WithMany(p => p.Osobas)
                    .HasForeignKey(d => d.LozaId)
                    .HasConstraintName("FK_Slike_Loza");

                entity.HasOne(d => d.MjestoRodenja)
                    .WithMany(p => p.OsobaMjestoRodenjas)
                    .HasForeignKey(d => d.MjestoRodenjaId)
                    .HasConstraintName("FK_Osoba_MjestoRodenja");

                entity.HasOne(d => d.MjestoSmrti)
                    .WithMany(p => p.OsobaMjestoSmrtis)
                    .HasForeignKey(d => d.MjestoSmrtiId)
                    .HasConstraintName("FK_Osoba_MjestoSmrti");
            });

            modelBuilder.Entity<OsobaDodatno>(entity =>
            {
                entity.ToTable("OsobaDodatno");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NazivPolja)
                    .IsRequired()
                    .HasColumnType("citext");

                entity.Property(e => e.VrijednostPolja)
                    .IsRequired()
                    .HasColumnType("citext");

                entity.HasOne(d => d.Osoba)
                    .WithMany(p => p.OsobaDodatnos)
                    .HasForeignKey(d => d.OsobaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OsobaDodatno_Osoba");
            });

            modelBuilder.Entity<OsobaDogadjaj>(entity =>
            {
                entity.ToTable("OsobaDogadjaj");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Napomena).HasColumnType("citext");

                entity.Property(e => e.Naziv).HasColumnType("citext");

                entity.Property(e => e.Opis).HasColumnType("citext");

                entity.Property(e => e.Uloga).HasColumnType("citext");

                entity.HasOne(d => d.Dogadjaj)
                    .WithMany(p => p.OsobaDogadjajs)
                    .HasForeignKey(d => d.DogadjajId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OsobaDogadjaj_Dogadjaj");

                entity.HasOne(d => d.Osoba)
                    .WithMany(p => p.OsobaDogadjajs)
                    .HasForeignKey(d => d.OsobaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OsobaDogadjaj_Osoba");
            });

            modelBuilder.Entity<OsobaDokument>(entity =>
            {
                entity.ToTable("OsobaDokument");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Napomena).HasColumnType("citext");

                entity.Property(e => e.Opis).HasColumnType("citext");

                entity.HasOne(d => d.Dokument)
                    .WithMany(p => p.OsobaDokuments)
                    .HasForeignKey(d => d.DokumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OsobaDokument_Dokument");

                entity.HasOne(d => d.OsobaDogadjaj)
                    .WithMany(p => p.OsobaDokuments)
                    .HasForeignKey(d => d.OsobaDogadjajId)
                    .HasConstraintName("FK_OsobaSlika_OsobaDogadjaj");

                entity.HasOne(d => d.Osoba)
                    .WithMany(p => p.OsobaDokuments)
                    .HasForeignKey(d => d.OsobaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OsobaDokument_Osoba");
            });

            modelBuilder.Entity<OsobaSlika>(entity =>
            {
                entity.ToTable("OsobaSlika");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Napomena).HasColumnType("citext");

                entity.Property(e => e.Opis).HasColumnType("citext");

                entity.HasOne(d => d.OsobaDogadjaj)
                    .WithMany(p => p.OsobaSlikas)
                    .HasForeignKey(d => d.OsobaDogadjajId)
                    .HasConstraintName("FK_OsobaSlika_OsobaDogadjaj");

                entity.HasOne(d => d.Osoba)
                    .WithMany(p => p.OsobaSlikas)
                    .HasForeignKey(d => d.OsobaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OsobaSlika_Osoba");

                entity.HasOne(d => d.Slika)
                    .WithMany(p => p.OsobaSlikas)
                    .HasForeignKey(d => d.SlikaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OsobaSlika_Slika");
            });

            modelBuilder.Entity<Slika>(entity =>
            {
                entity.ToTable("Slika");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Album).HasColumnType("citext");

                entity.Property(e => e.FilePath)
                    .IsRequired()
                    .HasColumnType("citext");

                entity.Property(e => e.Naziv).HasColumnType("citext");

                entity.Property(e => e.Opis).HasColumnType("citext");

                entity.HasOne(d => d.DatumTocnost)
                    .WithMany(p => p.Slikas)
                    .HasForeignKey(d => d.DatumTocnostId)
                    .HasConstraintName("FK_Slike_DatumTocnost");

                entity.HasOne(d => d.Lokacija)
                    .WithMany(p => p.Slikas)
                    .HasForeignKey(d => d.LokacijaId)
                    .HasConstraintName("FK_Slike_Lokacija");
            });

            modelBuilder.Entity<TocnostVremenaLookup>(entity =>
            {
                entity.ToTable("TocnostVremenaLookup");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Kratica)
                    .IsRequired()
                    .HasColumnType("citext");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasColumnType("citext");

                entity.Property(e => e.Opis)
                    .IsRequired()
                    .HasColumnType("citext");
            });

            modelBuilder.Entity<VrstaObiteljiLookup>(entity =>
            {
                entity.ToTable("VrstaObiteljiLookup");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Kratica)
                    .IsRequired()
                    .HasColumnType("citext");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasColumnType("citext");

                entity.Property(e => e.Opis).HasColumnType("citext");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
