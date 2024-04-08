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

        private int[,] tiles;
        private Player player;
        private int maxWidth;
        private int maxHeight;

        public AI(string[,] display, int x, int y, string icon, int[] bounds, Player player, int maxWidth, int maxHeight, int[,] tiles)
        {
            Display = display;
            X = x;
            Y = y;
            Icon = icon;
            this.bounds = bounds;
            this.player = player;
            this.maxWidth = maxWidth;
            this.maxHeight = maxHeight;
            this.tiles = tiles;
        }

        private string curTile()
        {
            return Display[X, Y];
        }

        private bool IsValidMove(int x, int y, int maxWidth, int maxHeight, int[,] tiles)
        {
            return x >= 0 && x < maxWidth && y >= 0 && y < maxHeight && tiles[x, y] != -1;
        }

        public async Task Move(Player player, int maxWidth, int maxHeight, int[,] tiles)
        {


            //if (curTile() == "0")
            //{
            //    X++;
            //}
            //else
            //{
            //    // Ide kell az AI logika
            //}

            int targetX = 0;
            int targetY = 0;


            Random random = new Random();
            int randomD = random.Next(2);

            if (randomD == 0) // Vízszintes mozgás
            {
                if (Math.Abs(targetX - X) > Math.Abs(targetY - Y))
                {
                    if (targetX > X && IsValidMove(X + 1, Y, bounds[0], bounds[1], tiles))
                        X++;
                    else if (targetX < X && IsValidMove(X - 1, Y, bounds[0], bounds[1], tiles))
                        X--;
                }
                else
                {
                    if (targetY > Y && IsValidMove(X, Y + 1, bounds[0], bounds[1], tiles))
                        Y++;
                    else if (targetY < Y && IsValidMove(X, Y - 1, bounds[0], bounds[1], tiles))
                        Y--;
                }
            }
            else // Függőleges mozgás
            {
                if (Math.Abs(targetX - X) > Math.Abs(targetY - Y))
                {
                    if (targetY > Y && IsValidMove(X, Y + 1, bounds[0], bounds[1], tiles))
                        Y++;
                    else if (targetY < Y && IsValidMove(X, Y - 1, bounds[0], bounds[1], tiles))
                        Y--;
                }
                else
                {
                    if (targetX > X && IsValidMove(X + 1, Y, bounds[0], bounds[1], tiles))
                        X++;
                    else if (targetX < X && IsValidMove(X - 1, Y, bounds[0], bounds[1], tiles))
                        X--;
                }
            }
        }

        public void AIDispose() //Victory
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\tYou won!");
            Console.ResetColor();
        }
    }
}
