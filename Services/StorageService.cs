using System.Collections.Generic;
using System.Linq;

public class StorageService : IStorageService {
	private IBaseRepository _repository;

	public StorageService(IBaseRepository repository) {
		_repository = repository;
	}

    public DataResult<StorageResponseDto> Create(StorageRequestDto requestDto) {
		Storage building = new() {
			Quantity=requestDto.Quantity,
			PlayerId=requestDto.PlayerId
		};

		DataResult<Storage> result = _repository.Create(building);

		StorageResponseDto? responseDto = (result.Model == null) ? null : new() {
			Id=result.Model.Id,
			Quantity=result.Model.Quantity,
			PlayerId=result.Model.PlayerId
		};

		return new DataResult<StorageResponseDto> {
			Model=responseDto, 
			StatusCode=result.StatusCode,
			Message=result.Message
		};
    }

    public DataResult<StorageResponseDto> Read(int id) {
		DataResult<Storage> result = _repository.Read<Storage>(id);
		StorageResponseDto? responseDto = (result.Model == null) ? null : new() {
			Id=result.Model.Id,
			Quantity=result.Model.Quantity,
			PlayerId=result.Model.PlayerId
		};

		return new DataResult<StorageResponseDto> {
			Model=responseDto,
			StatusCode=result.StatusCode,
			Message=result.Message
		};
    }

    public DataResult<List<StorageResponseDto>> ReadAll() {
		DataResult<List<Storage>> result = _repository.ReadAll<Storage>();

		List<StorageResponseDto> responseDtos = result.Model!.Select(building => new StorageResponseDto {
			Id=building.Id,
			Quantity=building.Quantity,
			PlayerId=building.PlayerId
		}).ToList();

		return new DataResult<List<StorageResponseDto>> {
			Model=responseDtos,
			StatusCode=result.StatusCode,
			Message=result.Message
		};
    }

    public DataResult<StorageResponseDto> Update(int id, StorageRequestDto requestDto) {
		Storage building = new() {
			Id=id,
			Quantity=requestDto.Quantity,
			PlayerId=requestDto.PlayerId
		};

		DataResult<Storage> result = _repository.Update(building);

		StorageResponseDto? responseDto = (result.Model == null) ? null : new() {
			Id=result.Model.Id,
			Quantity=result.Model.Quantity,
			PlayerId=result.Model.PlayerId
		};

		return new DataResult<StorageResponseDto> {
			Model=responseDto,
			StatusCode=result.StatusCode,
			Message=result.Message
		};
    }

    public DataResult<StorageResponseDto> Delete(int id) {
		DataResult<Storage> result = _repository.Delete<Storage>(id);

		return new DataResult<StorageResponseDto> {
			StatusCode=result.StatusCode,
			Message=result.Message
		};
    }
}
