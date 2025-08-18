using System.Collections.Generic;
using System.Linq;

public class BuildingService : IBuildingService {
	private IBaseRepository _repository;

	public BuildingService(IBaseRepository repository) {
		_repository = repository;
	}

    public DataResult<BuildingResponseDto> Create(BuildingRequestDto requestDto) {
		Building building = new() {
			Level=requestDto.Level,
			X=requestDto.X,
			Y=requestDto.Y,
			PlayerId=requestDto.PlayerId,
			BuildingTypeId=requestDto.BuildingTypeId
		};

		DataResult<Building> result = _repository.Create(building);

		BuildingResponseDto? responseDto = (result.Model == null) ? null : new() {
			Id=result.Model.Id,
			Level=result.Model.Level,
			X=result.Model.X,
			Y=result.Model.Y,
			PlayerId=result.Model.PlayerId,
			BuildingTypeId=result.Model.BuildingTypeId
		};

		return new DataResult<BuildingResponseDto> {
			Model=responseDto, 
			StatusCode=result.StatusCode,
			Message=result.Message
		};
    }

    public DataResult<BuildingResponseDto> Read(int id) {
		DataResult<Building> result = _repository.Read<Building>(id);
		BuildingResponseDto? responseDto = (result.Model == null) ? null : new() {
			Id=result.Model.Id,
			Level=result.Model.Level,
			X=result.Model.X,
			Y=result.Model.Y,
			PlayerId=result.Model.PlayerId,
			BuildingTypeId=result.Model.BuildingTypeId
		};

		return new DataResult<BuildingResponseDto> {
			Model=responseDto,
			StatusCode=result.StatusCode,
			Message=result.Message
		};
    }

    public DataResult<List<BuildingResponseDto>> ReadAll() {
		DataResult<List<Building>> result = _repository.ReadAll<Building>();

		List<BuildingResponseDto> responseDtos = result.Model!.Select(building => new BuildingResponseDto {
			Id=building.Id,
			Level=building.Level,
			X=building.X,
			Y=building.Y,
			PlayerId=building.PlayerId,
			BuildingTypeId=building.BuildingTypeId
		}).ToList();

		return new DataResult<List<BuildingResponseDto>> {
			Model=responseDtos,
			StatusCode=result.StatusCode,
			Message=result.Message
		};
    }

    public DataResult<BuildingResponseDto> Update(int id, BuildingRequestDto requestDto) {
		Building building = new() {
			Id=id,
			Level=requestDto.Level,
			X=requestDto.X,
			Y=requestDto.Y,
			PlayerId=requestDto.PlayerId,
			BuildingTypeId=requestDto.BuildingTypeId
		};

		DataResult<Building> result = _repository.Update(building);

		BuildingResponseDto? responseDto = (result.Model == null) ? null : new() {
			Id=result.Model.Id,
			Level=result.Model.Level,
			X=result.Model.X,
			Y=result.Model.Y,
			PlayerId=result.Model.PlayerId
		};

		return new DataResult<BuildingResponseDto> {
			Model=responseDto,
			StatusCode=result.StatusCode,
			Message=result.Message
		};
    }

    public DataResult<BuildingResponseDto> Delete(int id) {
		DataResult<Building> result = _repository.Delete<Building>(id);

		return new DataResult<BuildingResponseDto> {
			StatusCode=result.StatusCode,
			Message=result.Message
		};
    }

	public bool IsOwner(int id, string userId) {
		Building? building = _repository.Read<Building>(id).Model;
		if (building == null) {
			return false;
		}

		Player? player = _repository.Read<Player>(building.PlayerId).Model;
		if (player == null) {
			return false;
		}

		return player.UserId == userId;
	}
}
