using System.Reflection.Metadata.Ecma335;

namespace TreeProject
{
    internal class Program
    {
        static bool isYellow = true;
        static void Main(string[] args)
        {

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            
            Console.WriteLine("TYPE 1 for Pyramid");
            Console.WriteLine("-----");
            Console.WriteLine("Type 2 for Tree");
            Console.WriteLine("-----");
            Console.WriteLine("TYPE 3 for Christmas Tree");
            Console.WriteLine("-----");
            Console.WriteLine();
            Console.WriteLine("TYPE anything else to close program");
            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Black;

            SelectionScreen();




            static void SelectionScreen()
            {
                string typedResult = Console.ReadKey(true).KeyChar.ToString();
                Console.Clear();
                

                switch (typedResult) 
                {
                    case "1":
                        Pyramid();
                        break;
                    case "2":
                        Tree();
                        break;
                    case "3":
                        ChristmasTree();
                        break;
                    default:
                        Console.WriteLine("Press Anything to close program");
                        Environment.Exit(0);
                        break;
                    
                }

                

                
            }

            static void Pyramid() 
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.Clear();
                int length = 1;
                int maxLength = 0;
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkBlue;

                Console.WriteLine("Enter Value between 3-30 for Pyramid length");
                Console.WriteLine();
                Console.WriteLine("Alternatively, type anything else to return to menu");
                Console.WriteLine();
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Black;

                

                switch (int.TryParse(Console.ReadLine(), out maxLength))
                {
                    case true when maxLength >= 3 && maxLength <= 30:

                        
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Clear();

                        for (int i = maxLength - 1; i >= 0; i--) 
                        {
                            Console.Write(new string(' ', i));

                            Console.WriteLine(new string('-', length));
                            length = length + 2;
                            Console.Beep(100, 10);
                        }
                        ExitOrReturn();
                        break;
                    default:
                        Console.Clear();
                        System.Diagnostics.Process.Start(Environment.ProcessPath);
                        break;

                }
            }

            static void Tree()
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.Clear();
                int length = 1;
                int maxLength = 0;
                int trunkLength = 1;
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkMagenta;

                Console.WriteLine("Enter Value between 3-20 for the Tree length");
                Console.WriteLine();
                Console.WriteLine("Alternatively, type anything else to return to the menu");
                Console.WriteLine();
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Black;

                switch (int.TryParse(Console.ReadLine(), out maxLength)) 
                {
                    case true when maxLength >= 3 && maxLength <= 20:

                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Clear();

                        for (int i = maxLength - 1; i >= 0; i--) 
                        {
                            Console.BackgroundColor = ConsoleColor.DarkBlue;

                            Console.Write(new string(' ', i));

                            Console.BackgroundColor = ConsoleColor.Green;

                            Console.WriteLine(new string('-', length));
                            length = length + 2;

                            Console.Beep(100, 10); 
                        }

                        if (maxLength > 10 && maxLength <16)
                        {
                            trunkLength = 2;
                        }
                        else if (maxLength >= 16)
                        {
                            trunkLength = 3;
                        }
                        else
                        {
                            trunkLength = 1;
                        }

                        

                        for (int i = 0; i < trunkLength; i++)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write(new string(' ', length / 2 - 1));

                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("|");

                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Black;

                            Console.Beep(100, 10);
                        }

                        ExitOrReturn();

                        break;
                    default:
                        Console.Clear();
                        System.Diagnostics.Process.Start(Environment.ProcessPath);
                        break;
                }

            }

            static void ChristmasTree()
            {
                

                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Press anything to start");
                Console.ReadKey();
                Console.Clear();

                ChristmasTreeRenderer();

                
                Console.Beep(500, 400);
                ChristmasTreeRenderer();
                Console.Beep(330, 400);
                ChristmasTreeRenderer();
                Console.Beep(330, 200);
                ChristmasTreeRenderer();
                Console.Beep(370, 200);
                ChristmasTreeRenderer();
                Console.Beep(330, 200);
                ChristmasTreeRenderer();
                Console.Beep(310, 200);
                ChristmasTreeRenderer();
                Console.Beep(280, 400);
                ChristmasTreeRenderer();
                Console.Beep(280, 400);
                ChristmasTreeRenderer();

                Console.Beep(280, 400);
                ChristmasTreeRenderer();
                Console.Beep(370, 400);
                ChristmasTreeRenderer();
                Console.Beep(370, 200);
                ChristmasTreeRenderer();
                Console.Beep(420, 200);
                ChristmasTreeRenderer();
                Console.Beep(370, 200);
                ChristmasTreeRenderer();
                Console.Beep(330, 200);
                ChristmasTreeRenderer();
                Console.Beep(310, 400);
                ChristmasTreeRenderer();
                Console.Beep(310, 400);
                ChristmasTreeRenderer();

                Console.Beep(310, 400);
                ChristmasTreeRenderer();
                Console.Beep(420, 400);
                ChristmasTreeRenderer();
                Console.Beep(420, 200);
                ChristmasTreeRenderer();
                Console.Beep(440, 200);
                ChristmasTreeRenderer();
                Console.Beep(420, 200);
                ChristmasTreeRenderer();
                Console.Beep(370, 200);
                ChristmasTreeRenderer();
                Console.Beep(330, 400);
                ChristmasTreeRenderer();
                Console.Beep(280, 400);
                ChristmasTreeRenderer();

                Console.Beep(280, 200);
                ChristmasTreeRenderer();
                Console.Beep(280, 200);
                ChristmasTreeRenderer();
                Console.Beep(310, 400);
                ChristmasTreeRenderer();
                Console.Beep(370, 400);
                ChristmasTreeRenderer();
                Console.Beep(310, 400);
                ChristmasTreeRenderer();
                Console.Beep(330, 800);

                ExitOrReturn();
            }

            static void ChristmasTreeRenderer() 
            {
                
                Console.Clear();
                Console.WriteLine();

                AlternatingStarColor();
                Console.Write("          *");
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("         --"); RandomOrnamentColor(); Console.Write("o"); Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();

                Console.Write("        -"); RandomOrnamentColor(); Console.Write("o"); Console.ForegroundColor = ConsoleColor.Green; Console.Write("---");
                Console.WriteLine();

                Console.Write("       ---"); RandomOrnamentColor(); Console.Write("o"); Console.ForegroundColor = ConsoleColor.Green; Console.Write("-"); RandomOrnamentColor(); Console.Write("o"); Console.ForegroundColor = ConsoleColor.Green; Console.Write("-");
                Console.WriteLine();

                RandomOrnamentColor(); Console.Write("      o"); Console.ForegroundColor = ConsoleColor.Green; Console.Write("--"); RandomOrnamentColor(); Console.Write("o"); Console.ForegroundColor = ConsoleColor.Green; Console.Write("--"); RandomOrnamentColor(); Console.Write("o"); Console.ForegroundColor = ConsoleColor.Green; Console.Write("--");
                Console.WriteLine();

                Console.Write("     ------"); RandomOrnamentColor(); Console.Write("o"); Console.ForegroundColor = ConsoleColor.Green; Console.Write("--"); RandomOrnamentColor(); Console.Write("o"); Console.ForegroundColor = ConsoleColor.Green; Console.Write("-");
                Console.WriteLine();

                RandomOrnamentColor(); Console.Write("    o"); Console.ForegroundColor = ConsoleColor.Green; Console.Write("---"); RandomOrnamentColor(); Console.Write("o"); Console.ForegroundColor = ConsoleColor.Green; Console.Write("--"); RandomOrnamentColor(); Console.Write("o"); Console.ForegroundColor = ConsoleColor.Green; Console.Write("--"); RandomOrnamentColor(); Console.Write("o"); Console.ForegroundColor = ConsoleColor.Green; Console.Write("--");
                Console.WriteLine();

                Console.Write("   ---"); RandomOrnamentColor(); Console.Write("o"); Console.ForegroundColor = ConsoleColor.Green; Console.Write("--"); RandomOrnamentColor(); Console.Write("o"); Console.ForegroundColor = ConsoleColor.Green; Console.Write("---"); RandomOrnamentColor(); Console.Write("o"); Console.ForegroundColor = ConsoleColor.Green; Console.Write("----");
                Console.WriteLine();

                Console.Write("  -"); RandomOrnamentColor(); Console.Write("o"); Console.ForegroundColor = ConsoleColor.Green; Console.Write("--"); RandomOrnamentColor(); Console.Write("o"); Console.ForegroundColor = ConsoleColor.Green; Console.Write("--"); RandomOrnamentColor(); Console.Write("o"); Console.ForegroundColor = ConsoleColor.Green; Console.Write("--"); RandomOrnamentColor(); Console.Write("o"); Console.ForegroundColor = ConsoleColor.Green; Console.Write("----"); RandomOrnamentColor(); Console.Write("o"); Console.ForegroundColor = ConsoleColor.Green; Console.Write("-");
                Console.WriteLine();

                Console.Write(" -------------------");
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("          |           ");
                Console.WriteLine("          |           ");

                Console.ForegroundColor = ConsoleColor.White;

            }

            

            static void AlternatingStarColor()
            {
                

                if (isYellow)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    isYellow = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    isYellow = true;
                }
            }

            static void RandomOrnamentColor() 
            {
                Random random = new Random();
                int randomNumber = random.Next(1, 6);
                switch (randomNumber)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    default:
                        break;

                }

                
                
                
                
                
            }


            

            

            
            

            

            static void ExitOrReturn() 
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Press R to return to menu or anything else to close program");
                string typedResult = Console.ReadKey(true).KeyChar.ToString().ToLower();
                if (typedResult == "r")
                {
                    System.Diagnostics.Process.Start(Environment.ProcessPath);
                }
                
                else
                {
                    Environment.Exit(0);
                }
                
            }
        }
    }
}
