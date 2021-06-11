using System;
using System.Collections.Generic;

#nullable disable

namespace Stablo.DAL
{
    public partial class Dijete
    {
        public Guid Id { get; set; }
        public Guid ObiteljId { get; set; }
        public Guid DijeteId { get; set; }
        public string Napomena { get; set; }
        public string Opis { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public virtual Osoba DijeteNavigation { get; set; }
        public virtual Obitelj Obitelj { get; set; }
    }
}
