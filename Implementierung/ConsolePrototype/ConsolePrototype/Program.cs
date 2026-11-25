using Microsoft.Data.Sql;
namespace ConsolePrototype
{
    internal class Program
    {
        enum ProgramState { Off, MainMenu, AddPersMenu, EditPersMenu, AddShiftMenu, EditShiftMenu }
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

                    //Add Person Menu
                    case ProgramState.AddPersMenu:
                        {
                            AddPersonMenuLogic();
                            break;
                        }

                    case ProgramState.AddShiftMenu:
                        {
                            AddShiftMenuLogic();
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
            Console.WriteLine("5: Programm beenden");
            Console.Write("Eingabe:");
            string? eingabe;
            eingabe = Console.ReadLine();
            Console.Clear();
            switch (eingabe)
            {
                case "1":
                    programState = ProgramState.AddPersMenu;
                    break;
                case "2":
                    break;
                case "3":
                    programState = ProgramState.AddShiftMenu;
                    break;
                case "4":
                    break;
                case "5":
                    programState = ProgramState.Off;
                    break;
                default:
                    Console.Clear();
                    Console.Write("Fehlerhafte Eingabe. Int erwartet");
                    Console.ReadLine();
                    break;
            }
        }

        static void AddPersonMenuLogic()
        {
            //read out Name
            Console.Clear();
            Console.Write("Name der Person:");
            string? name = Console.ReadLine();
            

            //read out WorkTypeID
            int? workTypeID = null;
            while (workTypeID is null)
            {
                Console.Clear();
                Console.WriteLine("Arbeit der Person:");
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
            //TODO add name, arbeitsTyp, arbeitsstunden into the Database, should add a new class for that
            programState = ProgramState.MainMenu;
        }

        static void AddShiftMenuLogic()
        {
            //read out Name
            Console.Clear();
            Console.Write("Benennen Sie die Schicht (z.B: Montag Morgen):");
            string? Name = Console.ReadLine();

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
                Console.WriteLine("Beginn der Schicht (hh.mm):");
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
            //TODO add name, date, beginnZeit, endZeit into the Database, should add a new class for that
            programState = ProgramState.MainMenu;

        }
    }
}
