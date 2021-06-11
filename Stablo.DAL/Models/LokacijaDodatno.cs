using System;
using System.Collections.Generic;

#nullable disable

namespace Stablo.DAL
{
    public partial class LokacijaDodatno
    {
        public Guid Id { get; set; }
        public Guid LokacijaId { get; set; }
        public string NazivPolja { get; set; }
        public string VrijednostPolja { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public virtual Lokacija Lokacija { get; set; }
    }
}
