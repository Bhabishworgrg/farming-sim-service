using System.Collections.Generic;
using System.Linq;

public class StatService : IStatService {
	private IBaseRepository _repository;

	public StatService(IBaseRepository repository) {
		_repository = repository;
	}

    public DataResult<StatResponseDto> Create(StatRequestDto requestDto) {
		Stat stat = new() {
			Xp=requestDto.Xp,
			Coins=requestDto.Coins,
			Level=requestDto.Level
		};

		DataResult<Stat> result = _repository.Create(stat);

		StatResponseDto? responseDto = (result.Model == null) ? null : new() {
			Id=result.Model.Id,
			Xp=result.Model.Xp,
			Coins=result.Model.Coins,
			Level=result.Model.Level
		};

		return new DataResult<StatResponseDto> {
			Model=responseDto, 
			StatusCode=result.StatusCode,
			Message=result.Message
		};
    }

    public DataResult<StatResponseDto> Read(int id) {
		DataResult<Stat> result = _repository.Read<Stat>(id);
		StatResponseDto? responseDto = (result.Model == null) ? null : new() {
			Id=result.Model.Id,
			Xp=result.Model.Xp,
			Coins=result.Model.Coins,
			Level=result.Model.Level
		};

		return new DataResult<StatResponseDto> {
			Model=responseDto,
			StatusCode=result.StatusCode,
			Message=result.Message
		};
    }

    public DataResult<List<StatResponseDto>> ReadAll() {
		DataResult<List<Stat>> result = _repository.ReadAll<Stat>();

		List<StatResponseDto> responseDtos = result.Model!.Select(stat => new StatResponseDto {
			Id=stat.Id,
			Xp=stat.Xp,
			Coins=stat.Coins,
			Level=stat.Level
		}).ToList();

		return new DataResult<List<StatResponseDto>> {
			Model=responseDtos,
			StatusCode=result.StatusCode,
			Message=result.Message
		};
    }

    public DataResult<StatResponseDto> Update(int id, StatRequestDto requestDto) {
		Stat stat = new() {
			Id=id,
			Xp=requestDto.Xp,
			Coins=requestDto.Coins,
			Level=requestDto.Level
		};

		DataResult<Stat> result = _repository.Update(stat);

		StatResponseDto? responseDto = (result.Model == null) ? null : new() {
			Id=result.Model.Id,
			Xp=result.Model.Xp,
			Coins=result.Model.Coins,
			Level=result.Model.Level
		};

		return new DataResult<StatResponseDto> {
			Model=responseDto,
			StatusCode=result.StatusCode,
			Message=result.Message
		};
    }

    public DataResult<StatResponseDto> Delete(int id) {
		DataResult<Stat> result = _repository.Delete<Stat>(id);

		return new DataResult<StatResponseDto> {
			StatusCode=result.StatusCode,
			Message=result.Message
		};
    }
}
