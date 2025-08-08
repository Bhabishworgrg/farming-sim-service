public class BuildingType {
	public int Id { get; set; }
	public string Name { get; set; } = null!;
	public int BaseCost { get; set; }
	public int BuildTimeSeconds { get; set; }
	public short MaxLevel { get; set; }
}
