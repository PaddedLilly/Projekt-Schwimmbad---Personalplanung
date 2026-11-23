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
    BeginZeit   datetime,
    EndZeit     datetime
);

CREATE TABLE Besetzung (
    MitarbeiterID   int,
    SchichtID       int,
    FOREIGN KEY (MitarbeiterID) REFERENCES Mitarbeiter(MitarbeiterID),
    FOREIGN KEY (SchichtID) REFERENCES Schicht(SchichtID)
);

CREATE TABLE PersonalBedarf (
    ArbeitsTypID    int,
    SchichtID       int,
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
('Willy Weber',     30, 2);

GO
SELECT MitarbeiterName,ArbeitsStunden,ArbeitsTyp.Bezeichnung
FROM Mitarbeiter
JOIN ArbeitsTyp ON ArbeitsTyp.ArbeitsTypID = Mitarbeiter.ArbeitsTypID