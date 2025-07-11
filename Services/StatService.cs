using System.Collections.Generic;

public class StatService {
	private static List<Stat> stats = new() {
		new() {Id=1, Coins=100, Level=25, Xp=3899},
		new() {Id=2, Coins=930, Level=51, Xp=3438124},
		new() {Id=3, Coins=645, Level=29, Xp=15874},
		new() {Id=4, Coins=331, Level=37, Xp=32801},
	};
	
	public StatResponseDto CreateStat(StatRequestDto request) {
		int id = stats[^1].Id + 1;
		Stat stat = new() {
			Id=id, 
			Coins=request.Coins, 
			Level=request.Level, 
			Xp=request.Xp,
		};

		stats.Add(stat);
		
		return new StatResponseDto {
			Id=stat.Id,
			Coins=stat.Coins, 
			Level=stat.Level, 
			Xp=stat.Xp, 
		};
	}
	
	public StatResponseDto? ReadStat(int id) {
		foreach (Stat stat in stats) {
			if (stat.Id == id) {
				return new StatResponseDto {
					Id=stat.Id,
					Coins=stat.Coins,
					Level=stat.Level,
					Xp=stat.Xp,
				};
			}
		}
		return null;
	}
	
	public List<StatResponseDto> ReadStats() {
		List<StatResponseDto> result = new();
		foreach (Stat stat in stats) {
			result.Add(new StatResponseDto {
				Id=stat.Id,
				Coins=stat.Coins,
				Level=stat.Level,
				Xp=stat.Xp,
			});
		}
		return result;
	}
	
	public StatResponseDto? UpdateStat(int id, StatRequestDto request) {
		for (int i = 0; i < stats.Count; i++) {
			if (stats[i].Id == id) {
				Stat stat = new() {
					Id=id,
					Coins=request.Coins,
					Level=request.Level,
					Xp=request.Xp,
				};
				
				stats[i] = stat;

				return new StatResponseDto {
					Id=stat.Id,
					Coins=stat.Coins,
					Level=stat.Level,
					Xp=stat.Xp,
				};
			}
		}
		return null;
	}
	
	public StatResponseDto? DeleteStat(int id) {
		foreach (Stat stat in stats) {
			if (stat.Id == id) {
				stats.Remove(stat);
				return new StatResponseDto {
					Id=stat.Id,
					Coins=stat.Coins,
					Level=stat.Level,
					Xp=stat.Xp,
				};
			}
		}
		return null;
	}
}
