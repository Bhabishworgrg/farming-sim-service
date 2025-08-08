public class Building : BaseEntity {
	public string Type { get; set; } = null!;
	public short Level { get; set; }
	public short X { get; set; }
	public short Y { get; set; }
	public int PlayerId { get; set; }
	public int BuildingTypeId { get; set; }
	public Player Player { get; set; } = null!;
	public BuildingType BuildingType { get; set; } = null!;
}
