using System;
using System.Collections.Generic;

#nullable disable

namespace Stablo.DAL
{
    public partial class Dokument
    {
        public Dokument()
        {
            OsobaDokuments = new HashSet<OsobaDokument>();
        }

        public Guid Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string FilePath { get; set; }
        public DateTime Datum { get; set; }
        public Guid? DatumTocnostId { get; set; }
        public Guid? LokacijaId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public virtual TocnostVremenaLookup DatumTocnost { get; set; }
        public virtual Lokacija Lokacija { get; set; }
        public virtual ICollection<OsobaDokument> OsobaDokuments { get; set; }
    }
}
