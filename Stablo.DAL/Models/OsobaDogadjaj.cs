using System;
using System.Collections.Generic;

#nullable disable

namespace Stablo.DAL
{
    public partial class OsobaDogadjaj
    {
        public OsobaDogadjaj()
        {
            OsobaDokuments = new HashSet<OsobaDokument>();
            OsobaSlikas = new HashSet<OsobaSlika>();
        }

        public Guid Id { get; set; }
        public Guid OsobaId { get; set; }
        public Guid DogadjajId { get; set; }
        public string Naziv { get; set; }
        public string Uloga { get; set; }
        public string Napomena { get; set; }
        public string Opis { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public virtual Dogadjaj Dogadjaj { get; set; }
        public virtual Osoba Osoba { get; set; }
        public virtual ICollection<OsobaDokument> OsobaDokuments { get; set; }
        public virtual ICollection<OsobaSlika> OsobaSlikas { get; set; }
    }
}
