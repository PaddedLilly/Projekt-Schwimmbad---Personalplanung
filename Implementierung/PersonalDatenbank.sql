IF DB_ID(N'Personalverwaltung') IS NULL
    CREATE DATABASE Personalverwaltung;
GO

USE Personalverwaltung;
GO 

IF OBJECT_ID('Besetzung') IS NOT NULL
    DROP TABLE Besetzung;
IF OBJECT_ID('Personalbedarf') IS NOT NULL
    DROP TABLE Personalbedarf;
IF OBJECT_ID('Mitarbeiter') IS NOT NULL
    DROP TABLE Mitarbeiter;
IF OBJECT_ID('Schicht') IS NOT NULL
    DROP TABLE Schicht;
IF OBJECT_ID('ArbeitsTyp') IS NOT NULL
    DROP TABLE ArbeitsTyp;
GO 

CREATE TABLE ArbeitsTyp (
    ArbeitsTypID    int PRIMARY KEY IDENTITY (1,1),
    Bezeichnung     varchar(50)
);

CREATE TABLE Mitarbeiter (
    MitarbeiterID   int PRIMARY KEY IDENTITY (1,1),
    MitarbeiterName varchar(50),
    ArbeitsStunden  int,
    ArbeitsTypID    int,
    FOREIGN KEY (ArbeitsTypID) REFERENCES ArbeitsTyp(ArbeitsTypID)
);

CREATE TABLE Schicht (
    SchichtID   int PRIMARY KEY IDENTITY (1,1),
    SchichtName varchar(50),
    Datum       date,
    BeginnZeit   time,
    EndZeit     time
);

-- Defines who works at what shift
CREATE TABLE Besetzung (
    MitarbeiterID   int,
    SchichtID       int,
    PRIMARY KEY (MitarbeiterID, SchichtID),
    FOREIGN KEY (MitarbeiterID) REFERENCES Mitarbeiter(MitarbeiterID),
    FOREIGN KEY (SchichtID) REFERENCES Schicht(SchichtID)
);

-- Defines how many of each work type is needed in a shift
CREATE TABLE PersonalBedarf (
    SchichtID       int,
    ArbeitsTypID    int,
    BenötigteAnzahl int,
    PRIMARY KEY (ArbeitsTypID, SchichtID),
    FOREIGN KEY (ArbeitsTypID) REFERENCES ArbeitsTyp(ArbeitsTypID),
    FOREIGN KEY (SchichtID) REFERENCES Schicht(SchichtID)
);

INSERT INTO ArbeitsTyp (Bezeichnung)
VALUES
('Fachangestellte*r für Bäderbetriebe'),
('Verwaltung'),
('Empfang'),
('Reinigungsfachkraft'),
('Hausmeister');

INSERT INTO Mitarbeiter (MitarbeiterName,ArbeitsStunden,ArbeitsTypID)
VALUES
('Peter Kleber',    40, 1),
('Willy Weber',     30, 2),
('Hans Müller',     35, 3),
('Klaus Schmidt',   40, 1),
('Sabine Fischer',  25, 4),
('Monika Schneider',30, 2),
('Thomas Becker',   38, 5),
('Uwe Hoffmann',    20, 4),
('Michael Wagner',  40, 1),
('Stefan Bauer',    35, 2),
('Andrea Richter',  30, 4),
('Petra Klein',     25, 5),
('Frank Wolf',      40, 3),
('Jürgen Schröder', 38, 1),
('Claudia Neumann', 30, 2),
('Markus Schwarz',  35, 4);

Insert INTO Schicht (SchichtName, Datum, BeginnZeit, EndZeit)
VAlUES
('Montag Morgen','2026-11-30','06:00:00','14:00:00'),
('Montag Mittag','2026-11-30','10:00:00','18:00:00'),
('Montag Abend','2026-11-30','14:00:00','22:00:00'),
('Dienstag Morgen','2026-12-01','06:00:00','14:00:00'),
('Dienstag Mittag','2026-12-01','10:00:00','18:00:00'),
('Dienstag Abend','2026-12-01','14:00:00','22:00:00');

INSERT INTO Besetzung (MitarbeiterID,SchichtID)
VALUES
(1,1),
(2,1),
(3,1),
(4,1),
(5,1),
(6,1),
(7,1),
(8,2),
(9,2),
(10,2),
(11,3),
(12,3),
(13,3),
(14,3);

INSERT INTO PersonalBedarf (SchichtID, ArbeitsTypID, BenötigteAnzahl)
VALUES
(1,1,1), --1 Bademeister
(1,2,2), --2 Verwaltung
(1,3,1), --1 Empfang
(1,4,2), --2 Reinigung
(1,5,1); --1 Hausmeister

  
GO
SELECT MitarbeiterName,ArbeitsStunden,ArbeitsTyp.Bezeichnung
FROM Mitarbeiter
JOIN ArbeitsTyp ON ArbeitsTyp.ArbeitsTypID = Mitarbeiter.ArbeitsTypID

Select SchichtName As Schicht, Datum, BeginnZeit AS 'Beginn', ArbeitsTyp.Bezeichnung As Arbeitstyp, BenötigteAnzahl As 'Benötigte Anzahl'
From Schicht 
JOIN PersonalBedarf ON Schicht.SchichtID = PersonalBedarf.SchichtID 
JOIN ArbeitsTyp ON PersonalBedarf.ArbeitsTypID = ArbeitsTyp.ArbeitsTypID
