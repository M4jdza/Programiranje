--PRILIKOM KOPIRANJA SQL KODA, MORA SE PROMENITI U INSERTIMA MODELA PUTANJA DO DEFAULT SLIKE (no_image.png)

CREATE TABLE grad
(GradID INT PRIMARY KEY,
Grad NVARCHAR(255) NOT NULL,
PozivniBroj NVARCHAR(20) NOT NULL,
PostanskiBroj NVARCHAR(20) NOT NULL,
BrojStanovnika INT NOT NULL );

CREATE TABLE vozac
( VozacID INT PRIMARY KEY,
Ime NVARCHAR(255) NOT NULL,
Prezime NVARCHAR(255) NOT NULL,
DatumRodjenja DATE NOT NULL,
DozvolaIzdata DATE NOT NULL,
Adresa NVARCHAR(255) NOT NULL,
GradID INT REFERENCES grad(GradID) );

CREATE TABLE polisa
( PolisaID INT PRIMARY KEY,
DatumPocetka DATE NOT NULL,
DatumZavrsetka DATE NOT NULL,
Vrednost INT NOT NULL);

CREATE TABLE proizvodjac
( ProizvodjacID INT PRIMARY KEY,
Naziv NVARCHAR(255) NOT NULL);

CREATE TABLE model
(ModelID INT PRIMARY KEY,
Naziv NVARCHAR(255) NOT NULL,
ProizvodjacID INT REFERENCES proizvodjac(ProizvodjacID),
NazivFajla NVARCHAR(255) NOT NULL,
SLIKA varbinary(max) NOT NULL,
KUBIKAZA INT NOT NULL);

CREATE TABLE vozilo
( VoziloID INT PRIMARY KEY,
BrojSasije NVARCHAR(20) NOT NULL,
BrojMotora NVARCHAR(20) NOT NULL,
VelicinaMotora NVARCHAR(255) NOT NULL,
ModelID INT REFERENCES model(ModelID), 
GodinaRegistracije DATE NOT NULL,
RegistarskiBroj NVARCHAR(20) NOT NULL,
PolisaID INT REFERENCES polisa(PolisaID) );

CREATE TABLE vozilo_vozac
( VozacID INT REFERENCES vozac(VozacID),
VoziloID INT REFERENCES vozilo(VoziloID),
CONSTRAINT PK_PrimaryTableLink PRIMARY KEY (VozacID, VoziloID));

--GRADOVI
INSERT INTO grad
VALUES (1, 'Kraljevo', 036, 36000, 100000);
INSERT INTO grad
VALUES (2, 'Beograd', 011, 11000, 2000000);
INSERT INTO grad
VALUES (3, 'Cacak', 032, 32000, 120000);
INSERT INTO grad
VALUES (4, 'Nis', 018, 18000, 320000);
INSERT INTO grad
VALUES (5, 'Novi Sad', 021, 21000, 400000);
INSERT INTO grad
VALUES (6, 'Sombor', 047, 47000, 63000);
INSERT INTO grad
VALUES (7, 'Zrenjanin', 023, 23000, 88800);
INSERT INTO grad
VALUES (8, 'Arandjelovac', 034, 34303, 20000);
INSERT INTO grad
VALUES (9, 'Svilajinac', 035, 35210, 20000);
INSERT INTO grad
VALUES (10, 'Pozega', 031, 31210, 60000);
INSERT INTO grad
VALUES (11, 'Pozarevac', 012, 12000, 50000);
INSERT INTO grad
VALUES (12, 'Krusevac', 037, 37000, 70000);
INSERT INTO grad
VALUES (13, 'Subotica', 024, 24000, 100000);
INSERT INTO grad
VALUES (14, 'Loznica', 015, 15300, 80000);
INSERT INTO grad
VALUES (15, 'Novi Pazar', 020, 36300, 70000);
INSERT INTO grad
VALUES (16, 'Tutin', 020, 36320, 30000);
INSERT INTO grad
VALUES (17, 'Zajecar', 019, 19000, 20000);
INSERT INTO grad
VALUES (18, 'Bor', 030, 19210, 15000);
INSERT INTO grad
VALUES (19, 'Vranje', 017, 17500, 15000);
INSERT INTO grad
VALUES (20, 'Dimitrovgrad', 010, 18320, 14000);

--VOZACI
INSERT INTO vozac
VALUES(1,'Pera','Peric', '1955-5-25' , '1999-3-20','Vojvode Stepe 125',2);
INSERT INTO vozac
VALUES(2,'Laza','Maricic','1982-8-16','2001-5-7','Cara Dusana 52',1);
INSERT INTO vozac
VALUES(3,'Vuk','Perisic','1955-5-21','1975-6-18','Djure Perisica',3);
INSERT INTO vozac
VALUES(4,'Ilija','Vlajovic','1989-4-17','2008-3-26','Vuka Brankovica 34',4);
INSERT INTO vozac
VALUES(5,'Vladimir','Plavsic','1996-11-16','2015-04-15','Knez Mihajlnova', 5);
INSERT INTO vozac
VALUES(6,'Bogdan','Vujic','1999-7-06','2017-10-04','Turistica 6',6);
INSERT INTO vozac
VALUES(7,'Stefan','Vukovic','1999-02-25','2017-06-15','Milocaj 228',7);
INSERT INTO vozac
VALUES(8,'Marko','Andjelkovic','1999-12-17','2016-11-16','Kovanlucka 15',8);
INSERT INTO vozac
VALUES(9,'Bojan','Milosevic','1981-04-19','2010-12-12','Vojvode Misica 11',9);
INSERT INTO vozac
VALUES(10,'Rajko','Mitic','1938-09-16','1975-01-25','Pupinova',10);
INSERT INTO vozac
VALUES(11,'Zoran','Jovanovic','1957-03-27','1980-12-30','Rajkova 12a',11);
INSERT INTO vozac
VALUES(12,'Nebojsa','Maric','1989-05-14','2008-06-04','Jug Bogdanova 44a',12);
INSERT INTO vozac
VALUES(13,'Petar','Milojevic','1979-08-01','1999-10-16','Cara Lazara',13);
INSERT INTO vozac
VALUES(14,'Mirko','Zivanovic','2016-11-29','2018-11-04','Pera Mikica',14);
INSERT INTO vozac
VALUES(15,'Stefan','Jeftic','2001-12-01','2017-08-17','Milosa Velikog 112a',15);
INSERT INTO vozac
VALUES(16,'Matija','Gojkovic','2017-07-06','2018-02-05','Dositejeva 22',16);
INSERT INTO vozac
VALUES(17,'Nadja','Trisic','2017-11-22','2017-06-15','Cara Bogdana',17);
INSERT INTO vozac
VALUES(18,'Sara','Butacevic','1999-12-12','2016-11-16','Vranesi bb',18);
INSERT INTO vozac
VALUES(19,'Stefan','Debeljak','2005-05-15','2014-12-12','Godacica 76a/8',19);
INSERT INTO vozac
VALUES(20,'Milica','Djordjevic','2007-07-07','2018-02-05','Mosin Gaj bb',20);

--POLISA
INSERT INTO polisa
VALUES(1,'2010-03-05','2023-03-05',5000);
INSERT INTO polisa
VALUES(2,'2013-05-26','2023-05-26',18000);
INSERT INTO polisa
VALUES(3,'2015-04-15','2023-10-17',7500);
INSERT INTO polisa
VALUES(4,'2014-11-06','2023-04-30',12457);
INSERT INTO polisa
VALUES(5,'2010-10-20','2023-07-16',33000);
INSERT INTO polisa
VALUES(6,'2010-10-20','2023-07-16',14000);
INSERT INTO polisa
VALUES(7,'2014-09-06','2023-01-29',22000);
INSERT INTO polisa
VALUES(8,'2004-06-15','2023-06-11',12200);
INSERT INTO polisa
VALUES(9,'2015-07-16','2023-11-19',78000);
INSERT INTO polisa
VALUES(10,'2015-01-27','2023-01-01',8000);
INSERT INTO polisa
VALUES(11,'2000-02-02','2023-02-02',3500);
INSERT INTO polisa
VALUES(12,'2009-11-26','2023-07-12',15222);
INSERT INTO polisa
VALUES(13,'2014-04-11','2023-03-07',36555);
INSERT INTO polisa
VALUES(14,'2016-07-14','2024-02-28',18966);
INSERT INTO polisa
VALUES(15,'2013-05-13','2023-02-03',45000);
INSERT INTO polisa
VALUES(16,'2012-06-12','2023-07-16',4900);
INSERT INTO polisa
VALUES(17,'2015-07-22','2023-09-22',65000);
INSERT INTO polisa
VALUES(18,'2018-01-08','2023-10-16',85000);
INSERT INTO polisa
VALUES(19,'2017-11-22','2024-06-12',33555000);
INSERT INTO polisa
VALUES(20,'2015-08-15','2023-12-20',55);



--PROIZVODJAC

INSERT INTO proizvodjac
VALUES(1,'BMW');

INSERT INTO proizvodjac
VALUES(2,'Volkswagen');

INSERT INTO proizvodjac
VALUES(3,'Audi');

INSERT INTO proizvodjac
VALUES(4,'Mercedes');

INSERT INTO proizvodjac
VALUES(5,'Peugeot');

INSERT INTO proizvodjac
VALUES(6,'BRABUS');

INSERT INTO proizvodjac
VALUES(7,'ACURA');

INSERT INTO proizvodjac
VALUES(8,'Nissan');

INSERT INTO proizvodjac
VALUES(9,'Mazda');

INSERT INTO proizvodjac
VALUES(10,'Toyota');

INSERT INTO proizvodjac
VALUES(11,'Hyundai');



--MODELI (MORA SE PROMENITI PUTANJA U OPENROWSETU)

INSERT INTO model
VALUES(1,'BMW 335i',1, 'no_image.png', (SELECT * FROM OPENROWSET(BULK N'C:\Users\lazol\OneDrive\Радна површина\Programiranje\A27 - Osiguranje Vozila\PROJEKAT PROGRAMIRANJE\bin\Debug\Slike\no_image.png', SINGLE_BLOB) as T1), 1400);
INSERT INTO model
VALUES(2,'Golf 7 R',2, 'no_image.png', (SELECT * FROM OPENROWSET(BULK N'C:\Users\lazol\OneDrive\Радна површина\Programiranje\A27 - Osiguranje Vozila\PROJEKAT PROGRAMIRANJE\bin\Debug\Slike\no_image.png', SINGLE_BLOB) as T1), 1900);
INSERT INTO model
VALUES(3,'Audi A8L',3, 'no_image.png', (SELECT * FROM OPENROWSET(BULK N'C:\Users\lazol\OneDrive\Радна површина\Programiranje\A27 - Osiguranje Vozila\PROJEKAT PROGRAMIRANJE\bin\Debug\Slike\no_image.png', SINGLE_BLOB) as T1), 5000);
INSERT INTO model
VALUES(4,'BMW M550D',1, 'no_image.png', (SELECT * FROM OPENROWSET(BULK N'C:\Users\lazol\OneDrive\Радна површина\Programiranje\A27 - Osiguranje Vozila\PROJEKAT PROGRAMIRANJE\bin\Debug\Slike\no_image.png', SINGLE_BLOB) as T1), 3000);
INSERT INTO model
VALUES(5,'Mercedes S500',4, 'no_image.png', (SELECT * FROM OPENROWSET(BULK N'C:\Users\lazol\OneDrive\Радна површина\Programiranje\A27 - Osiguranje Vozila\PROJEKAT PROGRAMIRANJE\bin\Debug\Slike\no_image.png', SINGLE_BLOB) as T1), 5000);
INSERT INTO model
VALUES(6,'Peugeot 407',5, 'no_image.png', (SELECT * FROM OPENROWSET(BULK N'C:\Users\lazol\OneDrive\Радна површина\Programiranje\A27 - Osiguranje Vozila\PROJEKAT PROGRAMIRANJE\bin\Debug\Slike\no_image.png', SINGLE_BLOB) as T1), 1300);
INSERT INTO model
VALUES(7,'Golf 6 GTI',2, 'no_image.png', (SELECT * FROM OPENROWSET(BULK N'C:\Users\lazol\OneDrive\Радна површина\Programiranje\A27 - Osiguranje Vozila\PROJEKAT PROGRAMIRANJE\bin\Debug\Slike\no_image.png', SINGLE_BLOB) as T1), 1600);
INSERT INTO model
VALUES(8,'BRABUS 800',6, 'no_image.png', (SELECT * FROM OPENROWSET(BULK N'C:\Users\lazol\OneDrive\Радна површина\Programiranje\A27 - Osiguranje Vozila\PROJEKAT PROGRAMIRANJE\bin\Debug\Slike\no_image.png', SINGLE_BLOB) as T1), 6000);
INSERT INTO model
VALUES(9,'BMW M5 CS',1, 'no_image.png', (SELECT * FROM OPENROWSET(BULK N'C:\Users\lazol\OneDrive\Радна површина\Programiranje\A27 - Osiguranje Vozila\PROJEKAT PROGRAMIRANJE\bin\Debug\Slike\no_image.png', SINGLE_BLOB) as T1), 4000);
INSERT INTO model
VALUES(10,'Acura NSX',7, 'no_image.png', (SELECT * FROM OPENROWSET(BULK N'C:\Users\lazol\OneDrive\Радна површина\Programiranje\A27 - Osiguranje Vozila\PROJEKAT PROGRAMIRANJE\bin\Debug\Slike\no_image.png', SINGLE_BLOB) as T1), 3000);
INSERT INTO model
VALUES(11,'Arteon',2, 'no_image.png', (SELECT * FROM OPENROWSET(BULK N'C:\Users\lazol\OneDrive\Радна површина\Programiranje\A27 - Osiguranje Vozila\PROJEKAT PROGRAMIRANJE\bin\Debug\Slike\no_image.png', SINGLE_BLOB) as T1), 2000);
INSERT INTO model
VALUES(12,'G63',4, 'no_image.png', (SELECT * FROM OPENROWSET(BULK N'C:\Users\lazol\OneDrive\Радна површина\Programiranje\A27 - Osiguranje Vozila\PROJEKAT PROGRAMIRANJE\bin\Debug\Slike\no_image.png', SINGLE_BLOB) as T1), 5500);
INSERT INTO model
VALUES(13,'GT-R35',8, 'no_image.png', (SELECT * FROM OPENROWSET(BULK N'C:\Users\lazol\OneDrive\Радна површина\Programiranje\A27 - Osiguranje Vozila\PROJEKAT PROGRAMIRANJE\bin\Debug\Slike\no_image.png', SINGLE_BLOB) as T1), 6000);
INSERT INTO model
VALUES(14,'RX-7',9, 'no_image.png', (SELECT * FROM OPENROWSET(BULK N'C:\Users\lazol\OneDrive\Радна површина\Programiranje\A27 - Osiguranje Vozila\PROJEKAT PROGRAMIRANJE\bin\Debug\Slike\no_image.png', SINGLE_BLOB) as T1), 1900);
INSERT INTO model
VALUES(15,'Supra',10, 'no_image.png', (SELECT * FROM OPENROWSET(BULK N'C:\Users\lazol\OneDrive\Радна површина\Programiranje\A27 - Osiguranje Vozila\PROJEKAT PROGRAMIRANJE\bin\Debug\Slike\no_image.png', SINGLE_BLOB) as T1), 4000);
INSERT INTO model
VALUES(16,'M4',1, 'no_image.png', (SELECT * FROM OPENROWSET(BULK N'C:\Users\lazol\OneDrive\Радна површина\Programiranje\A27 - Osiguranje Vozila\PROJEKAT PROGRAMIRANJE\bin\Debug\Slike\no_image.png', SINGLE_BLOB) as T1), 3000);
INSERT INTO model
VALUES(17,'Tucson',11, 'no_image.png', (SELECT * FROM OPENROWSET(BULK N'C:\Users\lazol\OneDrive\Радна површина\Programiranje\A27 - Osiguranje Vozila\PROJEKAT PROGRAMIRANJE\bin\Debug\Slike\no_image.png', SINGLE_BLOB) as T1), 1900);
INSERT INTO model
VALUES(18,'GT63S',4, 'no_image.png', (SELECT * FROM OPENROWSET(BULK N'C:\Users\lazol\OneDrive\Радна површина\Programiranje\A27 - Osiguranje Vozila\PROJEKAT PROGRAMIRANJE\bin\Debug\Slike\no_image.png', SINGLE_BLOB) as T1), 4000);
INSERT INTO model
VALUES(19,'E63S',4, 'no_image.png', (SELECT * FROM OPENROWSET(BULK N'C:\Users\lazol\OneDrive\Радна површина\Programiranje\A27 - Osiguranje Vozila\PROJEKAT PROGRAMIRANJE\bin\Debug\Slike\no_image.png', SINGLE_BLOB) as T1), 3000);
INSERT INTO model
VALUES(20,'GT-R34',8, 'no_image.png', (SELECT * FROM OPENROWSET(BULK N'C:\Users\lazol\OneDrive\Радна површина\Programiranje\A27 - Osiguranje Vozila\PROJEKAT PROGRAMIRANJE\bin\Debug\Slike\no_image.png', SINGLE_BLOB) as T1), 6000);



--VOZILO
INSERT INTO vozilo
VALUES(1,'WAUZZZ4BZWN049194','5674198745', 3.000,1, '2020-11-16','KV-001-AA',1); 

INSERT INTO vozilo
VALUES(2,'RAUTUZ4BZWN040947',' 6871349872', 2.000,2, '2021-11-16','KV-002-AB',2);

INSERT INTO vozilo
VALUES(3,' EZIPPZ4BZRN048834',' 7821569831', 3.000,3, '2019-11-16','KV-003-AC',3);

INSERT INTO vozilo
VALUES(4,' SWSDEZ4BAJM027625',' 3856941253', 3.000,4, '2020-12-16','KV-004-AD',4);

INSERT INTO vozilo
VALUES(5,' AGIEPG2EDSL721357',' 6478921453', 5.000,5, '2016-07-16','KV-005-AE',5);

INSERT INTO vozilo
VALUES(6,' AZHJ34BEGA742845',' 9547213640', 2.000,6, '2015-11-10','KV-006-AF',6);

INSERT INTO vozilo
VALUES(7,' WZWEHJ7JFHS862523',' 2314759874', 2.000,7, '2023-02-16','KV-007-AG',7);

INSERT INTO vozilo
VALUES(8,' KJIPRK2KJGS857624',' 8004597231', 4.000,8, '2023-05-16','KV-008-AH',8);

INSERT INTO vozilo
VALUES(9,' ERALKK3KHHS847845',' 4400068741', 4.000,9, '2021-09-09','KV-009-AI',9);

INSERT INTO vozilo
VALUES(10,' AUSPPZ4TZAR098753 ',' 3354789631', 3.000,10, '2022-11-16','KV-010-AJ',10);

INSERT INTO vozilo
VALUES(11,' PAGPYA3AARM376538',' 9848574315', 2.000,11, '2023-01-19','KV-011-AK',11);

INSERT INTO vozilo
VALUES(12,' KASHHA7HZHA031239',' 6300457123', 6.300,12, '2020-11-30','KV-012-AL',12);

INSERT INTO vozilo
VALUES(13,' EAEFA4RMMM876554',' 9874123578', 2.500,13, '2022-12-12','KV-013-AM',13);

INSERT INTO vozilo
VALUES(14,' TAIPHH3HHHA053265',' 1423047809', 1.400,14, '2019-11-16','KV-014-AN',14);

INSERT INTO vozilo
VALUES(15,' ZAOTOA4KZJN242863',' 7845120980', 3.000,15, '2016-07-21','KV-015-AO',15);

INSERT INTO vozilo
VALUES(16,' AZAPAZ3BSFS032745',' 4723045002', 3.000,16, '2022-11-26','KV-016-AP',16);

INSERT INTO vozilo
VALUES(17,' RZYZPA8GGGH948428',' 7815349830', 2.000,17, '2021-11-11','KV-017-AZ',17);

INSERT INTO vozilo
VALUES(18,' BZAEPA3AKSH141238',' 4574369891', 4.000,18, '2022-11-16','KV-018-AR',18);

INSERT INTO vozilo
VALUES(19,' PEUAAR4RZAG328126',' 7896541047', 4.000,19, '2023-03-08','KV-019-AS',19);

INSERT INTO vozilo
VALUES(20,' PWALAJ4ZSRA943443',' 7469328416', 3.000,20, '2023-02-28','KV-020-AT',20);




--VOZACI-VOZILO
INSERT INTO vozilo_vozac
VALUES(2,4);

INSERT INTO vozilo_vozac
VALUES(4,2);

INSERT INTO vozilo_vozac
VALUES(5,1);

INSERT INTO vozilo_vozac
VALUES(6,7);

INSERT INTO vozilo_vozac
VALUES(7,6);

INSERT INTO vozilo_vozac
VALUES(8,8);

INSERT INTO vozilo_vozac
VALUES(9,9);

INSERT INTO vozilo_vozac
VALUES(10,10);

INSERT INTO vozilo_vozac
VALUES(11,11);

INSERT INTO vozilo_vozac
VALUES(12,12);

INSERT INTO vozilo_vozac
VALUES(13,13);

INSERT INTO vozilo_vozac
VALUES(14,14);

INSERT INTO vozilo_vozac
VALUES(15,15);

INSERT INTO vozilo_vozac
VALUES(16,16);

INSERT INTO vozilo_vozac
VALUES(17,17);

INSERT INTO vozilo_vozac
VALUES(18,18);

INSERT INTO vozilo_vozac
VALUES(19,19);

INSERT INTO vozilo_vozac
VALUES(20,20);

INSERT INTO vozilo_vozac
VALUES(1,3);

INSERT INTO vozilo_vozac
VALUES(3,5);



--PROSIRENJE BAZE
ALTER TABLE vozilo
ADD vrednost INT;
CREATE TABLE prekrsaj
(
id INT PRIMARY KEY,
naziv NVARCHAR(255) NOT NULL,
opis NVARCHAR(1000) NOT NULL
);
CREATE TABLE vozac_prekrsaj
(
vozacid INT REFERENCES vozac(vozacid),
prekrsajid INT REFERENCES prekrsaj(id)
);
