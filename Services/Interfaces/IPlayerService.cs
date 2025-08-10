using System.Collections.Generic;

public interface IPlayerService {
	public DataResult<PlayerResponseDto> Create(PlayerRequestDto requestDto, string? userId = null);
	public DataResult<PlayerResponseDto> Read(int id);
	public DataResult<List<PlayerResponseDto>> ReadAll();
	public DataResult<PlayerFullResponseDto> ReadMe();
	public DataResult<PlayerResponseDto> Update(int id, PlayerRequestDto requestDto);
	public DataResult<PlayerResponseDto> Delete(int id);
}

