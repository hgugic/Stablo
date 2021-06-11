using System;
using System.Collections.Generic;

#nullable disable

namespace Stablo.DAL
{
    public partial class OsobaSlika
    {
        public Guid Id { get; set; }
        public Guid OsobaId { get; set; }
        public Guid SlikaId { get; set; }
        public Guid? OsobaDogadjajId { get; set; }
        public string Opis { get; set; }
        public string Napomena { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public virtual Osoba Osoba { get; set; }
        public virtual OsobaDogadjaj OsobaDogadjaj { get; set; }
        public virtual Slika Slika { get; set; }
    }
}
