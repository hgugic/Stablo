using System;
using System.Collections.Generic;

#nullable disable

namespace Stablo.DAL
{
    public partial class Dogadjaj
    {
        public Dogadjaj()
        {
            OsobaDogadjajs = new HashSet<OsobaDogadjaj>();
        }

        public Guid Id { get; set; }
        public Guid? DogadjajVrstaId { get; set; }
        public string Naziv { get; set; }
        public string Napomena { get; set; }
        public string Opis { get; set; }
        public Guid? DatumTocnostId { get; set; }
        public Guid? LokacijaId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public virtual TocnostVremenaLookup DatumTocnost { get; set; }
        public virtual DogadjajVrstum DogadjajVrsta { get; set; }
        public virtual Lokacija Lokacija { get; set; }
        public virtual ICollection<OsobaDogadjaj> OsobaDogadjajs { get; set; }
    }
}
