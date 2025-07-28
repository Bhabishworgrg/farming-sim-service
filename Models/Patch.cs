using System;

public class Patch : BaseEntity {
	public PatchStage Stage { get; set; }
	public DateTime PlantedTime { get; set; }
	public short X { get; set; }
	public short Y { get; set; }
	public int PlayerId { get; set; }
	public Player Player { get; set; } = null!;
}
