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

        public async Task Move(Player player, int maxWidth, int maxHeight)
        {


            //if (curTile() == "0")
            //{
            //    X++;
            //}
            //else
            //{
            //    // Ide kell az AI logika
            //}

            
            //D = direction

            int playerDX = player.X - X;
            int playerDY = player.Y - Y;

            Random random = new Random();
            int randomD = random.Next(2); 

            if (randomD == 0) // Vízszintes mozgás
            {
                if (Math.Abs(playerDX) > Math.Abs(playerDY))
                {
                    if (playerDX < 0 && X > 0)
                        X--;
                    else if (playerDX > 0 && X < maxWidth - 1)
                        X++;
                }
                else
                {
                    if (playerDY < 0 && Y > 0)
                        Y--;
                    else if (playerDY > 0 && Y < maxHeight - 1)
                        Y++;
                }
            }
            else // Függőleges mozgás
            {
                if (Math.Abs(playerDX) > Math.Abs(playerDY))
                {
                    if (playerDY < 0 && Y > 0)
                        Y--;
                    else if (playerDY > 0 && Y < maxHeight - 1)
                        Y++;
                }
                else
                {
                    if (playerDX < 0 && X > 0)
                        X--;
                    else if (playerDX > 0 && X < maxWidth - 1)
                        X++;
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
