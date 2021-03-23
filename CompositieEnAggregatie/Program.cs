using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositieEnAggregatie
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> Oefeningen = new List<string>();
            Console.OutputEncoding = Encoding.UTF8; // voor de euro sign
            Oefeningen = new List<string>();
            Oefeningen.Add("Exit");
            Oefeningen.Add("UML Diagrammen");
            Oefeningen.Add("Politiek");
            Oefeningen.Add("Moederbord");
            Oefeningen.Add("Een eigen huis");
            //Oefeningen.Add("RPG");

            bool bExit = false;
            while (!bExit)
            {
                Console.Clear();
                Console.WriteLine("Overerving oefeningen:\n");
                switch (SelectMenu(false, Oefeningen.ToArray()) - 1)
                {
                    case 0: bExit = true; break;
                    case 1: UMLDiagrammen(); break;
                    case 2: Politiek(); break;
                    case 3: Moederbord(); break;
                    case 4: EenEigenHuis(); break;
                    //case 5: RPG(); break;

                    default:
                        break;
                }
            }

            void UMLDiagrammen()
            {
                Console.Clear();
                Console.WriteLine("UML Diagrammen:");
                Console.WriteLine("-> Bekijk klassen Persoon & Engine voor de opbouw voor deze oefening");
                Console.ReadKey();
            }
            void Politiek()
            {
                Console.Clear();
                Console.WriteLine("Politiek (was het maar zo eenvoudig):");

                List<Minister> ministers = new List<Minister>();
                ministers.Add(new Minister("Minister 1"));
                ministers.Add(new Minister("Minister 2"));
                ministers.Add(new Minister("Minister 3"));
                ministers.Add(new Minister("Minister 4"));
                ministers.Add(new Minister("Minister 5"));
                ministers.Add(new Minister("Minister 6"));
                President newPresident = new President("President");
                Land belgium = new Land("Belgium");
                belgium.MaakRegering(newPresident, ministers);

                Console.WriteLine("Huidige president");
                Console.WriteLine(belgium.President.Naam); 
                Console.WriteLine("Huidige Eerste minister:");
                Console.WriteLine(belgium.EersteMinister.Naam);
                Console.WriteLine("Huidige ministers");
                foreach (Minister minister in belgium.ministers)
                    Console.WriteLine(belgium.ministers.IndexOf(minister) + 1 + ": " + minister.Naam);
                Console.ReadKey();
            }

            void Moederbord()
            {
                Moederbord Z390E_Gaming = new Moederbord();
                Ram ddr3 = new Ram("DDR 3");
                AGP agp = new AGP("GeForce 2");
                USB muis = new USB("Logitech muis");
                USB toetsenbord = new USB("Logitech toetsenbord");
                PCI geluidskaart = new PCI("Creative");
                Z390E_Gaming.cpu = new CPU("Intel");
                Z390E_Gaming.VoegRamToe(ddr3);
                Z390E_Gaming.VoegRamToe(ddr3);
                Z390E_Gaming.VoegRamToe(ddr3);
                Z390E_Gaming.VoegAGPToe(agp);
                Z390E_Gaming.VoegUSBToe(muis);
                Z390E_Gaming.VoegUSBToe(toetsenbord);
                Z390E_Gaming.VoegPCIToe(geluidskaart);
                Z390E_Gaming.TestMoederbord();

                Console.ReadKey();


            }

            void EenEigenHuis()
            {
                List<Kamer> mijnKamers = new List<Kamer>();
                mijnKamers.Add(new Badkamer("badkamer",40));
                mijnKamers.Add(new Salon("Salon",50));
                mijnKamers.Add(new Kamer("Slaapkamer 1", 30));
                mijnKamers.Add(new Kamer("Slaapkamer 2", 20));
                mijnKamers.Add(new Gang("Gang 1", 30));
                mijnKamers.Add(new Gang("Gang 2", 10));
                Huis mijnHuis = new Huis(mijnKamers);
                Console.WriteLine("\tHuis bevat volgende kamers:\n");
                Console.WriteLine(string.Format("\t{0,-7} {1,-5}: {2,-16} {3,3} {4,-5}","Klassen","Index","Naam","Opp.","Prijs"));
                foreach (Kamer kamer in mijnHuis.Kamers)
                {
                    string[] type = kamer.GetType().ToString().Split('.');
                    string msg = string.Format( "\t{4,-10} {0,2}: {1,-15} {2,3}m² {3,-5:0.0}€"
                                                , mijnHuis.Kamers.IndexOf(kamer) + 1, kamer.Naam, kamer.Oppervlakte,kamer.Prijs,type[1]);
                    Console.WriteLine(msg);
                    
                }
                Console.WriteLine(string.Format("\t{0,35}:{1,6:0.0}€", "Totaal prijs", mijnHuis.BerekenPrijs()));
                Console.ReadKey();

            }

            void RPG()
            {
                Character player = new Character();
                player.Hp_base = 100;
                player.Gewicht = 0;
                player.Naam = "Player";
                //player.
            }

            int SelectMenu(bool clearScreen = true, params string[] menu)
            {
                int selection = 1;
                int cursTop = Console.CursorTop;
                int cursLeft = Console.CursorLeft;
                bool selected = false;
                ConsoleColor selectionForeground = Console.BackgroundColor;
                ConsoleColor selectionBackground = Console.ForegroundColor;

                if (clearScreen)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.Clear();
                }
                else
                {
                    cursTop = Console.CursorTop;
                    cursLeft = Console.CursorLeft;
                    Console.SetCursorPosition(cursLeft, cursTop);
                }
                Console.CursorVisible = false;

                while (!selected)
                {
                    for (int i = 0; i < menu.Length; i++)
                    {
                        if (selection == i + 1)
                        {
                            Console.ForegroundColor = selectionForeground;
                            Console.BackgroundColor = selectionBackground;
                        }
                        Console.WriteLine(string.Format("{0,5}:{1,-40}", i + 1, menu[i]));
                        Console.ResetColor();
                    }
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.UpArrow:
                            selection--;
                            break;
                        case ConsoleKey.DownArrow:
                            selection++;
                            break;
                        case ConsoleKey.Enter:
                            selected = true;
                            break;
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1: selection = 1; break;
                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2: selection = 2; break;
                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3: selection = 3 <= menu.Length ? 3 : menu.Length; break;
                        case ConsoleKey.D4:
                        case ConsoleKey.NumPad4: selection = 4 <= menu.Length ? 4 : menu.Length; break;
                    }
                    selection = Math.Min(Math.Max(selection, 1), menu.Length);
                    if (clearScreen)
                        Console.SetCursorPosition(0, 0);
                    else Console.SetCursorPosition(cursLeft, cursTop);
                }
                Console.Clear();
                Console.CursorVisible = true;
                return selection;
            }
            string InputStrFormat(string inputFormat = "  :    :    :", int fixedLength = 14, char charStart = '0', char charEnd = '9')
            {
                string toReturn = inputFormat;
                bool exit = false;
                int cursX = Console.CursorLeft;
                int cursY = Console.CursorTop;
                int count = 0;

                foreach (char c in toReturn)
                {
                    if (c == ' ')
                    {

                    }
                }
                while ((toReturn.Length < fixedLength) && (!exit))
                {
                    Console.CursorLeft = cursX;
                    Console.CursorTop = cursY;
                    Console.WriteLine(toReturn, fixedLength);
                    char input = Console.ReadKey(true).KeyChar;
                    if ((input >= charStart) && (input <= charEnd))
                    {
                        //toReturn[0] = input;
                    }
                }

                return toReturn;
            }
            char InputChr(params string[] tekst)
            {
                for (int i = 0; i < tekst.GetLength(0); i++)
                    Console.WriteLine(tekst[i]);
                return Console.ReadKey(true).KeyChar;
            }
            string InputStr(params string[] tekst)
            {
                for (int i = 0; i < tekst.GetLength(0); i++)
                    if (tekst.GetLength(0) == 1) Console.Write(tekst[i]);
                    else Console.WriteLine(tekst[i]);
                return Console.ReadLine();
            }
            bool InputBool(string tekst = "j/n", bool Cyes = true, bool Cno = false)
            {
                Console.WriteLine(tekst);
                switch (Char.ToLower(Console.ReadKey(true).KeyChar))
                {
                    case 'y':
                    case 'j': return Cyes;
                    case 'n': return Cno;
                }
                return false;
            }
            int InputInt(string tekst = "Getal: ")
            {
                Console.Write(tekst);
                return int.Parse(Console.ReadLine());
            }
            double InputDbl(string tekst = "Getal: ")
            {
                Console.Write(tekst);
                return double.Parse(Console.ReadLine());
            }
        }
    }
}
