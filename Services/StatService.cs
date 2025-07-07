using System;
using System.Collections.Generic;

public class StatService {
	private static List<Stat> stats = new() {
		new() {Id=1, Coins=100, Level=25, Xp=3899, PlayerId=Guid.Parse("a31d56d6-a353-48bf-b430-e73b746e3a90")},
		new() {Id=2, Coins=930, Level=51, Xp=3438124, PlayerId=Guid.Parse("9afacf79-5720-4a60-9a8c-7d9509433a4b")},
		new() {Id=3, Coins=645, Level=29, Xp=15874, PlayerId=Guid.Parse("2e36945b-82af-472d-bb8a-fd523c83c3e9")},
		new() {Id=4, Coins=331, Level=37, Xp=32801, PlayerId=Guid.Parse("09c6dcc3-9b66-4184-83e5-587495fbb8e2")},
	};
	
	public StatResponseDto CreateStat(StatRequestDto request) {
		int id = stats[^1].Id + 1;
		Stat stat = new() {
			Id=id, 
			Coins=request.Coins, 
			Level=request.Level, 
			Xp=request.Xp, 
			PlayerId=request.PlayerId
		};

		stats.Add(stat);
		
		return new StatResponseDto {
			Id=stat.Id,
			Coins=stat.Coins, 
			Level=stat.Level, 
			Xp=stat.Xp, 
			PlayerId=stat.PlayerId
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
					PlayerId=stat.PlayerId
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
				PlayerId=stat.PlayerId
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
					PlayerId=request.PlayerId
				};
				
				stats[i] = stat;

				return new StatResponseDto {
					Id=stat.Id,
					Coins=stat.Coins,
					Level=stat.Level,
					Xp=stat.Xp,
					PlayerId=stat.PlayerId
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
					PlayerId=stat.PlayerId
				};
			}
		}
		return null;
	}
}
