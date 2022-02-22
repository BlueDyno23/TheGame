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
                    if (y == player.Y && x == player.X)
                    {
                        player.Draw();
                        Console.SetCursorPosition(player.lastX, player.lastY);
                        Console.BackgroundColor = Color.FromArgb(myWorld.GetColors(x, y)[0], myWorld.GetColors(x, y)[1], myWorld.GetColors(x, y)[2]);
                        Console.Write(" ");

                        Console.ResetColor();
                        System.Console.ResetColor();

                        Console.SetCursorPosition(0, 40);
                        Console.WriteLine($"R:{myWorld.GetColors(x,y)[0]}\tG:{myWorld.GetColors(x, y)[1]}\tB:{myWorld.GetColors(x, y)[2]}");
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
                if(HandlePlayerInput())
                {
                    AdvancedPlayerDraw();
                }
            }
            
        }
    }
}
