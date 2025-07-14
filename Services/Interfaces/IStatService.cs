using System.Collections.Generic;

public interface IStatService {
	public DataResult<StatResponseDto> Create(StatRequestDto requestDto);
	public DataResult<StatResponseDto> Read(int id);
	public DataResult<List<StatResponseDto>> ReadAll();
	public DataResult<StatResponseDto> Update(int id, StatRequestDto requestDto);
	public DataResult<StatResponseDto> Delete(int id);
}
