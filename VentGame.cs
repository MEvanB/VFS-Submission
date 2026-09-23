using System;
using System.Threading;

namespace VentGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Renderer scene = new Renderer();
            GameLogic player = new GameLogic();

            player.calculateDirection(); //starting direction.


            while (player.alive == true)
            {
                if (player.monsterActivity >= player.monsterDEATHVALUE) 
                {
                    player.alive = false;
                    Console.Clear();
                    scene.failScreen();

                    Console.ForegroundColor = ConsoleColor.DarkRed;

                    Console.WriteLine();
                    Console.Beep(250, 100);
                    Thread.Sleep(1000);
                    Console.WriteLine($"- You survived {player.gameTime} seconds");
                    Console.Beep(250, 100);
                    Thread.Sleep(1000);
                    Console.WriteLine($"- unsightly");
                    Console.Beep(250, 100);
                    Thread.Sleep(1000);
                    Console.WriteLine($"- {player.predeterminedDeath} missing bones");
                    Console.Beep(250, 100);
                    Environment.Exit(0);

                }
                scene.timeCounter(player);

                player.gameTime++;
                player.calculateDirection();
                scene.facingDirection(player);

                player.checkifventEmpty();
                player.monsterActivityEVENT();

                //Console.Beep(2000, 10);

                //scene.facingDirection(player);
                

                
                scene.gameInputManager(player); 
                

                if (player.flashlightOn == true)
                {
                    player.batteryLife--;
                    //Console.Beep(100, 200);
                }

                //vent rendering
               
                if (player.flashlightOn == false)
                {
                    scene.ventNotFlashed(player);
                    scene.flashlightOFF(player);
                }
                else if (player.flashlightOn == true && player.ventEmpty)
                {
                    scene.ventFlashedEmpty(player);
                    scene.flashlightON(player);
                }
                else if (player.flashlightOn == true && !player.ventEmpty)
                {
                    /////////////////////////////////////////////////////////////////////////////// //ventFARAWAY //ventMIDRANGE //ventUPCLOSE
                    if (player.monsterActivity <= player.monsterDEATHVALUE /3) //if 10, then 3.33
                    {
                        scene.ventFlashedOccupiedFARAWAY(player);
                        

                    }
                    else if (player.monsterActivity >= player.monsterDEATHVALUE /3 && player.monsterActivity <= player.monsterDEATHVALUE /3 * 2) // if 10 then 6.66
                    {
                        scene.ventFlashOccupiedMIDRANGE(player);
                        
                    }
                    else if (player.monsterActivity > player.monsterDEATHVALUE /3 * 2)
                    {
                        scene.ventFlashedOccupiedUPCLOSE(player);
                        
                    }
                    
                    scene.flashlightON(player);
                }

                
                
                


                Thread.Sleep(1000); // Simulate game loop delay
                

                scene.clearRender();
                
            }
            


           
            

            //scene.turningLeft();
            //scene.turningRight();   



            

           

        }
    }

    class GameLogic
    {
        public int gameTime = 0;
        public int predeterminedDeath = new Random().Next(36, 197);

        public string audibleSound = "";

        public int batteryLife = 100;
        public bool alive = true; 
        public int directionValue = 0; //0 = front, 1 = left, 2 = right, 3 = back

        public bool flashlightOn = false; //determins if render should start with vent flashed or not
        public bool ventEmpty = true; //if monster is in vent or not.

        public string lookingDirection = "Front";



        public bool monsterActive = false;
        public int monsterActivity = 0;
        public int monsterInactivity = 0;
        public int monsterDEATHVALUE = new Random().Next(9, 15);
        public int currentMonsterLane = new Random().Next(0, 3);
        // 0 = front, 1 = left, 2 = back, 3 = right


        //only if we want states of monster being inactive, there will be some number it goes up to while inactive before it is active again. 
        //public bool monsterActive = true;
        //public int monsterInactiveMAXTime = 0; time while inactive it will have to wait before becoming active again

        public void calculateDirection()
        {
            if (directionValue == 0)
            {
                lookingDirection = "FRONT";
                
            }
            else if (directionValue == 1)
            {
                lookingDirection = "LEFT";
            }
            else if (directionValue == 2)
            {
                lookingDirection = "BACK";
            }
            else if (directionValue == 3)
            {
                lookingDirection = "RIGHT";
            }
        }

        
      
           
         public void checkifventEmpty()
         {
                if (currentMonsterLane == directionValue && monsterActive == true)
                {
                    ventEmpty = false;
                }
                else if (currentMonsterLane != directionValue || monsterActive == false)
                {
                    ventEmpty = true;
                }
         }

          public void monsterActivityEVENT()
          {
                if (flashlightOn && currentMonsterLane == directionValue && monsterActive == true) //Scaring off the monster
                {
                   monsterActive = false;
                   monsterInactivity = 0;
                   monsterActivity = 0;
                   currentMonsterLane = new Random().Next(0, 3); //randomly select a new lane for the monster to be in.
                   monsterDEATHVALUE = new Random().Next(15, 35); //randomly select a new death value for monster   //was 10, 30 before.
                                                                 //Should gain battery here for sacring off the monster - capping at 100, + maybe score
                    
                    batteryLife = Math.Min(batteryLife + 3, 100);
                }
                if (!monsterActive && monsterInactivity >= new Random().Next(10, 20))
                {
                    
                    monsterActive = true;
                    //audibleSound = "*You hear rustling";
                }
            if (!monsterActive)
            {
                monsterInactivity++;
                //audibleSound = "";
            }
            else if (monsterActive)
            {
                if (monsterActivity > 0)
                {
                    //audibleSound = "*You hear clammering in the vents";
                }
                monsterActivity++;

            }

            //monster patience will be how long until it becomes active again, while monster activity or agro will be its progression into the next stage
          }
        
       

    }

    
   

    class Renderer 
    {
        
        public void clearRender()
        {
            Console.Clear();
        }

        public void resetColor()
        {
            Console.ResetColor(); //maybe include in clearRender, maybe not.
        }
        public void changeColorDARKGRAY()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }
        public void changeColorWHITE()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void changeColorDARKRED()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
        }
        public void changeColorYELLOW()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        public void audioPLAYER(GameLogic playerPOV)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine($"{playerPOV.audibleSound}");
            Console.ResetColor();
        }

        public void ventNotFlashed(GameLogic playerPOV) 
        {
            Console.WriteLine($"{playerPOV.directionValue}-----------------------{playerPOV.directionValue}");
            Console.WriteLine("|#######################|");
            Console.WriteLine("|#######################|");
            Console.WriteLine("|#######################|");
            Console.WriteLine("|#######################|");
            Console.WriteLine("|#######################|");
            Console.WriteLine("|#######################|");
            Console.WriteLine($"{playerPOV.directionValue}-----------------------{playerPOV.directionValue}");
        }
        public void ventFlashedEmpty(GameLogic playerPOV)
        {
            Console.WriteLine($"{playerPOV.directionValue}-----------------------{playerPOV.directionValue}");
            Console.WriteLine("|######-----------######|");
            Console.WriteLine("|####| ----------- |####|");
            Console.WriteLine("|### | |  -----  | | ###|");
            Console.WriteLine("|### | | |     | | | ###|");
            Console.WriteLine("|####| | |     | | |####|");
            Console.WriteLine("|######-----------######|");
            Console.WriteLine($"{playerPOV.directionValue}-----------------------{playerPOV.directionValue}");
        }
        public void ventFlashedOccupiedFARAWAY(GameLogic playerPOV)
        {
            Console.WriteLine($"{playerPOV.directionValue}-----------------------{playerPOV.directionValue}");
            Console.WriteLine("|######-----------######|");
            Console.WriteLine("|####| ----------- |####|");
            Console.WriteLine("|### | |  -----  | | ###|");
            Console.WriteLine("|### | | |   . | | | ###|");
            Console.WriteLine("|####| | |  .  | | |####|");
            Console.WriteLine("|######-----------######|");
            Console.WriteLine($"{playerPOV.directionValue}-----------------------{playerPOV.directionValue}");
        }

        public void ventFlashOccupiedMIDRANGE(GameLogic playerPOV)
        {
            Console.WriteLine($"{playerPOV.directionValue}-----------------------{playerPOV.directionValue}");
            Console.WriteLine("|######-----------######|");
            Console.WriteLine("|####| ----------- |####|");
            Console.WriteLine("|### | | o       | | ###|");
            Console.WriteLine("|### | |   || o  | | ###|");
            Console.WriteLine("|####| |  |||    | |####|");
            Console.WriteLine("|######-----------######|");
            Console.WriteLine($"{playerPOV.directionValue}-----------------------{playerPOV.directionValue}");
        }

        public void ventFlashedOccupiedUPCLOSE(GameLogic playerPOV)
        {
            Console.WriteLine($"{playerPOV.directionValue}-----------------------{playerPOV.directionValue}");
            Console.WriteLine("|###### o         ######|");
            Console.WriteLine("|####          O    ####|");
            Console.WriteLine("|###   ||||          ###|");
            Console.WriteLine("|###    -            ###|");
            Console.WriteLine("|####     ||||      ####|");
            Console.WriteLine("|######           ######|");
            Console.WriteLine($"{playerPOV.directionValue}-----------------------{playerPOV.directionValue}");
        }

        public void turningLeft() 
        {
            Console.WriteLine("            <- ---- -- -- - -");
            
            Console.WriteLine("    ///////");
            Console.WriteLine("////////////////////////");
            Console.WriteLine(" //////////////");
            Console.WriteLine("    ///////////////");
            Console.WriteLine("    //////   ");
            Console.WriteLine(" <- ---- -- -- - -");

        }

        public void turningRight()
        {
            Console.WriteLine(@" - - -- -- ---- ->");

            Console.WriteLine(@"              \\   \\\\ ");
            Console.WriteLine(@"\\\\\\\\\\\\\\\\\\\\\\\\");
            Console.WriteLine(@"            \\ \\\\\\\\\");
            Console.WriteLine(@"        \\\\\\\\\\\\\");
            Console.WriteLine(@"     \\\\\\\");
            Console.WriteLine(@"          - - -- -- ---- ->");
        }

        public void failScreen() 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("* YOU HAVE MET AN UNFORTUNATE END *");
            Console.WriteLine();
            Console.WriteLine("         x");
            Console.WriteLine("        xXx   x              x");
            Console.WriteLine("       xXXx  xx             xXx");
            Console.WriteLine("      xXXXx  xx  x    xx   xXXXx");
            Console.WriteLine("     xXXXXxxxxx  xx   xx  xXXXXXx");
            Console.WriteLine("     xXXXXXXXXXxxxxxx xXx XXXXXXx");
            Console.WriteLine("     xXXXXXXXXXXXXXXXXXXX XXXXXXx");
            Console.WriteLine("       xXXXXXxx xXXXXXXXX  xxxxX");
            Console.WriteLine("        xxxx      xXXXXXx      xxx");
            Console.WriteLine("                   xXXXx       ");
            Console.WriteLine("          x          XXx     xxxx");
            Console.WriteLine("          xxx x XX  XXXXXxxXXXXx");
            Console.WriteLine("          xxXXXXXx    XXXXXXXXX");
            Console.WriteLine("	     xxxx      xXXXXX");
            Console.WriteLine("                  x   xXXXx");
            Console.WriteLine("                 xx   xxx");
            Console.ResetColor();

            

        }

        public void flashlightON(GameLogic flashlight) 
        {
           Console.WriteLine(@"        \       /");
           Console.WriteLine(@"         \     / ");
           Console.WriteLine(@"          \   /  ");
           Console.WriteLine(@"           \ / ");
            //Console.WriteLine(@"");

            Console.WriteLine("          [___]");
            Console.WriteLine("           | |");
            Console.Write    ("           |0|"); Console.WriteLine($"   ({flashlight.batteryLife}%)");
            Console.WriteLine("           | |");
            Console.WriteLine("           |_|");
        }

        public void flashlightOFF(GameLogic flashlight) 
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            //Console.WriteLine();

            Console.WriteLine("          [___]");
            Console.WriteLine("           | |");
            Console.Write    ("           |O|"); Console.WriteLine($"   ({flashlight.batteryLife}%)");
            Console.WriteLine("           | |");
            Console.WriteLine("           |_|");
        }

        
        public void facingDirection(GameLogic gamePlayer) 
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"    *{gamePlayer.lookingDirection} VENT          ");
            //Console.WriteLine($"{gamePlayer.currentMonsterLane}");
            //Console.WriteLine($"{gamePlayer.monsterActive}");
            //Console.WriteLine($"{gamePlayer.monsterInactivity}");
            //Console.WriteLine($"{gamePlayer.monsterActivity}");
            //Console.WriteLine($"{gamePlayer.monsterDEATHVALUE}"); 

            Console.ResetColor();
        }

        public void timeCounter(GameLogic gamePlayer)
        {
            Console.WriteLine("Controls = [F] Flashlight, [Left Arrow] Turn Left");
            Console.WriteLine($"    TIME: {gamePlayer.gameTime}"); 
        }

        
        
        public void gameInputManager(GameLogic gamePlayer)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                flashlightInputCheck(gamePlayer, key);
                turningInputCheck(gamePlayer, key);
            }
        }



        public void flashlightInputCheck(GameLogic gamePlayer, ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.F)
            {
                    if (gamePlayer.flashlightOn)
                    {
                        gamePlayer.flashlightOn = false;
                    }
                    else if (!gamePlayer.flashlightOn && gamePlayer.batteryLife > 0)
                    {
                        gamePlayer.flashlightOn = true;
                    }
                    
                
            }
        }
        public void turningInputCheck(GameLogic gamePlayer, ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.LeftArrow)
            {
                
                    //Set turning/actively turning to true, then also in initial code have if condition for normal scene to also be if not turning, if is turning then go through turning animation.?
                    if (gamePlayer.directionValue >= 0 && gamePlayer.directionValue < 3)
                    {
                        if (gamePlayer.flashlightOn == true)
                        {
                            gamePlayer.flashlightOn = false;
                            flashlightPenalty(gamePlayer);
                        }
                        gamePlayer.directionValue++;
                    }
                    else if (gamePlayer.directionValue >= 3)
                    {
                        if (gamePlayer.flashlightOn == true)
                        {
                            gamePlayer.flashlightOn = false;
                            flashlightPenalty(gamePlayer);
                    }
                    gamePlayer.directionValue = 0;
                    }
                
            }
        }

        //Penalty for turning while flashlight is on
        public void flashlightPenalty(GameLogic gamePlayer) 
        {
            if (gamePlayer.batteryLife >= 10)
            {
                gamePlayer.batteryLife = gamePlayer.batteryLife - 5;
            }
            else if (gamePlayer.batteryLife < 10)
            {
                gamePlayer.batteryLife = 0;
                gamePlayer.flashlightOn = false;
            }

        }

    }
}

