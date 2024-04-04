using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineStep
{
    public class AI
    {
        public string[,] Display { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string Icon { get; set; }
        public int[] bounds { get; set; }


        public AI(string[,] display, int x, int y, string icon, int[] bounds)
        {
            Display = display;
            X = x;
            Y = y;
            Icon = icon;
            this.bounds = bounds;
        }

        private string curTile()
        {
            return Display[X, Y];
        }

        public async Task Move()
        {


            //if (curTile() == "0")
            //{
            //    X++;
            //}
            //else
            //{
            //    // Ide kell az AI logika
            Random random = new Random();
            int direction = random.Next(4);

            //}

            switch (direction)
            {
                case 0:
                    Y--; // Felfelé mozgás
                    break;
                case 1:
                    X--; // Balra mozgás
                    break;
                case 2:
                    Y++; // Lefelé mozgás
                    break;
                case 3:
                    X++; // Jobbra mozgás
                    break;
            }

            if (X < 0 || X >= bounds[0] || Y < 0 || Y >= bounds[1])
            {
                // Ha kiment, akkor visszalép az előző pozícióba
                switch (direction)
                {
                    case 0:
                        Y++;
                        break;
                    case 1:
                        X++;
                        break;
                    case 2:
                        Y--;
                        break;
                    case 3:
                        X--;
                        break;
                }
            }
        }

        public void AIDispose()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\tYou won!");
            Console.ResetColor();
        }
    }
}
