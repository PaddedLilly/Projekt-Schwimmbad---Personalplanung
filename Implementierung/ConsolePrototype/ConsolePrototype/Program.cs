using Microsoft.Data.Sql;
namespace ConsolePrototype
{
    internal class Program
    {
        enum ProgramState { Off, MainMenu, AddMitarbeiterMenu, EditMitarbeitersMenu, AddShiftMenu, EditShiftMenu, AddMitarbeiterToShiftMenu }
        static ProgramState programState = ProgramState.MainMenu;

        
        static void Main(string[] args)
        {
            
            
            //Mainmenu
            while (true)
            {
                switch (programState)
                {
                    case ProgramState.MainMenu:
                        {
                            MainMenuLogic();
                            break;
                        }

                    case ProgramState.AddMitarbeiterMenu:
                        {
                            AddMitarbeiterMenuLogic();
                            break;
                        }

                    case ProgramState.AddShiftMenu:
                        {
                            AddShiftMenuLogic();
                            break;
                        }

                    case ProgramState.AddMitarbeiterToShiftMenu:
                        {
                            AddMitarbeiterToShiftMenu();
                            break;
                        }

                }
            }
        }

        static void MainMenuLogic(){
            Console.Clear();
            Console.WriteLine("Dieses Programm erlaubt das Erstellen und Bearbeiten von Schicht-Daten in der entsprechenden Datenbank");
            Console.WriteLine("Wählen Sie dazu eine der folgenen Optionen aus:");
            Console.WriteLine("1: Personal Hinzufügen");
            Console.WriteLine("2: Personal Bearbeiten");
            Console.WriteLine("3: Dinstplan Hinzufügen");
            Console.WriteLine("4: Dinstplan Bearbeiten");
            Console.WriteLine("5: Mitarbeiter zu Schicht zuweisen");
            Console.WriteLine("6: Programm beenden");
            Console.Write("Eingabe:");
            string? eingabe;
            eingabe = Console.ReadLine();
            Console.Clear();
            switch (eingabe)
            {
                case "1":
                    programState = ProgramState.AddMitarbeiterMenu;
                    break;
                case "2":
                    break;
                case "3":
                    programState = ProgramState.AddShiftMenu;
                    break;
                case "4":
                    break;
                case "5":
                    programState = ProgramState.AddMitarbeiterToShiftMenu;
                    break;
                case "6":
                    programState = ProgramState.Off;
                    break;
                default:
                    Console.Clear();
                    Console.Write("Fehlerhafte Eingabe. Int erwartet");
                    Console.ReadLine();
                    break;
            }
        }

        static void AddMitarbeiterMenuLogic()
        {
            //read out Name
            Console.Clear();
            Console.Write("Name des Mitarbeiters:");
            string? name = Console.ReadLine();
            

            //read out WorkTypeID
            int? workTypeID = null;
            while (workTypeID is null)
            {
                Console.Clear();
                Console.WriteLine("Arbeit des Mitarbeiters:");
                Console.WriteLine("1: Fachangestellte*r für Bäderbetriebe");
                Console.WriteLine("2: Verwaltung");
                Console.WriteLine("3: Empfang");
                Console.WriteLine("4: Reinigungsfachkraft");
                Console.WriteLine("5: Hausmeister");
                Console.Write("Eingabe:");
                string? eingabe = Console.ReadLine();

                try { workTypeID = Convert.ToInt32(eingabe); }
                catch (FormatException e)
                {
                    Console.Clear();
                    Console.Write("Fehlerhafte Eingabe. Int erwartet");
                    Console.ReadLine();
                }
            }
            //read out ArbeitsStunden
            int? arbeitsStunden = null;
            while (arbeitsStunden is null)
            {
                Console.Clear();
                Console.Write("Anzahl Wochenstunden:");
                string? eingabe = Console.ReadLine();

                try { arbeitsStunden = Convert.ToInt32(eingabe); }
                catch (FormatException e)
                {
                    Console.Clear();
                    Console.Write("Fehlerhafte Eingabe. Int erwartet");
                    Console.ReadLine();
                }
            }

            Mitarbeiter mitarbeiter = new(name, (int)workTypeID, (int)arbeitsStunden);
            mitarbeiter.AddToDatabase();

            programState = ProgramState.MainMenu;
        }

        static void AddShiftMenuLogic()
        {
            //read out Name
            Console.Clear();
            Console.Write("Benennen Sie die Schicht (z.B: Montag Morgen):");
            string? name = Console.ReadLine();

            //read out Date
            DateOnly? datum = null;
            while (datum is null)
            {
                Console.Clear();
                Console.WriteLine("Datum der Schicht (dd.MM.yyyy):");
                try {datum = DateOnly.Parse(Console.ReadLine());}
                catch (FormatException e)
                {
                    Console.Clear();
                    Console.Write("Fehlerhafte Eingabe.");
                    Console.ReadLine();
                }
            }

            //read out beginnZeit
            TimeOnly? beginnZeit = null;
            while (beginnZeit is null)
            {
                Console.Clear();
                Console.WriteLine("Beginn der Schicht (hh:mm):");
                try {beginnZeit = TimeOnly.Parse(Console.ReadLine());}
                catch (FormatException e)
                {
                    Console.Clear();
                    Console.Write("Fehlerhafte Eingabe.");
                    Console.ReadLine();
                }
            }

            //read out endZeit
            TimeOnly? endZeit = null;
            while (endZeit is null)
            {
                Console.Clear();
                Console.WriteLine("Beginn der Schicht (hh:mm):");
                try {endZeit = TimeOnly.Parse(Console.ReadLine());}
                catch (FormatException e)
                {
                    Console.Clear();
                    Console.Write("Fehlerhafte Eingabe.");
                    Console.ReadLine();
                }
            }

            //read out personalbedarf
            List<int> personalbedarf = new();
            string[] personaltypen = {"Fachangestellte für Bäderbetriebe","Verwaltungsfachkräfte","Arbeiter im Empfang","Reinigungsfachkräfte","Hausmeister"};
            foreach (string typ in personaltypen)
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine($"Wieviele {typ} werden benötigt?");

                    try
                    {
                        personalbedarf.Add(Convert.ToInt32(Console.ReadLine()));
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.Clear();
                        Console.Write("Fehlerhafte Eingabe. Int erwartet");
                        Console.ReadLine();
                    }
                }
            }
            Schicht schicht = new(name, (DateOnly)datum, (TimeOnly)beginnZeit, (TimeOnly)endZeit, personalbedarf);
            schicht.AddToDatabase();
            programState = ProgramState.MainMenu;
        }

        static void AddMitarbeiterToShiftMenu()
        {
            int? mitarbeiterID = null;
            while (mitarbeiterID == null)
            {
                Console.Clear();
                int counter = 1;
                foreach (object o in Mitarbeiter.mockdataMitarbeiter) 
                {
                    Console.WriteLine(Convert.ToString(counter++) + ": " + o);
                }
                Console.Write("Mitarbeiter Auswählen:");
            
                try
                {
                    mitarbeiterID = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.Write("Fehlerhafte Eingabe. Int erwartet");
                    Console.ReadLine();
                }
            }


            int? schichtID = null;
            while (schichtID == null)
            {
                Console.Clear();
                int counter = 1;
                foreach (object o in Schicht.mockdataSchicht)
                {
                    Console.WriteLine(Convert.ToString(counter++) + ": " + o);
                }
                Console.Write("Schicht Auswählen:");

                try
                {
                    schichtID = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.Write("Fehlerhafte Eingabe. Int erwartet");
                    Console.ReadLine();
                }
            }

            Schicht schicht = Schicht.FindByID((int)schichtID);
            Mitarbeiter mitarbeiter = Mitarbeiter.FindByID((int)mitarbeiterID);
            schicht.AddMitarbeiter(mitarbeiter);

            programState = ProgramState.MainMenu;
        }
    }
}
