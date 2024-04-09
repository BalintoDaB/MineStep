using Kocsiszin;
using MineStep;


Menu menu = new Menu();
Jatek();

void Jatek()
{
    int v;
    do
    {
        Console.ResetColor();
        v = menu.MenuRajzol(new string[] { "Új játék", "Játék folytatása", "Játékleírás", "Kilépés" });
        switch (v)
        {
            case 0:
                Player player = new Player(0, 0, "P", new int[] { 20, 10 });
                Map map = new Map(20, 10, 10, player);
                 map.Run(); //await 
                break;
            case 1:
                // fajliras + jatek
                break;
            case 2:
                Kiir();
                break;
        }
    } while (v != 3);
    Console.ResetColor();
}


void Kiir(){
    Console.WriteLine("Játékleírás:\nA játékot egy játékos vs. gép módban lehet játszani. \n" +
        " A játék lényege ,hogy az egyik játékosnak minnél előbb el kell jutnia a másik játékos kezdő poziciójára. \n" +
        "Az nyer aki hamarabb ér a másik kezdő helyzetére \n" +
        "Három nehézségi kategória van: könnyű, küzepes, nehéz");
}