using System;
using System.Collections.Generic;

#nullable disable

namespace Stablo.DAL
{
    public partial class Lokacija
    {
        public Lokacija()
        {
            Dogadjajs = new HashSet<Dogadjaj>();
            Dokuments = new HashSet<Dokument>();
            LokacijaDodatnos = new HashSet<LokacijaDodatno>();
            LokacijaGeografijas = new HashSet<LokacijaGeografija>();
            OsobaMjestoRodenjas = new HashSet<Osoba>();
            OsobaMjestoSmrtis = new HashSet<Osoba>();
            Slikas = new HashSet<Slika>();
        }

        public Guid Id { get; set; }
        public string Naziv { get; set; }
        public string Mjesto { get; set; }
        public string Opis { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public virtual ICollection<Dogadjaj> Dogadjajs { get; set; }
        public virtual ICollection<Dokument> Dokuments { get; set; }
        public virtual ICollection<LokacijaDodatno> LokacijaDodatnos { get; set; }
        public virtual ICollection<LokacijaGeografija> LokacijaGeografijas { get; set; }
        public virtual ICollection<Osoba> OsobaMjestoRodenjas { get; set; }
        public virtual ICollection<Osoba> OsobaMjestoSmrtis { get; set; }
        public virtual ICollection<Slika> Slikas { get; set; }
    }
}
