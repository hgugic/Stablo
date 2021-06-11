using System;
using System.Collections.Generic;

#nullable disable

namespace Stablo.DAL
{
    public partial class OsobaDodatno
    {
        public Guid Id { get; set; }
        public Guid OsobaId { get; set; }
        public string NazivPolja { get; set; }
        public string VrijednostPolja { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public virtual Osoba Osoba { get; set; }
    }
}
