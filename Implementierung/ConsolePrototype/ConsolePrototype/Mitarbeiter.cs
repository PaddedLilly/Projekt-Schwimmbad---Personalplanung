using System;
using System.Collections.Generic;
using System.Text;

namespace ConsolePrototype
{
    internal class Mitarbeiter
    {
        // would have to be loaded from database
        public static (int MitarbeiterID, string Name, int Arbeitsstunden, int ArbeitsTypID)[] mockdataMitarbeiter =
        [   (1,"Peter Kleber",    40, 1),
            (2,"Willy Weber",     30, 2),
            (3,"Hans Müller",     35, 3),
            (4,"Klaus Schmidt",   40, 1),
            (5,"Sabine Fischer",  25, 4),
            (6,"Monika Schneider",30, 2),
            (7,"Thomas Becker",   38, 5),
            (8,"Uwe Hoffmann",    20, 4),
            (9,"Michael Wagner",  40, 1),
            (10,"Stefan Bauer",    35, 2),
            (11,"Andrea Richter",  30, 4),
            (12,"Petra Klein",     25, 5),
            (13,"Frank Wolf",      40, 3),
            (14,"Jürgen Schröder", 38, 1),
            (15,"Claudia Neumann", 30, 2),
            (16,"Markus Schwarz",  35, 4)];

        int? MitarbeiterID { get; }
        string Name { get; set; }
        int ArbeitsTypID { get; set; }
        int ArbeitsStunden { get; set; }

        public Mitarbeiter(string name, int arbeitsTyp, int arbeitsstunden)
        {
            MitarbeiterID = null;   //when created in Program, no ID set as Database does that 
            Name = name;
            ArbeitsTypID = arbeitsTyp;
            ArbeitsStunden = arbeitsstunden;
        }

        public void AddToDatabase()
        {
            //TODO this would add the object to the database
        }

        public static Mitarbeiter? FindByID(int id)
        {
            foreach (var m in mockdataMitarbeiter)
            {
                if (m.MitarbeiterID == id) return new(m.Name, m.ArbeitsTypID, m.Arbeitsstunden);
            }
            return null;

        }




    }
}
