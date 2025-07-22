public interface IAuthService {
	public DataResult<RegisterResponseDto> Register(RegisterRequestDto requestDto);
	public DataResult<LoginResponseDto> Login(LoginRequestDto requestDto);
}
