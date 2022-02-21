using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
            player = new Player(1,1);
            //renderManager = new RenderManager();

            RunGameLoop();
        }

        private void AdvancedDraw()
        {
            for (int y = 0; y < myWorld.GridSizeY(); y++)
            {
                for (int x = 0; x < myWorld.GridSizeX(); x++)
                {
                    if(y == player.Y && x == player.X)
                    {
                        player.Draw();
                        Console.SetCursorPosition(player.lastX, player.lastY);
                        Console.Write(" ");

                        Console.SetCursorPosition(0, 40);
                        Console.WriteLine($"CX:{player.X}\tCY:{player.Y}\nLX:{player.lastX}\tLY:{player.lastY}");
                    }
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
                    AdvancedDraw();
                }
            }
            
        }
    }
}
