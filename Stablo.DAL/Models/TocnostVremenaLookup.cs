using System;
using System.Collections.Generic;

#nullable disable

namespace Stablo.DAL
{
    public partial class TocnostVremenaLookup
    {
        public TocnostVremenaLookup()
        {
            Dogadjajs = new HashSet<Dogadjaj>();
            Dokuments = new HashSet<Dokument>();
            OsobaDatumRodenjaTocnosts = new HashSet<Osoba>();
            OsobaDatumSmrtiTocnosts = new HashSet<Osoba>();
            Slikas = new HashSet<Slika>();
        }

        public Guid Id { get; set; }
        public string Opis { get; set; }
        public string Naziv { get; set; }
        public string Kratica { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public virtual ICollection<Dogadjaj> Dogadjajs { get; set; }
        public virtual ICollection<Dokument> Dokuments { get; set; }
        public virtual ICollection<Osoba> OsobaDatumRodenjaTocnosts { get; set; }
        public virtual ICollection<Osoba> OsobaDatumSmrtiTocnosts { get; set; }
        public virtual ICollection<Slika> Slikas { get; set; }
    }
}
