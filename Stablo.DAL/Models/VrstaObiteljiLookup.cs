using System;
using System.Collections.Generic;

#nullable disable

namespace Stablo.DAL
{
    public partial class VrstaObiteljiLookup
    {
        public VrstaObiteljiLookup()
        {
            Obiteljs = new HashSet<Obitelj>();
        }

        public Guid Id { get; set; }
        public string Opis { get; set; }
        public string Naziv { get; set; }
        public string Kratica { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public virtual ICollection<Obitelj> Obiteljs { get; set; }
    }
}
