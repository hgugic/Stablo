create table "TocnostVremenaLookup" (

"Id" uuid not null,
"Opis" citext not null,
"Naziv" citext not null,
"Kratica" citext not null,
"DateCreated" timestamp without time zone not null,
"DateUpdated" timestamp without time zone not null,
 CONSTRAINT "PK_TocnostVremenaLookup" PRIMARY KEY ("Id")
);

--insert into "TocnostVremenaLookup" ("Id", "Opis", "Naziv", "Kratica", "DateCreated", "DateUpdated")

create table "Lokacija" (

"Id" uuid not null,
"Naziv" citext not null,
"Mjesto" citext,
"Opis" citext,
"DateCreated" timestamp without time zone not null,
"DateUpdated" timestamp without time zone not null,
 CONSTRAINT "PK_Lokacija" PRIMARY KEY ("Id")
);

create table "LokacijaDodatno" (

"Id" uuid not null,
"LokacijaId" uuid not null,
"NazivPolja" citext not null,
"VrijednostPolja" citext not null,
"DateCreated" timestamp without time zone not null,
"DateUpdated" timestamp without time zone not null,
 CONSTRAINT "PK_LokacijaDodatno" PRIMARY KEY ("Id"),
 CONSTRAINT "FK_LokacijaDodatno_Lokacija" FOREIGN KEY ("LokacijaId") REFERENCES "Lokacija"("Id")
);

create table "LokacijaGeografija" (

"Id" uuid not null,
"LokacijaId" uuid not null,
"Opis" citext,
"Geografija" citext not null,
"DateCreated" timestamp without time zone not null,
"DateUpdated" timestamp without time zone not null,
 CONSTRAINT "PK_LokacijaGeografija" PRIMARY KEY ("Id"),
 CONSTRAINT "FK_LokacijaGeografija_Lokacija" FOREIGN KEY ("LokacijaId") REFERENCES "Lokacija"("Id")
);

create table "DogadjajVrsta" (

"Id" uuid not null,
"Naziv" citext not null,
"Napomena" citext,
"Opis" citext,
"DateCreated" timestamp without time zone not null,
"DateUpdated" timestamp without time zone not null,
 CONSTRAINT "PK_DogadjajVrsta" PRIMARY KEY ("Id")
);

create table "Dogadjaj" (

"Id" uuid not null,
"DogadjajVrstaId" uuid,
"Naziv" citext not null,
"Napomena" citext,
"Opis" citext,
"DatumTocnostId" uuid,
"LokacijaId" uuid,
"DateCreated" timestamp without time zone not null,
"DateUpdated" timestamp without time zone not null,
 CONSTRAINT "PK_Dogadjaj" PRIMARY KEY ("Id"),
 CONSTRAINT "FK_Dogadjaj_Lokacija" FOREIGN KEY ("LokacijaId") REFERENCES "Lokacija"("Id"),
 CONSTRAINT "FK_Dogadjaj_DogadjajVrsta" FOREIGN KEY ("DogadjajVrstaId") REFERENCES "DogadjajVrsta"("Id"),
 CONSTRAINT "FK_Dogadjaj_DatumTocnostLookup" FOREIGN KEY ("DatumTocnostId") REFERENCES "TocnostVremenaLookup"("Id")
);

create table "Slika" (

"Id" uuid not null,
"Naziv" citext,
"Opis" citext,
"Album" citext,
"FilePath" citext not null,
"Datum" timestamp without time zone not null,
"DatumTocnostId" uuid,
"LokacijaId" uuid,
"DateCreated" timestamp without time zone not null,
"DateUpdated" timestamp without time zone not null,
 CONSTRAINT "PK_Slike" PRIMARY KEY ("Id"),
 CONSTRAINT "FK_Slike_Lokacija" FOREIGN KEY ("LokacijaId") REFERENCES "Lokacija"("Id"),
 CONSTRAINT "FK_Slike_DatumTocnost" FOREIGN KEY ("DatumTocnostId") REFERENCES "TocnostVremenaLookup"("Id")
);

create table "Dokument" (

"Id" uuid not null,
"Naziv" citext,
"Opis" citext,
"FilePath" citext not null,
"Datum" timestamp without time zone not null,
"DatumTocnostId" uuid,
"LokacijaId" uuid,
"DateCreated" timestamp without time zone not null,
"DateUpdated" timestamp without time zone not null,
 CONSTRAINT "PK_Dokument" PRIMARY KEY ("Id"),
 CONSTRAINT "FK_Dokument_Lokacija" FOREIGN KEY ("LokacijaId") REFERENCES "Lokacija"("Id"),
 CONSTRAINT "FK_Dokument_DatumTocnost" FOREIGN KEY ("DatumTocnostId") REFERENCES "TocnostVremenaLookup"("Id")
);

create table "Loza" (
"Id" uuid not null,
"Naziv" citext,
"Opis" citext,
CONSTRAINT "PK_Loza" PRIMARY KEY ("Id")
);

create table "Osoba" (

"Id" uuid not null,
"Ime" citext not null,
"Prezime" citext,
"ObiteljskiNadimak" citext,
"Nadimak" citext,
"LozaId" uuid,
"Spol" varchar(8),
"MjestoRodenjaId" uuid,
"DatumRodenja" timestamp without time zone,
"DatumRodenjaTocnostId" uuid,
"MjestoSmrtiId" uuid,
"DatumSmrti" timestamp without time zone,
"DatumSmrtiTocnostId" uuid,
"BioloskiOtacId" uuid,
"BioloskaMajkaId" uuid,
"DateCreated" timestamp without time zone not null,
"DateUpdated" timestamp without time zone not null,

 CONSTRAINT "PK_Osoba" PRIMARY KEY ("Id"),
 CONSTRAINT "FK_Osoba_BioloskaMajka" FOREIGN KEY ("BioloskaMajkaId") REFERENCES "Osoba"("Id"),
 CONSTRAINT "FK_Osoba_BioloskiOtac" FOREIGN KEY ("BioloskiOtacId") REFERENCES "Osoba"("Id"),
 CONSTRAINT "FK_Osoba_MjestoRodenja" FOREIGN KEY ("MjestoRodenjaId") REFERENCES "Lokacija"("Id"),
 CONSTRAINT "FK_Osoba_MjestoSmrti" FOREIGN KEY ("MjestoSmrtiId") REFERENCES "Lokacija"("Id"),
 CONSTRAINT "FK_Slike_DatumRodenjaTocnost" FOREIGN KEY ("DatumRodenjaTocnostId") REFERENCES "TocnostVremenaLookup"("Id"),
 CONSTRAINT "FK_Slike_DatumSmrtiTocnost" FOREIGN KEY ("DatumSmrtiTocnostId") REFERENCES "TocnostVremenaLookup"("Id"),
 CONSTRAINT "FK_Slike_Loza" FOREIGN KEY ("LozaId") REFERENCES "Loza"("Id")
);


create table "OsobaDodatno" (

"Id" uuid not null,
"OsobaId" uuid not null,
"NazivPolja" citext not null,
"VrijednostPolja" citext not null,
"DateCreated" timestamp without time zone not null,
"DateUpdated" timestamp without time zone not null,
 CONSTRAINT "PK_OsobaDodatno" PRIMARY KEY ("Id"),
 CONSTRAINT "FK_OsobaDodatno_Osoba" FOREIGN KEY ("OsobaId") REFERENCES "Osoba"("Id")
);

create table "OsobaDogadjaj" (

"Id" uuid not null,
"OsobaId" uuid not null,
"DogadjajId" uuid not null,
"Naziv" citext,
"Uloga" citext,
"Napomena" citext,
"Opis" citext,
"DateCreated" timestamp without time zone not null,
"DateUpdated" timestamp without time zone not null,
 CONSTRAINT "PK_OsobaDogadjaj" PRIMARY KEY ("Id"),
 CONSTRAINT "FK_OsobaDogadjaj_Osoba" FOREIGN KEY ("OsobaId") REFERENCES "Osoba"("Id"),
 CONSTRAINT "FK_OsobaDogadjaj_Dogadjaj" FOREIGN KEY ("DogadjajId") REFERENCES "Dogadjaj"("Id")
);

create table "OsobaSlika" (

"Id" uuid not null,
"OsobaId" uuid not null,
"SlikaId" uuid not null,
"OsobaDogadjajId" uuid,
"KoordinateNaSlici" geography,
"Opis" citext,
"Napomena" citext,
"DateCreated" timestamp without time zone not null,
"DateUpdated" timestamp without time zone not null,
 CONSTRAINT "PK_OsobaSlika" PRIMARY KEY ("Id"),
 CONSTRAINT "FK_OsobaSlika_Osoba" FOREIGN KEY ("OsobaId") REFERENCES "Osoba"("Id"),
 CONSTRAINT "FK_OsobaSlika_OsobaDogadjaj" FOREIGN KEY ("OsobaDogadjajId") REFERENCES "OsobaDogadjaj"("Id"),
 CONSTRAINT "FK_OsobaSlika_Slika" FOREIGN KEY ("SlikaId") REFERENCES "Slika"("Id")
);

create table "OsobaDokument" (

"Id" uuid not null,
"OsobaId" uuid not null,
"DokumentId" uuid not null,
"OsobaDogadjajId" uuid,
"Opis" citext,
"Napomena" citext,
"DateCreated" timestamp without time zone not null,
"DateUpdated" timestamp without time zone not null,
 CONSTRAINT "PK_OsobaDokument" PRIMARY KEY ("Id"),
 CONSTRAINT "FK_OsobaDokument_Osoba" FOREIGN KEY ("OsobaId") REFERENCES "Osoba"("Id"),
  CONSTRAINT "FK_OsobaSlika_OsobaDogadjaj" FOREIGN KEY ("OsobaDogadjajId") REFERENCES "OsobaDogadjaj"("Id"),
 CONSTRAINT "FK_OsobaDokument_Dokument" FOREIGN KEY ("DokumentId") REFERENCES "Dokument"("Id")
);

create table "VrstaObiteljiLookup" (

"Id" uuid not null,
"Opis" citext,
"Naziv" citext not null,
"Kratica" citext not null,
"DateCreated" timestamp without time zone not null,
"DateUpdated" timestamp without time zone not null,
 CONSTRAINT "PK_VrstaObitelji" PRIMARY KEY ("Id")
);


create table "Obitelj" (

"Id" uuid not null,
"VrstaId" uuid,
"Pocetak" timestamp without time zone,
"Zavrsetak" timestamp without time zone,
"Osoba1Id" uuid not null,
"Naziv1" citext,
"Opis1" citext,
"Osoba2Id" uuid,
"Naziv2" citext,
"Opis2" citext,
"DateCreated" timestamp without time zone not null,
"DateUpdated" timestamp without time zone not null,
 CONSTRAINT "PK_Obitelj" PRIMARY KEY ("Id"),
 CONSTRAINT "FK_Obitelj_Osoba1" FOREIGN KEY ("Osoba1Id") REFERENCES "Osoba"("Id"),
 CONSTRAINT "FK_Obitelj_Osoba2" FOREIGN KEY ("Osoba2Id") REFERENCES "Osoba"("Id"),
 CONSTRAINT "FK_Obitelj_VrstaObitelji" FOREIGN KEY ("VrstaId") REFERENCES "VrstaObiteljiLookup"("Id")
);


create table "ObiteljDodatno" (

"Id" uuid not null,
"ObiteljId" uuid not null,
"NazivPolja" citext not null,
"VrijednostPolja" citext not null,
"DateCreated" timestamp without time zone not null,
"DateUpdated" timestamp without time zone not null,
 CONSTRAINT "PK_ObiteljDodatno" PRIMARY KEY ("Id"),
 CONSTRAINT "FK_ObiteljDodatno_Obitelj" FOREIGN KEY ("ObiteljId") REFERENCES "Obitelj"("Id")
);


create table "Dijete" (

"Id" uuid not null,
"ObiteljId" uuid not null,
"DijeteId" uuid not null,
"Napomena" citext,
"Opis" citext,
"DateCreated" timestamp without time zone not null,
"DateUpdated" timestamp without time zone not null,
 CONSTRAINT "PK_Dijete" PRIMARY KEY ("Id"),
 CONSTRAINT "FK_Dijete_Obitelj" FOREIGN KEY ("ObiteljId") REFERENCES "Obitelj"("Id"),
 CONSTRAINT "FK_Dijete_Osoba" FOREIGN KEY ("DijeteId") REFERENCES "Osoba"("Id")
);








