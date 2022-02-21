using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int lastX;
        public int lastY;
        private string playerMarker;
        private ConsoleColor playerColor;

        public Player(int initialX, int initialY)
        {
            X = initialX;
            Y = initialY;
            playerMarker = "O";
            playerColor = ConsoleColor.Red;
        }

        public void Draw()
        {
            Console.ForegroundColor = playerColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(playerMarker);
            Console.ResetColor();
        }
    }
}
