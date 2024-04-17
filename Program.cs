using System.Reflection.Emit;
using System.IO;

namespace MineStep;

public class Program
{
    public static int PScore = 0;
    public static int AIScore = 0;
    static int savedMode = 0;
    static bool firstRun = false;

    public static void Main()
    {
        if(!firstRun)
        {
            string[] save = File.ReadAllLines("save.txt");
            PScore = int.Parse(save[0]);
            AIScore = int.Parse(save[1]);
            savedMode = int.Parse(save[2]);
            firstRun = true;
        }
        Program program = new Program();
    }

    public Program()
    {
        Menu menu = new();
        Console.ResetColor();
        string jatek_folytatas_neve = $"Játék folytatása\tP:{PScore}-AI:{AIScore}";
        int mode = menu.MenuRajzol(new string[] { "Új játék", jatek_folytatas_neve, "Játékleírás", "Kilépés" });

        if (mode == 0)
        {
            mode = menu.MenuRajzol(new string[] { "Könnyű", "Közepes", "Nehéz" });
            savedMode = mode;
            File.WriteAllText("save.txt", $"0\n0\n{mode}");
            PScore = 0;
            AIScore = 0;
            int bombCount = mode * 5 + 10; //0*5+10=10, 1*5+10=15, 2*5+10=20
            Player player = new(0, 0, "P", new int[] { 20, 10 });
            Map map = new Map(20, 10, bombCount, player);
            try { map.Run().Wait(); }
            catch {  }
        }
        else if (mode == 1)
        {
            int bombCount = savedMode * 5 + 10;
            Player player = new(0, 0, "P", new int[] { 20, 10 });
            Map map = new Map(20, 10, bombCount, player);
            map.Run().Wait();
        }
        else if (mode == 2) Kiir();
        else
        {
            File.WriteAllText("save.txt", $"{PScore}\n{AIScore}\n{savedMode}");
            Environment.Exit(0);
        }
        Console.ResetColor();
    }


    void Kiir()
    {
        Console.WriteLine("Játékleírás:\nA játékot egy játékos vs. gép módban lehet játszani. \n" +
            "A játék lényege ,hogy az egyik játékosnak minnél előbb el kell jutnia a másik játékos kezdő poziciójára. \n" +
            "Az nyer aki hamarabb ér a másik kezdő helyzetére \n" +
            "Három nehézségi kategória van: könnyű, közepes, nehéz");
        Console.ReadKey();
        Main();
    }

}





