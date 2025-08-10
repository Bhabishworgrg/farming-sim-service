using System.Collections.Generic;
using System.Linq;
using System.Net;

public class PlayerService : IPlayerService {
	private IPlayerRepository _repository;
	private ITokenService _tokenService;

	public PlayerService(IPlayerRepository repository, ITokenService tokenService) {
		_repository = repository;
		_tokenService = tokenService;
	}

    public DataResult<PlayerResponseDto> Create(PlayerRequestDto requestDto) {
		string? userId = _tokenService.GetUserIdFromToken();	
		if (userId == null) {
			return new DataResult<PlayerResponseDto> {
				StatusCode = (int) HttpStatusCode.Unauthorized,
				Message = "User is not authenticated."
			};
		}

		Player player = new() {
			Username=requestDto.Username,
			Xp=requestDto.Xp,
			Coins=requestDto.Coins,
			Level=requestDto.Level,
			UserId=userId
		};

		DataResult<Player> result = _repository.Create(player);

		PlayerResponseDto? responseDto = (result.Model == null) ? null : new() {
			Id=result.Model.Id,
			Username=result.Model.Username,
			Xp=result.Model.Xp,
			Coins=result.Model.Coins,
			Level=requestDto.Level
		};

		return new DataResult<PlayerResponseDto> {
			Model=responseDto, 
			StatusCode=result.StatusCode,
			Message=result.Message
		};
    }

    public DataResult<PlayerResponseDto> Read(int id) {
		DataResult<Player> result = _repository.Read<Player>(id);
		PlayerResponseDto? responseDto = (result.Model == null) ? null : new() {
			Id=result.Model.Id,
			Username=result.Model.Username,
			Xp=result.Model.Xp,
			Coins=result.Model.Coins,
			Level=result.Model.Level
		};

		return new DataResult<PlayerResponseDto> {
			Model=responseDto,
			StatusCode=result.StatusCode,
			Message=result.Message
		};
    }

    public DataResult<List<PlayerResponseDto>> ReadAll() {
		DataResult<List<Player>> result = _repository.ReadAll<Player>();

		List<PlayerResponseDto> responseDtos = result.Model!.Select(player => new PlayerResponseDto {
			Id=player.Id,
			Username=player.Username,
			Xp=player.Xp,
			Coins=player.Coins,
			Level=player.Level
		}).ToList();

		return new DataResult<List<PlayerResponseDto>> {
			Model=responseDtos,
			StatusCode=result.StatusCode,
			Message=result.Message
		};
    }

	public DataResult<PlayerFullResponseDto> ReadMe() {
		string? userId = _tokenService.GetUserIdFromToken();
		if (userId == null) {
			return new DataResult<PlayerFullResponseDto> {
				StatusCode = (int) HttpStatusCode.Unauthorized,
				Message = "User is not authenticated."
			};
		}

		DataResult<Player> result = _repository.ReadByUserId(userId);

		PlayerFullResponseDto? fullResponseDto = (result.Model == null) ? null : new() {
			Id = result.Model.Id,
			Username = result.Model.Username,
			Xp = result.Model.Xp,
			Coins = result.Model.Coins,
			Level = result.Model.Level,
			Storage = result.Model.Storage.Select(
				storage => new StorageResponseDto {
					Id=storage.Id,
					Quantity=storage.Quantity,
					CropTypeId=storage.CropTypeId
				}
			).ToList(),
			Patches = result.Model.Patches.Select(
				patch => new PatchResponseDto {
					Id=patch.Id,
					Stage=patch.Stage,
					PlantedTime=patch.PlantedTime,
					X=patch.X,
					Y=patch.Y,
					CropTypeId=patch.CropTypeId
				}
			).ToList(),
			Buildings = result.Model.Buildings.Select(
				building => new BuildingResponseDto {
					Id=building.Id,
					Type=building.Type,
					Level=building.Level,
					X=building.X,
					Y=building.Y,
					BuildingTypeId=building.BuildingTypeId
				}
			).ToList()
		};

		return new DataResult<PlayerFullResponseDto> {
			Model=fullResponseDto,
			StatusCode=result.StatusCode,
			Message=result.Message
		};
	}

    public DataResult<PlayerResponseDto> Update(int id, PlayerRequestDto requestDto) {
		Player player = new() {
			Id=id,
			Username=requestDto.Username,
			Xp=requestDto.Xp,
			Coins=requestDto.Coins,
			Level=requestDto.Level
		};

		DataResult<Player> result = _repository.Update(player);

		PlayerResponseDto? responseDto = (result.Model == null) ? null : new() {
			Id=result.Model.Id,
			Username=result.Model.Username
		};

		return new DataResult<PlayerResponseDto> {
			Model=responseDto,
			StatusCode=result.StatusCode,
			Message=result.Message
		};
    }

    public DataResult<PlayerResponseDto> Delete(int id) {
		DataResult<Player> result = _repository.Delete<Player>(id);

		return new DataResult<PlayerResponseDto> {
			StatusCode=result.StatusCode,
			Message=result.Message
		};
    }
}
