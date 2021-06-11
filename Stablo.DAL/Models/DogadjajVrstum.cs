using System;
using System.Collections.Generic;

#nullable disable

namespace Stablo.DAL
{
    public partial class DogadjajVrstum
    {
        public DogadjajVrstum()
        {
            Dogadjajs = new HashSet<Dogadjaj>();
        }

        public Guid Id { get; set; }
        public string Naziv { get; set; }
        public string Napomena { get; set; }
        public string Opis { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public virtual ICollection<Dogadjaj> Dogadjajs { get; set; }
    }
}
