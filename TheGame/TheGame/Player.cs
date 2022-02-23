using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Colorful;
using Console = Colorful.Console;
using System.Drawing;

namespace TheGame
{
    class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int lastX;
        public int lastY;
        private string playerMarker;
        private Color playerColor;

        public Player(int initialX, int initialY)
        {
            X = initialX;
            Y = initialY;
            playerMarker = "O";
            playerColor = Color.FromArgb(250, 88, 182);
        }

        public void Draw()
        {
            Console.ForegroundColor = playerColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(playerMarker);
            Console.ResetColor();
        }

        public void Draw(Color background)
        {
            Console.ForegroundColor = playerColor;
            Console.BackgroundColor = background;
            Console.SetCursorPosition(X, Y);
            Console.Write(playerMarker);
            Console.ResetColor();
        }
    }
}
