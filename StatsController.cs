using System.Collections.Generic;

public class StatsController {
	private List<(int, int, int, int, string)> stats = new(){
		(1, 100, 25, 3899, "a31d56d6-a353-48bf-b430-e73b746e3a90"),
		(2, 1030, 51, 3438124, "9afacf79-5720-4a60-9a8c-7d9509433a4b"),
		(3, 3645, 29, 15874, "2e36945b-82af-472d-bb8a-fd523c83c3e9"),
		(4, 9331, 37, 32801, "09c6dcc3-9b66-4184-83e5-587495fbb8e2"),
	};
	
	public void Create(int coins, int level, int xp, string playerId) {
		int id = stats[^1].Item1 + 1;
		(int, int, int, int, string) newStat = (id, coins, level, xp, playerId);
		stats.Add(newStat);
	}

	public (int, int, int, int, string)? ReadById(int id) {
		foreach ((int, int, int, int, string) stat in stats) {
			if (stat.Item1 == id) {
				return stat;
			}
		}
		return null; 
	}

	public List<(int, int, int, int, string)> ReadAll() {
		List<(int, int, int, int, string)> allStats = new();
		foreach ((int, int, int, int, string) stat in stats) {
			allStats.Add(stat);
		}
		return allStats;
	}

	public void Update(int id, int coins, int level, int xp, string playerId) {
		(int, int, int, int, string) updatedStat = (id, coins, level, xp, playerId);

		int index;
		for (index = 0; index < stats.Count; index++) {
			if (stats[index].Item1 == id) {
				break;
			}
		}
		stats[index] = updatedStat;
	}

	public void DeleteById(int id) {
		foreach ((int, int, int, int, string) stat in stats) {
			if (stat.Item1 == id) {
				stats.Remove(stat);
				return;
			}
		}
	}
}
