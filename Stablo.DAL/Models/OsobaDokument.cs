using System;
using System.Collections.Generic;

#nullable disable

namespace Stablo.DAL
{
    public partial class OsobaDokument
    {
        public Guid Id { get; set; }
        public Guid OsobaId { get; set; }
        public Guid DokumentId { get; set; }
        public Guid? OsobaDogadjajId { get; set; }
        public string Opis { get; set; }
        public string Napomena { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public virtual Dokument Dokument { get; set; }
        public virtual Osoba Osoba { get; set; }
        public virtual OsobaDogadjaj OsobaDogadjaj { get; set; }
    }
}
