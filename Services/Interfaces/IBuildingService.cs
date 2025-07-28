using System.Collections.Generic;

public interface IBuildingService {
	public DataResult<BuildingResponseDto> Create(BuildingRequestDto requestDto);
	public DataResult<BuildingResponseDto> Read(int id);
	public DataResult<List<BuildingResponseDto>> ReadAll();
	public DataResult<BuildingResponseDto> Update(int id, BuildingRequestDto requestDto);
	public DataResult<BuildingResponseDto> Delete(int id);
}

