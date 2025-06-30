using System;
using System.Collections.Generic;

public class Program {
	public static void Main(string[] args) {
		StatsController statsController = new StatsController();

		Console.WriteLine("Printing all stats...");
		List<(int, int, int, int, string)> stats = statsController.ReadAll();
		foreach ((int, int, int, int, string) stat in stats) {
			Console.WriteLine(stat);
		}
		Console.WriteLine();

		Console.WriteLine("Creating a new stat of id 5...");
		statsController.Create(
			coins: 189, 
			level: 34, 
			xp: 128, 
			playerId: "7341c974-3e92-429c-b15d-359e3d1a4e06"
		);
		Console.WriteLine("Stat of id 5 created.\n");

		Console.WriteLine("Printing updated stats...");
		stats = statsController.ReadAll();
		foreach ((int, int, int, int, string) stat in stats) {
			Console.WriteLine(stat);
		}
		Console.WriteLine();
		
		Console.WriteLine("Printing stat of id 2...");
		Console.WriteLine(statsController.ReadById(id: 2));

		Console.WriteLine("\nUpdating stat of id 2...");
		statsController.Update(
			id:2,
			coins: 0,
			level: 1,
			xp: 0,
			playerId: "9afacf79-5720-4a60-9a8c-7d9509433a4b"
		);
		Console.WriteLine("Stat of id 2 updated.\n");

		Console.WriteLine("Printing updated stat of id 2.");
		Console.WriteLine(statsController.ReadById(id: 2));

		Console.WriteLine("\nDeleting stat of id 2...");
		statsController.DeleteById(id: 2);
		Console.WriteLine("Stat of id 2 deleted.\n");

		Console.WriteLine("Printing updated stats again...");
		stats = statsController.ReadAll();
		foreach ((int, int, int, int, string) stat in stats) {
			Console.WriteLine(stat);
		}
		Console.WriteLine();
	}
}
