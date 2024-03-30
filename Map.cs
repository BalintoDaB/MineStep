﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineStep
{
    public class Map
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int BombCount { get; set; }
        public int[,] Tiles { get; set; }
        public string[,] Display { get; set; }

        private Player player { get; set;}

        private Dictionary<string, ConsoleColor> colors = new Dictionary<string, ConsoleColor>
        {
            { "X", ConsoleColor.Magenta },
            { "0", ConsoleColor.DarkGray },
            { "1", ConsoleColor.Blue },
            { "2", ConsoleColor.Green },
            { "3", ConsoleColor.Red },
            { "4", ConsoleColor.DarkBlue },
            { "5", ConsoleColor.DarkRed },
            { "6", ConsoleColor.DarkGreen },
            { "7", ConsoleColor.DarkYellow },
            { "8", ConsoleColor.DarkMagenta },
            { "#", ConsoleColor.Gray }
        };


        public Map(int width, int height, int bombCount, Player p)
        {
            Width = width;
            Height = height;
            BombCount = bombCount;
            player = p;
            Generate();
        }

        private void Generate()
        {
            Tiles = new int[Width, Height];
            Display = new string[Width, Height];
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Display[x, y] = "#";
                }
            }
            Random random = new Random();
            for (int i = 0; i < BombCount; i++)
            {
                int x = random.Next(Width);
                int y = random.Next(Height);
                if (Tiles[x, y] == -1)
                {
                    i--;
                    continue;
                }
                Tiles[x, y] = -1;
                for (int dx = -1; dx <= 1; dx++)
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        if (dx == 0 && dy == 0)
                            continue;
                        if (x + dx < 0 || x + dx >= Width || y + dy < 0 || y + dy >= Height)
                            continue;
                        if (Tiles[x + dx, y + dy] == -1)
                            continue;
                        Tiles[x + dx, y + dy]++;
                    }
                }
            }
        }

        public void Reveal()
        {
            //reveal around the player's position
            //for (int dx = -1; dx <= 1; dx++)
            //{
            //    for (int dy = -1; dy <= 1; dy++)
            //    {
            //        if (player.X + dx < 0 || player.X + dx >= Width || player.Y + dy < 0 || player.Y + dy >= Height)
            //            continue;
            //        if (Tiles[player.X + dx, player.Y + dy] == -1) Display[player.X + dx, player.Y + dy] = "#";
            //        else Display[player.X + dx, player.Y + dy] = Tiles[player.X + dx, player.Y + dy].ToString();
            //    }
            //}
            //reveal just the player's position
            if (Tiles[player.X, player.Y] == -1) Display[player.X, player.Y] = "X";
            else Display[player.X, player.Y] = Tiles[player.X, player.Y].ToString();
        }

        public void Print(bool wPlayer)
        {
            Reveal();
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (player.X == x && player.Y == y && wPlayer)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(player.Icon);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = colors[Display[x, y]];
                        Console.Write(Display[x, y]);
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }
        }

        public async Task Run()
        {
            Console.Clear();
            CancellationTokenSource source = new CancellationTokenSource();
            #region OPTIMALIZALNI KESOBB
            while (true)
            {
                if (Console.KeyAvailable) // Check for player input
                {
                    source.Cancel(); // Stop the loop when player presses Enter
                    break;
                }
                Console.Clear();
                Print(true);
                await Task.Delay(500, source.Token); // Wait with cancellation
                Console.Clear();

                if (Console.KeyAvailable) // Check for player input
                {
                    source.Cancel(); // Stop the loop when player presses Enter
                    break;
                }

                Print(false);
                await Task.Delay(500, source.Token); // Wait with cancellation
            }
            #endregion
            await player.Move();
            await Run();
        }
    }
}