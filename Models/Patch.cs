using System;

public class Patch : PlayerOwnedEntity {
	public PatchStage Stage { get; set; }
	public DateTime PlantedTime { get; set; }
	public short X { get; set; }
	public short Y { get; set; }
	public int CropTypeId { get; set; }
	public CropType CropType { get; set; } = null!;
}
