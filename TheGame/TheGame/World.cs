using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TheGame
{
    public class World
    {
        string[,] Grid;
        int Rows;
        int Cols;

        public World(string[,] grid)
        {
            Grid = grid;
            Rows = Grid.GetLength(0);
            Cols = Grid.GetLength(1);
        }

        public World()
        {
            Grid = ImportMap();
            Rows = Grid.GetLength(0);
            Cols = Grid.GetLength(1);
        }

        public void Draw()
        {
            Grid = ImportMap();
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Cols; x++)
                {
                    Console.Write(Grid[y,x]);
                }
                Console.WriteLine();
            }
        }

        private string[,] ImportMap(string path = "SampleMap.txt")
        {
            string first = File.ReadAllLines(path)[0];
            int rows = File.ReadAllLines(path).Length;
            int cols = first.Length;

            string[,] grid = new string[rows, cols];

            for (int y = 0; y < rows; y++)
            {
                string line = File.ReadAllLines(path)[y];
                for (int x = 0; x < cols; x++)
                {
                    grid[y, x] = line[x].ToString();
                }
            }

            return grid;
        }

        public string GetElement(int x, int y)
        {
            return Grid[y,x];
        }

        public int GridSizeX()
        {
            return Cols;
        }
        public int GridSizeY()
        {
            return Rows;
        }

        public bool isNonCollidable(int x, int y)
        {
            if(y < 0 || x < 0 || y >= Rows || x >= Cols )
            {
                return false;
            }

            return Grid[y, x] == " ";  
        }
    }
}
