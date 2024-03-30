using MineStep;

Player player = new Player(0, 0, "P", new int[] { 20, 10 });
Map map = new Map(20, 10, 10, player);
await map.Run();