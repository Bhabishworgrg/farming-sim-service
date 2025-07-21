using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Identity;

public class AuthService : IAuthService {
	private UserManager<IdentityUser> _userManager;

	public AuthService(UserManager<IdentityUser> userManager) {
		_userManager = userManager;
	}

    public DataResult<RegisterResponseDto> Register(RegisterRequestDto requestDto) {
		IdentityUser user = new() {
			UserName=requestDto.UserName,
			Email=requestDto.Email
		};

		IdentityResult result = _userManager.CreateAsync(user, requestDto.Password).Result;

		if (result.Succeeded) {
			RegisterResponseDto responseDto = new() {
				Id=user.Id,
				UserName=user.UserName,
				Email=user.Email
			};

			return new DataResult<RegisterResponseDto> {
				Model = responseDto,
				StatusCode = (int) HttpStatusCode.Created,
				Message = $"User #{user.Id} registered successfully."
			};
		}

		string errors = string.Join(", ", result.Errors.Select(error => error.Description));
		return new DataResult<RegisterResponseDto> {
			StatusCode = (int) HttpStatusCode.BadRequest,
			Message = $"Error: {errors}"
		};
    }
}
