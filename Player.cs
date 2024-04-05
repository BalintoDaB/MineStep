using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineStep
{
    public class Player/*: IDisposable*/
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Icon { get; set; }
        public int[] bounds { get; set; }

        public Player(int x, int y, string icon, int[] bounds)
        {
            X = x;
            Y = y;
            Icon = icon;
            this.bounds = bounds;
        }

        public async Task Move()
        {
            int oldX = X;
            int oldY = Y;
            ConsoleKeyInfo key = await Task.Run(() => Console.ReadKey(true));
            // move the player based on the key pressed
            switch (key.Key)
            {
                case ConsoleKey.W:
                    Y--;
                    break;
                case ConsoleKey.A:
                    X--;
                    break;
                case ConsoleKey.S:
                    Y++;
                    break;
                case ConsoleKey.D:
                    X++;
                    break;
                case ConsoleKey.UpArrow:
                    Y--;
                    break;
                case ConsoleKey.LeftArrow:
                    X--;
                    break;
                case ConsoleKey.DownArrow:
                    Y++;
                    break;
                case ConsoleKey.RightArrow:
                    X++;
                    break;
            }

            // check if the player is out of bounds
            if (X < 0 || X >= bounds[0] || Y < 0 || Y >= bounds[1])
            {
                X = oldX;
                Y = oldY;
            }
        }

        public void PlayerDispose() //Game Over
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\tGame Over!");
            Console.ResetColor();
        }
    }
}
