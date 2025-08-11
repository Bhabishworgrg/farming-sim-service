public class Building : PlayerOwnedEntity {
	public string Type { get; set; } = null!;
	public short Level { get; set; }
	public short X { get; set; }
	public short Y { get; set; }
	public int BuildingTypeId { get; set; }
	public BuildingType BuildingType { get; set; } = null!;
}
