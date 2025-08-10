using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

public class Player : BaseEntity {
	public string Username { get; set; } = string.Empty;
	public int Coins { get; set; }
	public short Level { get; set; }
	public int Xp { get; set; }
	public string UserId { get; set; } = string.Empty;
	public IdentityUser User { get; set; } = null!;
	public ICollection<Storage> Storage { get; set; } = null!;
	public ICollection<Patch> Patches { get; set; } = null!;
	public ICollection<Building> Buildings { get; set; } = null!;
}
