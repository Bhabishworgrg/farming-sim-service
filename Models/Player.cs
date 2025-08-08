using Microsoft.AspNetCore.Identity;

public class Player : BaseEntity {
	public string Username { get; set; } = string.Empty;
	public string UserId { get; set; } = string.Empty;
	public IdentityUser User { get; set; } = null!;
}
