using Microsoft.Data.Sql;
namespace ConsolePrototype
{
    internal class Program
    {
        enum ProgramState { Off, MainMenu, AddPersMenu, EditPersMenu, AddShiftMenu, EditShiftMenu }

        static void Main(string[] args)
        {
            ProgramState programState = ProgramState.MainMenu;
            string? UserEingabe;

            //Mainmenu
            while (true)
            {
                switch (programState)
                {
                    case ProgramState.MainMenu:
                        {
                            Console.Clear();
                            Console.WriteLine("Yo! This is a short Explanation of what the f this thing does!!");
                            Console.WriteLine("1: Personal Hinzufügen");
                            Console.WriteLine("2: Personal Bearbeiten");
                            Console.WriteLine("3: Dinstplan Hinzufügen");
                            Console.WriteLine("4: Dinstplan Bearbeiten");
                            Console.WriteLine("5: Programm beenden");
                            Console.Write("Eingabe:");
                            UserEingabe = Console.ReadLine();
                            Console.Clear();
                            switch (UserEingabe)
                            {
                                case "1":
                                    programState = ProgramState.AddPersMenu;
                                    break;
                                case "2":
                                    programState = ProgramState.AddPersMenu;
                                    break;
                                case "5":
                                    programState = ProgramState.Off;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.Write("Faulty Input Error. Return with Enter");
                                    Console.ReadLine();
                                    break;
                            }

                            break;
                        }

                    //Add Person Menu
                    case ProgramState.AddPersMenu:
                        {
                            Console.Clear();
                            Console.Write("Name der Person:");
                            string? name = Console.ReadLine();


                            int? WorkTypeID = null;
                            while (WorkTypeID is null)
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

                                try
                                {
                                    WorkTypeID = Convert.ToInt32(eingabe);
                                }
                                catch (Exception e)
                                {
                                    Console.Clear();
                                    Console.Write("Faulty Input Error. Return with Enter");
                                    Console.ReadLine();
                                }
                            }
                            int? ArbeitsStunden = null;
                            while (ArbeitsStunden is null)
                            {
                                Console.Clear();
                                Console.Write("Anzahl Wochenstunden:");
                                string? eingabe = Console.ReadLine();

                                try { ArbeitsStunden = Convert.ToInt32(eingabe); }
                                catch (Exception e)
                                {
                                    Console.Clear();
                                    Console.Write("Faulty Input Error. Return with Enter");
                                    Console.ReadLine();
                                }
                            }
                            programState = ProgramState.MainMenu;
                            break;
                        }

                }
            }
        }
    }
}
