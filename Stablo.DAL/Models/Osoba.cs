using System;
using System.Collections.Generic;

#nullable disable

namespace Stablo.DAL
{
    public partial class Osoba
    {
        public Osoba()
        {
            Dijetes = new HashSet<Dijete>();
            InverseBioloskaMajka = new HashSet<Osoba>();
            InverseBioloskiOtac = new HashSet<Osoba>();
            ObiteljOsoba1s = new HashSet<Obitelj>();
            ObiteljOsoba2s = new HashSet<Obitelj>();
            OsobaDodatnos = new HashSet<OsobaDodatno>();
            OsobaDogadjajs = new HashSet<OsobaDogadjaj>();
            OsobaDokuments = new HashSet<OsobaDokument>();
            OsobaSlikas = new HashSet<OsobaSlika>();
        }

        public Guid Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string ObiteljskiNadimak { get; set; }
        public string Nadimak { get; set; }
        public Guid? LozaId { get; set; }
        public string Spol { get; set; }
        public Guid? MjestoRodenjaId { get; set; }
        public DateTime? DatumRodenja { get; set; }
        public Guid? DatumRodenjaTocnostId { get; set; }
        public Guid? MjestoSmrtiId { get; set; }
        public DateTime? DatumSmrti { get; set; }
        public Guid? DatumSmrtiTocnostId { get; set; }
        public Guid? BioloskiOtacId { get; set; }
        public Guid? BioloskaMajkaId { get; set; }
        public Guid? OwnerId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public virtual Osoba BioloskaMajka { get; set; }
        public virtual Osoba BioloskiOtac { get; set; }
        public virtual TocnostVremenaLookup DatumRodenjaTocnost { get; set; }
        public virtual TocnostVremenaLookup DatumSmrtiTocnost { get; set; }
        public virtual Loza Loza { get; set; }
        public virtual Lokacija MjestoRodenja { get; set; }
        public virtual Lokacija MjestoSmrti { get; set; }
        public virtual ICollection<Dijete> Dijetes { get; set; }
        public virtual ICollection<Osoba> InverseBioloskaMajka { get; set; }
        public virtual ICollection<Osoba> InverseBioloskiOtac { get; set; }
        public virtual ICollection<Obitelj> ObiteljOsoba1s { get; set; }
        public virtual ICollection<Obitelj> ObiteljOsoba2s { get; set; }
        public virtual ICollection<OsobaDodatno> OsobaDodatnos { get; set; }
        public virtual ICollection<OsobaDogadjaj> OsobaDogadjajs { get; set; }
        public virtual ICollection<OsobaDokument> OsobaDokuments { get; set; }
        public virtual ICollection<OsobaSlika> OsobaSlikas { get; set; }
    }
}
