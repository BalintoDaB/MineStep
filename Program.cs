using System.Reflection.Emit;
using System.IO;

namespace MineStep;

public class Program
{
    static void Main()
    {
        Program program = new Program();
    }

    public Program()
    {
        Menu menu = new();
        Console.ResetColor();
        string[] save = File.ReadAllLines("save.txt");
        string jatek_folytatas_neve = $"Játék folytatása\tP:{save[0]}-AI:{save[1]}";
        int mode = menu.MenuRajzol(new string[] { "Új játék", jatek_folytatas_neve, "Játékleírás", "Kilépés" });

        if (mode == 0)
        {
            //generate a file that contains a zero, a new line and another zero

            mode = menu.MenuRajzol(new string[] { "Könnyű", "Közepes", "Nehéz" });
            File.WriteAllText("save.txt", $"0\n0\n{mode}");
            int bombCount = mode * 5 + 10; //0*5+10=10, 1*5+10=15, 2*5+10=20
            //Ez akár egy 12 soros switch case is lehetne, de így rövidebb!
            Player player = new(0, 0, "P", new int[] { 20, 10 });
            Map map = new Map(20, 10, bombCount, player);
            map.Run().Wait();
        }
        else if (mode == 1)
        {

            int bombCount = int.Parse(save[2]) * 5 + 10;
            Player player = new(0, 0, "P", new int[] { 20, 10 });
            Map map = new Map(20, 10, bombCount, player);
            map.Run().Wait();
        }
        else if (mode == 2) Kiir();
        Console.ResetColor();
    }


    void Kiir()
    {
        Console.WriteLine("Játékleírás:\nA játékot egy játékos vs. gép módban lehet játszani. \n" +
            "A játék lényege ,hogy az egyik játékosnak minnél előbb el kell jutnia a másik játékos kezdő poziciójára. \n" +
            "Az nyer aki hamarabb ér a másik kezdő helyzetére \n" +
            "Három nehézségi kategória van: könnyű, közepes, nehéz");
    }

}





