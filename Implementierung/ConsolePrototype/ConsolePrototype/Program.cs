using Microsoft.Data.Sql;
namespace ConsolePrototype
{
    internal class Program
    {
        enum ProgramState {Off, MainMenu, AddPersMenu, EditPersMenu, AddShiftMenu, EditShiftMenu}
        static void Main(string[] args)
        {
            ProgramState programState = ProgramState.MainMenu;
            string? UserEingabe;

            //Mainmenu
            while (programState == ProgramState.MainMenu)
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
                {
                    switch (UserEingabe)
                    {
                        case "1":
                            programState = ProgramState.MainMenu;
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
                }

            }
        }
    }
}
