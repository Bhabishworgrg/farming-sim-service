using System.Collections.Generic;
using System;

public class StatController {
	private StatService service;

	public StatController(StatService service) {
		this.service = service;
	}

	public void Create(int coins, int level, int xp, string playerId) {
		Console.WriteLine("INFO: Creating a new stat...");
		try {
			int id = service.Create(coins, level, xp, playerId);
			Console.WriteLine($"SUCCESS: Stat of id {id} created.");
		} catch (Exception exception) {
			Console.WriteLine($"ERROR: {exception.Message}");
		}
	}

	public void ReadById(int id) {
		Console.WriteLine($"INFO: Reading stat of id {id}...");
		try {
			(int, int, int, int, string) stat = service.ReadById(id);
			Console.WriteLine($"\tid:        {stat.Item1}");
			Console.WriteLine($"\tcoins:     {stat.Item2}");
			Console.WriteLine($"\tlevel:     {stat.Item3}");
			Console.WriteLine($"\txp:        {stat.Item4}");
			Console.WriteLine($"\tplayer id: {stat.Item5}");
		} catch (Exception exception) {
			Console.WriteLine($"ERROR: {exception.Message}");
		}
	}

	public void ReadAll() {
		Console.WriteLine("INFO: Reading all stats...");
		Console.WriteLine("\tid\tcoins\tlevel\txp\tplayer id");

		List<(int, int, int, int, string)> stats = service.ReadAll();
		foreach ((int, int, int, int, string) stat in stats) {
			Console.WriteLine($"\t{stat.Item1}\t{stat.Item2}\t{stat.Item3}\t{stat.Item4}\t{stat.Item5}");
		}
	}

	public void Update(int id, int coins, int level, int xp, string playerId) {
		Console.WriteLine($"INFO: Updating stat of id {id}...");
		try {
			service.Update(id, coins, level, xp, playerId);
			Console.WriteLine($"SUCCESS: Stat of id {id} updated.");
		} catch (Exception exception) {
			Console.WriteLine($"ERROR: {exception.Message}");
		}
	}

	public void Delete(int id) {
		Console.WriteLine($"INFO: Deleting stat of id {id}...");
		try {
			service.Delete(id);
			Console.WriteLine($"SUCCESS: Stat of id {id} deleted.");
		} catch (Exception exception) {
			Console.WriteLine($"ERROR: {exception.Message}");
		}
	}
}
