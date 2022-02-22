using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Colorful;
using System.Drawing;
using Console = Colorful.Console;

namespace TheGame
{
    public class World
    {
        string[,,] Grid;
        string[,,] activeGrid;
        int Rows;
        int Cols;
        private double r, g, b;

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
                    string redElement = GetElement(x, y, 1);
                    string greenElement = GetElement(x, y, 2);
                    string blueElement = GetElement(x, y, 3);

                    if (double.TryParse(redElement, out r))
                    {
                        r = r / 10;
                        r = r * 255;
                        
                    }
                    if (double.TryParse(greenElement, out g))
                    {
                        g = g / 10;
                        g = g * 255;
                    }
                    if (double.TryParse(blueElement, out b))
                    {
                        b = b / 10;
                        b = b * 255;
                    }

                    if (r != 0 || g != 0 || b != 0)
                    {
                        Colorful.Console.BackgroundColor = Color.FromArgb((int)r, (int)g, (int)b);
                    }

                    Console.Write(Grid[y, x, 0]);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        public void Draw(int x1, int y1,int x2, int y2)
        {
            Grid = ImportMaps();

            activeGrid = new string[(y2 - y1), (x2 - x1),4];

            for (int y = y1; y < (y2-y1); y++)
            {
                for (int x = x1; x < (x2-x1); x++)
                {
                    string redElement = GetElement(x, y, 1);
                    string greenElement = GetElement(x, y, 2);
                    string blueElement = GetElement(x, y, 3);

                    if (double.TryParse(redElement, out r))
                    {
                        r = r / 10;
                        r = r * 255;
                    }
                    if (double.TryParse(greenElement, out g))
                    {
                        g = g / 10;
                        g = g * 255;

                    }
                    if (double.TryParse(blueElement, out b))
                    {
                        b = b / 10;
                        b = b * 255;

                    }

                    if (r != 0 || g != 0 || b != 0)
                    {
                        Colorful.Console.BackgroundColor = Color.FromArgb((int)r, (int)g, (int)b);
                    }

                    activeGrid[y, x,0] = Grid[y,x,0];
                    Colorful.Console.Write(activeGrid[y, x, 0]);
                    Colorful.Console.ResetColor();
                }
                System.Console.WriteLine();
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

            string[,,] grids = new string[rows, cols, 4];

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
        public string GetActiveElement(int x, int y, int d)
        {
            return activeGrid[y, x, d];
        }

        public int[] GridSize()
        {
            int[] size = { Rows, Cols };
            return size;
        }

        public int[] ActiveGridSize()
        {
            int[] size = { activeGrid.GetLength(0),activeGrid.GetLength(1) };
            return size;
        }

        public int[] GetColors(int x, int y)
        {

            string redElement = GetElement(x, y, 1);
            string greenElement = GetElement(x, y, 2);
            string blueElement = GetElement(x, y, 3);


            double.TryParse(redElement, out r);
            r = r / 10;
            r = r * 255;



            double.TryParse(greenElement, out g);
            g = g / 10;
            g = g * 255;


            double.TryParse(blueElement, out b);
            b = b / 10;
            b = b * 255;



            int[] colors = { (int)r, (int)g, (int)b };
            return colors;
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
