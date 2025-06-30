using System;
using System.Collections.Generic;

public class StatService {
	private List<(int, int, int, int, string)> stats = new(){
		(1, 100, 25, 3899, "a31d56d6-a353-48bf-b430-e73b746e3a90"),
		(2, 1030, 51, 3438124, "9afacf79-5720-4a60-9a8c-7d9509433a4b"),
		(3, 3645, 29, 15874, "2e36945b-82af-472d-bb8a-fd523c83c3e9"),
		(4, 9331, 37, 32801, "09c6dcc3-9b66-4184-83e5-587495fbb8e2"),
	};
	
	public int Create(int coins, int level, int xp, string playerId) {
		if (coins < 0 || level < 1 || xp < 0) {
			throw new ArgumentOutOfRangeException("Invalid value assigned for new stats.\n");
		}

		foreach ((int, int, int, int, string) stat in stats) {
			if (stat.Item5 == playerId) {
				throw new InvalidOperationException($"The stat for player ID {playerId} already exists.\n");
			}
		}

		int id = stats[^1].Item1 + 1;
		stats.Add((id, coins, level, xp, playerId));
		
		return id;
	}
	
	public (int, int, int, int, string) ReadById(int id) {
		foreach ((int, int, int, int, string) stat in stats) {
			if (stat.Item1 == id) {
				return stat;
			}
		}
		throw new KeyNotFoundException($"Stat of id {id} was not found.\n");
	}
	
	public List<(int, int, int, int, string)> ReadAll() {
		return stats;
	}
	
	public void Update(int id, int coins, int level, int xp, string playerId) {
		int index;
		for (index = 0; index < stats.Count; index++) {
			if (stats[index].Item1 == id) {
				stats[index] = (id, coins, level, xp, playerId);
				return;
			}
		}
		throw new KeyNotFoundException($"Stat of id {id} was not found.\n");
	}
	
	public void Delete(int id) {
		foreach ((int, int, int, int, string) stat in stats) {
			if (stat.Item1 == id) {
				stats.Remove(stat);
				return;
			}
		}
		throw new KeyNotFoundException($"Stat of id {id} was not found.\n");
	}
}
