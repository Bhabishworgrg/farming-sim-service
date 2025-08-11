using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

public class TokenService : ITokenService {
	private IConfiguration _configuration;
	private HttpContext? _httpContext;
	private UserManager<IdentityUser> _userManager;

	public TokenService(
		IConfiguration configuration, 
		IHttpContextAccessor httpContextAccessor,
		UserManager<IdentityUser> userManager
	) {
		_configuration = configuration;
		_httpContext = httpContextAccessor.HttpContext;
		_userManager = userManager;
	}

    public string GenerateToken(IdentityUser user) {
		IList<string> roles = _userManager.GetRolesAsync(user).Result;

		List<Claim> claims = new() {
			new Claim(JwtRegisteredClaimNames.Sub, user.Id),
			new Claim(JwtRegisteredClaimNames.Email, user.Email!)
		};

		claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

		SymmetricSecurityKey key = new(
			Encoding.UTF8.GetBytes(_configuration["Api:SecretKey"]!)
		);
		SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);

		JwtSecurityToken token = new(
			issuer: _configuration["Api:Issuer"],
			audience: _configuration["Api:Audience"],
			claims: claims,
			expires: DateTime.Now.AddDays(1),
			signingCredentials: credentials
		);

		return new JwtSecurityTokenHandler().WriteToken(token);
    }

	public string? GetUserIdFromToken() {
		return _httpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
	}
}
