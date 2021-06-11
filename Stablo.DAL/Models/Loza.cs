using System;
using System.Collections.Generic;

#nullable disable

namespace Stablo.DAL
{
    public partial class Loza
    {
        public Loza()
        {
            Osobas = new HashSet<Osoba>();
        }

        public Guid Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }

        public virtual ICollection<Osoba> Osobas { get; set; }
    }
}
