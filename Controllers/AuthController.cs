using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase {
	private IAuthService _service;

	public AuthController(IAuthService service) {
		_service = service;
	}

	[HttpPost("register")]
	public DataResult<RegisterResponseDto> Register(RegisterRequestDto requestDto) {
		return _service.Register(requestDto);
	}

	[HttpPost("login")]
	public DataResult<LoginResponseDto> Login(LoginRequestDto requestDto) {
		return _service.Login(requestDto);
	}
}
