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
        string[,,] Grid;
        int Rows;
        int Cols;

        public World(string[,,] grid)
        {
            Grid = grid;
            Rows = Grid.GetLength(0);
            Cols = Grid.GetLength(1);
        }

        public World()
        {
            Grid = ImportMaps();
            Rows = Grid.GetLength(0);
            Cols = Grid.GetLength(1);
        }

        public void Draw()
        {
            Grid = ImportMaps();
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Cols; x++)
                {
                    string element = GetElement(x, y, 1);
                    switch (element)
                    {
                        case "1":
                            Console.BackgroundColor = ConsoleColor.Green;
                            break;
                        case "2":
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            break;
                        case "3":
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            break;
                    }
                    Console.Write(Grid[y,x,0]);
                    Console.ResetColor();
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

        private string[,,] ImportMaps()
        {
            string path = "C:\\development\\BigProject\\TheGame\\TheGame\\Maps";
            string first = File.ReadAllLines(Directory.GetFiles(path)[0])[0];
            int rows = File.ReadAllLines(Directory.GetFiles(path)[0]).Length;
            int cols = first.Length;

            string[,,] grids = new string[rows, cols, 3];

            for (int d = 0; d < Directory.GetFiles(path).Count(); d++)
            {
                for (int y = 0; y < rows; y++)
                {
                    string line = File.ReadAllLines(Directory.GetFiles(path)[d])[y];
                    for (int x = 0; x < cols; x++)
                    {
                        grids[y, x, d] = line[x].ToString();
                    }
                }
            }
            return grids;
        }

        public string GetElement(int x, int y,int d)
        {
            return Grid[y,x,d];
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

            return Grid[y, x,0] == " ";  
        }
    }
}
