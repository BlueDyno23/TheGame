using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Console = Colorful.Console;
using System.Drawing;

namespace TheGame
{
    public class Game
    {
        private World myWorld;
        private Player player;
        //private RenderManager renderManager;

        public void Start()
        {
            myWorld = new World();
            player = new Player(10,10);
            //renderManager = new RenderManager();

            RunGameLoop();
        }

        private void AdvancedPlayerDraw()
        {
            
            for (int y = 0; y < myWorld.GridSize()[0]; y++)
            {
                for (int x = 0; x < myWorld.GridSize()[1]; x++)
                {
                    
                    /* reminder: everything in there only executes when the player walks on the block
                      this function only draws the player and fixes player related drawing bugs
                      this function DOES NOT DRAW THE MAP (although it could)
                    */
                    if (y == player.Y && x == player.X)
                    {
                        //getting the color
                        Color color = Color.FromArgb(myWorld.GetColors(x, y)[0], myWorld.GetColors(x, y)[1], myWorld.GetColors(x, y)[2]);
                        Color lastColor = Color.FromArgb(myWorld.GetColors(player.lastX, player.lastY)[0], myWorld.GetColors(player.lastX, player.lastY)[1], myWorld.GetColors(player.lastX, player.lastY)[2]);

                        //drawing the player
                        Console.SetCursorPosition(x, y);
                        player.Draw(color);

                        //resetting player's trail
                        Console.SetCursorPosition(player.lastX, player.lastY);
                        Console.BackgroundColor = lastColor;
                        Console.Write(" ");

                        //resetting the colors in the background
                        Console.SetCursorPosition(x,y);
                        Console.BackgroundColor = color;

                        //making double sure that the colors are reset to not affect the entire screen
                        Console.ResetColor();
                        System.Console.ResetColor();

                        //debug
                        Console.SetCursorPosition(0, 40);
                        Console.ForegroundColor = Color.FromArgb(35,35,35);

                        Console.WriteLine("DEBUG INFO:\n");
                        Console.WriteLine($"R:{myWorld.GetColors(x,y)[0]}\tG:{myWorld.GetColors(x, y)[1]}\tB:{myWorld.GetColors(x, y)[2]}");
                        Console.WriteLine($"X: {player.X}\tY:{player.Y}");
                        Console.WriteLine($"PATH: {Directory.GetCurrentDirectory()}");
                        Console.WriteLine($"WINDOW HEIGHT: {Console.WindowHeight}");
                        Console.WriteLine($"WINDOW HEIGHT: {Console.WindowHeight}");

                        Console.ResetColor();
                        
                    }
                }
            }
        }

        private void AdvancedMapDraw()
        {
            for (int y = 0; y < myWorld.ActiveGridSize()[0]; y++)
            {
                for (int x = 0; x < myWorld.ActiveGridSize()[1]; x++)
                {

                    Console.SetCursorPosition(0, 40);
                    Console.WriteLine($"CX:{player.X}\tCY:{player.Y}\nLX:{player.lastX}\tLY:{player.lastY}");

                }
            }
        }
        private void DrawFrame()
        {
            Console.Clear();
            myWorld.Draw();
            //player.Draw();
        }

        private bool HandlePlayerInput()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            ConsoleKey key = keyInfo.Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if(myWorld.isNonCollidable(player.X,player.Y-1))
                    {
                        player.lastY = player.Y;
                        player.lastX = player.X;
                        player.Y -= 1;
                        return true;
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (myWorld.isNonCollidable(player.X, player.Y + 1))
                    {
                        player.lastY = player.Y;
                        player.lastX = player.X;
                        player.Y += 1;
                        return true;
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if (myWorld.isNonCollidable(player.X+1, player.Y))
                    {
                        player.lastY = player.Y;
                        player.lastX = player.X;
                        player.X += 1;
                        return true;
                    } 
                    break;

                case ConsoleKey.LeftArrow:
                    if (myWorld.isNonCollidable(player.X-1, player.Y))
                    {
                        player.lastY = player.Y;
                        player.lastX = player.X;
                        player.X -= 1;
                        return true;
                    }
                    break;

                default:
                    return false;
                    break;
            }
            return false;
        }

        private void RunGameLoop()
        {
            myWorld.Draw();
            while (true)
            {
                Console.CursorVisible = false;
                if(HandlePlayerInput())
                {
                    AdvancedPlayerDraw();
                }
            }
            
        }
    }
}
