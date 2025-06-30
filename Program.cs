public class Program {
	public static void Main(string[] args) {
		StatService statsService = new();
		StatController statsController = new(statsService);

		statsController.ReadAll();

		statsController.Create(
			coins: 189, 
			level: 34, 
			xp: 128, 
			playerId: "7341c974-3e92-429c-b15d-359e3d1a4e06"
		);
		statsController.ReadAll();
		
		statsController.ReadById(id: 2);
		statsController.Update(
			id:2,
			coins: 0,
			level: 1,
			xp: 0,
			playerId: "9afacf79-5720-4a60-9a8c-7d9509433a4b"
		);
		statsController.ReadById(id: 2);

		statsController.Delete(id: 2);
		statsController.ReadAll();
	}
}
