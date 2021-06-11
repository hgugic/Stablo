using System;
using System.Collections.Generic;

#nullable disable

namespace Stablo.DAL
{
    public partial class Obitelj
    {
        public Obitelj()
        {
            Dijetes = new HashSet<Dijete>();
            ObiteljDodatnos = new HashSet<ObiteljDodatno>();
        }

        public Guid Id { get; set; }
        public Guid? VrstaId { get; set; }
        public DateTime? Pocetak { get; set; }
        public DateTime? Zavrsetak { get; set; }
        public Guid Osoba1Id { get; set; }
        public string Naziv1 { get; set; }
        public string Opis1 { get; set; }
        public Guid? Osoba2Id { get; set; }
        public string Naziv2 { get; set; }
        public string Opis2 { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public virtual Osoba Osoba1 { get; set; }
        public virtual Osoba Osoba2 { get; set; }
        public virtual VrstaObiteljiLookup Vrsta { get; set; }
        public virtual ICollection<Dijete> Dijetes { get; set; }
        public virtual ICollection<ObiteljDodatno> ObiteljDodatnos { get; set; }
    }
}
