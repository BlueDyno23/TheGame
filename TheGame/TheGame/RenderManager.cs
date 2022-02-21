using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    class RenderManager
    {
        Player myPlayer;
        World myWorld;

        public RenderManager()
        {
            myPlayer = new Player(50,50);
            myWorld = new World();
        }

        public void DrawFrameBasic()
        {
            Console.Clear();
            myWorld.Draw();
            myPlayer.Draw();
        }

        public static void Render()
        {
            
        }
    }
}
