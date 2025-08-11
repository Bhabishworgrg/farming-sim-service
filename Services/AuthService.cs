using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Identity;

public class AuthService : IAuthService {
	private UserManager<IdentityUser> _userManager;
	private ITokenService _tokenService;
	private IPlayerService _playerService;

	public AuthService(
		UserManager<IdentityUser> userManager, 
		ITokenService tokenService, 
		IPlayerService playerService
	) {
		_userManager = userManager;
		_tokenService = tokenService;
		_playerService = playerService;
	}

    public DataResult<RegisterResponseDto> Register(RegisterRequestDto requestDto) {
		IdentityUser user = new() {
			Email=requestDto.Email,
			UserName=requestDto.Email
		};

		IdentityResult result = _userManager.CreateAsync(user, requestDto.Password).Result;

		if (!result.Succeeded) {
			string errors = string.Join(", ", result.Errors.Select(
				error => error.Description
			));
			return new DataResult<RegisterResponseDto> {
				StatusCode = (int) HttpStatusCode.BadRequest,
				Message = $"Error: {errors}"
			};
		}

		_userManager.AddToRoleAsync(user, "Player").Wait();

		PlayerRequestDto playerRequestDto = new() {
			Username=requestDto.Username
		};
		DataResult<PlayerResponseDto> playerResult = _playerService.Create(playerRequestDto, user.Id);

		if (playerResult.StatusCode != (int) HttpStatusCode.Created) {
			return new DataResult<RegisterResponseDto> {
				StatusCode=playerResult.StatusCode,
				Message=playerResult.Message
			};
		}

		RegisterResponseDto responseDto = new() {
			Id=user.Id,
			Email=user.Email,
			Username=playerResult.Model!.Username
		};

		return new DataResult<RegisterResponseDto> {
			Model = responseDto,
			StatusCode = (int) HttpStatusCode.Created,
			Message = $"User #{user.Id} registered successfully."
		};
    }

    public DataResult<LoginResponseDto> Login(LoginRequestDto requestDto)
    {
		IdentityUser? user = _userManager.FindByEmailAsync(requestDto.Email).Result;
		if (user == null) {
			return new DataResult<LoginResponseDto> {
				StatusCode = (int) HttpStatusCode.Unauthorized,
				Message = "Invalid user or password."
			};
		}

		bool isPasswordValid = _userManager.CheckPasswordAsync(user, requestDto.Password).Result;
		if(!isPasswordValid) {
			return new DataResult<LoginResponseDto> {
				StatusCode = (int) HttpStatusCode.Unauthorized,
				Message = "Invalid user or password."
			};
		}

		string token = _tokenService.GenerateToken(user);
		LoginResponseDto responseDto = new() {
			Token= token,
			Id=user.Id,
			Email=user.Email!
		};

		return new DataResult<LoginResponseDto> {
			Model = responseDto,
			StatusCode = (int) HttpStatusCode.OK,
			Message = $"User {user.Id} logged in successfully."
		};
    }
}
