using System.Collections.Generic;
using System.Linq;

public class StorageService : IStorageService {
	private IBaseRepository _repository;

	public StorageService(IBaseRepository repository) {
		_repository = repository;
	}

    public DataResult<StorageResponseDto> Create(StorageRequestDto requestDto) {
		Storage storage = new() {
			Quantity=requestDto.Quantity,
			CropTypeId=requestDto.CropTypeId,
			PlayerId=requestDto.PlayerId
		};

		DataResult<Storage> result = _repository.Create(storage);

		StorageResponseDto? responseDto = (result.Model == null) ? null : new() {
			Id=result.Model.Id,
			Quantity=result.Model.Quantity,
			CropTypeId=result.Model.CropTypeId,
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
			CropTypeId=result.Model.CropTypeId,
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

		List<StorageResponseDto> responseDtos = result.Model!.Select(storage => new StorageResponseDto {
			Id=storage.Id,
			Quantity=storage.Quantity,
			CropTypeId=storage.CropTypeId,
			PlayerId=storage.PlayerId
		}).ToList();

		return new DataResult<List<StorageResponseDto>> {
			Model=responseDtos,
			StatusCode=result.StatusCode,
			Message=result.Message
		};
    }

    public DataResult<StorageResponseDto> Update(int id, StorageRequestDto requestDto) {
		Storage storage = new() {
			Id=id,
			Quantity=requestDto.Quantity,
			CropTypeId=requestDto.CropTypeId,
			PlayerId=requestDto.PlayerId
		};

		DataResult<Storage> result = _repository.Update(storage);

		StorageResponseDto? responseDto = (result.Model == null) ? null : new() {
			Id=result.Model.Id,
			Quantity=result.Model.Quantity,
			CropTypeId=result.Model.CropTypeId,
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

	public bool IsOwner(int id, string userId) {
		Storage? storage = _repository.Read<Storage>(id).Model;
		if (storage == null) {
			return false;
		}

		Player? player = _repository.Read<Player>(storage.PlayerId).Model;
		if (player == null) {
			return false;
		}

		return player.UserId == userId;
	}
}
