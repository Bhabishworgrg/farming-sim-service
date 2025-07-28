public class Storage : BaseEntity {
	public short Quantity { get; set; }
	public int PlayerId { get; set; }
	public Player Player { get; set; } = null!;
}
