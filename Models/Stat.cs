public class Stat : BaseEntity {
	public int Coins { get; set; }
	public short Level { get; set; }
	public int Xp { get; set; }
	public int PlayerId { get; set; }
	public Player Player { get; set; } = null!;
}
