using System;
using System.Collections.Generic;
using System.Text;

namespace ConsolePrototype
{
    internal class Schicht
    {
        //mockdata this would have to be loaded from the database
        public static (int SchichtID, string Name, DateOnly Datum, TimeOnly BeginnZeit, TimeOnly EndZeit, List<int> Personalbedarf)[] mockdataSchicht =
        [(1, "Montag Morgen", new DateOnly(2026, 11, 30), new TimeOnly(8, 0), new TimeOnly(16, 0), new List<int>()),
         (2, "Montag Morgen", new DateOnly(2026, 11, 30), new TimeOnly(12, 0), new TimeOnly(20, 0), new List<int>()),
         (3, "Montag Morgen", new DateOnly(2026, 11, 30), new TimeOnly(16, 0), new TimeOnly(23, 59), new List<int>())];

        int? SchichtID { get; }
        string Name { get; set; }
        DateOnly Datum { get; set; }
        TimeOnly BeginnZeit { get; set; }
        TimeOnly EndZeit { get; set; }
        List<int> Personalbedarf { get; set; }

        public Schicht(string name, DateOnly datum, TimeOnly beginnZeit, TimeOnly endZeit, List<int> personalbedarf)
        {
            Name = name;
            Datum = datum;
            BeginnZeit = beginnZeit;
            EndZeit = endZeit;
            Personalbedarf = personalbedarf;
        }

        public void AddToDatabase()
        {
            //TODO this would add the object to the database
        }

        public void AddMitarbeiter(Mitarbeiter m)
        {
            //TODO this would add m.MitarbeiterID to Besetzung in Database
        }

        public static Schicht? FindByID(int id)
        {
            //TODO implement 

            foreach (var s in mockdataSchicht)
            {
                if (s.SchichtID == id) return new(s.Name, s.Datum, s.BeginnZeit, s.EndZeit, s.Personalbedarf);
            }
            return null;
        }
    }
}
