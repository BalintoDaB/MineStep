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

        public AI(string[,] display, int x, int y)
        {
            Display = display;
            X = x;
            Y = y;
        }

        private string curTile()
        {
            return Display[X, Y];
        }

        public async Task Move()
        {
            if (curTile() == "0")
            {
                X++;
            }
            else
            {
                // Ide kell az AI logika
            }
        }

    }
}
