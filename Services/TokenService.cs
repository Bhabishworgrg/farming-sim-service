using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

public class TokenService : ITokenService {
	private IConfiguration _configuration;
	private HttpContext? _httpContext;

	public TokenService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor) {
		_configuration = configuration;
		_httpContext = httpContextAccessor.HttpContext;
	}

    public string GenerateToken(IdentityUser user) {
		Claim[] claims = new[] {
			new Claim(JwtRegisteredClaimNames.Sub, user.Id),
			new Claim(JwtRegisteredClaimNames.Email, user.Email!)
		};

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
		return _httpContext?.User.FindFirstValue(JwtRegisteredClaimNames.Sub);
	}
}
