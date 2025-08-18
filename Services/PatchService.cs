using System.Collections.Generic;
using System.Linq;

public class PatchService : IPatchService {
	private IBaseRepository _repository;

	public PatchService(IBaseRepository repository) {
		_repository = repository;
	}

    public DataResult<PatchResponseDto> Create(PatchRequestDto requestDto) {
		Patch patch = new() {
			Stage=requestDto.Stage,
			PlantedTime=requestDto.PlantedTime,
			X=requestDto.X,
			Y=requestDto.Y,
			PlayerId=requestDto.PlayerId
		};

		DataResult<Patch> result = _repository.Create(patch);

		PatchResponseDto? responseDto = (result.Model == null) ? null : new() {
			Id=result.Model.Id,
			Stage=result.Model.Stage,
			PlantedTime=result.Model.PlantedTime,
			X=result.Model.X,
			Y=result.Model.Y,
			PlayerId=result.Model.PlayerId
		};

		return new DataResult<PatchResponseDto> {
			Model=responseDto, 
			StatusCode=result.StatusCode,
			Message=result.Message
		};
    }

    public DataResult<PatchResponseDto> Read(int id) {
		DataResult<Patch> result = _repository.Read<Patch>(id);
		PatchResponseDto? responseDto = (result.Model == null) ? null : new() {
			Id=result.Model.Id,
			Stage=result.Model.Stage,
			PlantedTime=result.Model.PlantedTime,
			X=result.Model.X,
			Y=result.Model.Y,
			PlayerId=result.Model.PlayerId
		};

		return new DataResult<PatchResponseDto> {
			Model=responseDto,
			StatusCode=result.StatusCode,
			Message=result.Message
		};
    }

    public DataResult<List<PatchResponseDto>> ReadAll() {
		DataResult<List<Patch>> result = _repository.ReadAll<Patch>();

		List<PatchResponseDto> responseDtos = result.Model!.Select(patch => new PatchResponseDto {
			Id=patch.Id,
			Stage=patch.Stage,
			PlantedTime=patch.PlantedTime,
			X=patch.X,
			Y=patch.Y,
			PlayerId=patch.PlayerId
		}).ToList();

		return new DataResult<List<PatchResponseDto>> {
			Model=responseDtos,
			StatusCode=result.StatusCode,
			Message=result.Message
		};
    }

    public DataResult<PatchResponseDto> Update(int id, PatchRequestDto requestDto) {
		Patch patch = new() {
			Id=id,
			Stage=requestDto.Stage,
			PlantedTime=requestDto.PlantedTime,
			X=requestDto.X,
			Y=requestDto.Y,
			PlayerId=requestDto.PlayerId
		};

		DataResult<Patch> result = _repository.Update(patch);

		PatchResponseDto? responseDto = (result.Model == null) ? null : new() {
			Id=result.Model.Id,
			Stage=result.Model.Stage,
			PlantedTime=result.Model.PlantedTime,
			X=result.Model.X,
			Y=result.Model.Y,
			PlayerId=result.Model.PlayerId
		};

		return new DataResult<PatchResponseDto> {
			Model=responseDto,
			StatusCode=result.StatusCode,
			Message=result.Message
		};
    }

    public DataResult<PatchResponseDto> Delete(int id) {
		DataResult<Patch> result = _repository.Delete<Patch>(id);

		return new DataResult<PatchResponseDto> {
			StatusCode=result.StatusCode,
			Message=result.Message
		};
    }

	public bool IsOwner(int id, string userId) {
		Patch? patch = _repository.Read<Patch>(id).Model;
		if (patch == null) {
			return false;
		}

		Player? player = _repository.Read<Player>(patch.PlayerId).Model;
		if (player == null) {
			return false;
		}

		return player.UserId == userId;
	}
}
