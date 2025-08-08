public class CropType {
	public int Id { get; set; }
	public string Name { get; set; } = null!;
	public int GrowthTimeSeconds { get; set; }
	public int SeedCost { get; set; }
	public int SellPrice { get; set; }
	public short HarvestQuality { get; set; }
}
