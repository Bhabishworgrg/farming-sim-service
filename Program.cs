using System;

public class Program {
	public static void Main(string[] args) {
		StatsController statsController = new StatsController();

		Console.WriteLine(statsController.ReadAll());

		statsController.Create(
			id: 5, 
			coins: 189, 
			level: 34, 
			xp: 128, 
			playerId: "7341c974-3e92-429c-b15d-359e3d1a4e06"
		);
		Console.WriteLine(statsController.ReadAll());
		
		Console.WriteLine(statsController.ReadById(id: 2));
		statsController.Update(
			id:2,
			coins: 0,
			level: 1,
			xp: 0,
			playerId: "9afacf79-5720-4a60-9a8c-7d9509433a4b"
		);
		Console.WriteLine(statsController.ReadById(id: 2));

		statsController.DeleteById(id: 2);
		Console.WriteLine(statsController.ReadAll());
	}
}
