public class PlayerOwnedEntity : BaseEntity {
	public int PlayerId { get; set; }
	public Player Player { get; set; } = null!;
}
