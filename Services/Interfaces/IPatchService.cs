using System.Collections.Generic;

public interface IPatchService {
	public DataResult<PatchResponseDto> Create(PatchRequestDto requestDto);
	public DataResult<PatchResponseDto> Read(int id);
	public DataResult<List<PatchResponseDto>> ReadAll();
	public DataResult<PatchResponseDto> Update(int id, PatchRequestDto requestDto);
	public DataResult<PatchResponseDto> Delete(int id);
}
