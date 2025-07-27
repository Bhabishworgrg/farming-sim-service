using Microsoft.AspNetCore.Identity;

public interface ITokenService {
	public string GenerateToken(IdentityUser user);
}
