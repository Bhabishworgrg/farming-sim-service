public class Storage : PlayerOwnedEntity {
	public short Quantity { get; set; }
	public int CropTypeId { get; set; }
	public CropType CropType { get; set; } = null!;
}
