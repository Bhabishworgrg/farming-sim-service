using System.Collections.Generic;
using System.Linq;

public class PlayerService : IPlayerService {
	private IBaseRepository _repository;

	public PlayerService(IBaseRepository repository) {
		_repository = repository;
	}

    public DataResult<PlayerResponseDto> Create(PlayerRequestDto requestDto) {
		Player player = new() {
			Username=requestDto.Username
		};

		DataResult<Player> result = _repository.Create(player);

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

    public DataResult<PlayerResponseDto> Read(int id) {
		DataResult<Player> result = _repository.Read<Player>(id);
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

    public DataResult<List<PlayerResponseDto>> ReadAll() {
		DataResult<List<Player>> result = _repository.ReadAll<Player>();

		List<PlayerResponseDto> responseDtos = result.Model!.Select(player => new PlayerResponseDto {
			Id=player.Id,
			Username=player.Username
		}).ToList();

		return new DataResult<List<PlayerResponseDto>> {
			Model=responseDtos,
			StatusCode=result.StatusCode,
			Message=result.Message
		};
    }

    public DataResult<PlayerResponseDto> Update(int id, PlayerRequestDto requestDto) {
		Player player = new() {
			Id=id,
			Username=requestDto.Username
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

