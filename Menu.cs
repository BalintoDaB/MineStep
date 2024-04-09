using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kocsiszin
{
    public class Menu
    {

        public Menu()
        {
        }

        public int MenuRajzol(string[] Menupontok)
        {
            Console.Clear();
            Console.CursorVisible = false;
            foreach (var menupont in Menupontok)
            {
                Console.WriteLine(menupont);
            }
            int aktualis = 0;
            ConsoleKey key;
            do
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(0, aktualis);
                Console.WriteLine(Menupontok[aktualis]);
                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(0, aktualis);
                    Console.WriteLine(Menupontok[aktualis]);
                    if (key == ConsoleKey.DownArrow)
                    {
                        aktualis = (aktualis + 1) % Menupontok.Length;
                    }
                    else
                    {
                        aktualis = (aktualis + Menupontok.Length - 1) % Menupontok.Length;
                    }
                }
            } while (key != ConsoleKey.Enter);
            Console.ResetColor();
            return aktualis;
        }

    }
}
