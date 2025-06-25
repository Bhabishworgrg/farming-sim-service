using System.Collections.Generic;

public class StatsController {
	private List<List<dynamic>> stats = new List<List<dynamic>> {
		new List<dynamic> {1, 100, 25, 3899, "a31d56d6-a353-48bf-b430-e73b746e3a90"},
		new List<dynamic> {2, 1030, 51, 3438124, "9afacf79-5720-4a60-9a8c-7d9509433a4b"},
		new List<dynamic> {3, 3645, 29, 15874, "2e36945b-82af-472d-bb8a-fd523c83c3e9"},
		new List<dynamic> {4, 9331, 37, 32801, "09c6dcc3-9b66-4184-83e5-587495fbb8e2"},
	};
	
	public void Create(int id, int coins, int level, int xp, string playerId) {
		List<dynamic> newStat = new List<dynamic> {id, coins, level, xp, playerId};
		stats.Add(newStat);
	}

	public List<dynamic>? ReadById(int id) {
		foreach (List<dynamic> stat in stats) {
			if (stat[0] == id) {
				return stat;
			}
		}
		return null; 
	}

	public List<List<dynamic>> ReadAll() {
		return stats;
	}

	public void Update(int id, int coins, int level, int xp, string playerId) {
		List<dynamic> updatedStat = new List<dynamic> {id, coins, level, xp, playerId};

		int index;
		for (index = 0; index < stats.Count; index++) {
			if (stats[index][0] == id) {
				break;
			}
		}

		stats[index] = updatedStat;
	}

	public void DeleteById(int id) {
		List<dynamic>? statToDelete = null;
		foreach (List<dynamic> stat in stats) {
			if (stat[0] == id) {
				statToDelete = stat;
			}
		}
		stats.Remove(statToDelete!);
	}
}
