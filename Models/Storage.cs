public class Storage : BaseEntity {
	public short Quantity { get; set; }
	public int PlayerId { get; set; }
	public int CropId { get; set; }
	public Player Player { get; set; } = null!;
	public CropType CropType { get; set; } = null!;
}
