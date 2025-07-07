using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/stats")]
public class StatController : ControllerBase {
	private StatService service = new();

	[HttpPost]
	public DataResult<StatResponseDto> CreateStat(StatRequestDto request) {
		StatResponseDto response = service.CreateStat(request);
		return new() {
			Model=response,
			StatusCode=201,
			Message=$"Stat #{response.Id} created successfully."
		};
	}

	[HttpGet("{id}")]
	public DataResult<StatResponseDto> ReadStat(int id) {
		return new() {
			Model=service.ReadStat(id),
			StatusCode=200,
			Message=$"Stat #{id} retrieved successfully."
		};
	}

	[HttpGet]
	public DataResult<List<StatResponseDto>> ReadStats() {
		return new() {
			Model=service.ReadStats(),
			StatusCode=200,
			Message="Stats retrieved successfully."
		};
	}

	[HttpPut("{id}")]
	public DataResult<StatResponseDto> UpdateStat(int id, StatRequestDto request) {
		return new() {
			Model=service.UpdateStat(id, request),
			StatusCode=200,
			Message=$"Stat #{id} updated successfully."
		};
	}

	[HttpDelete("{id}")]
	public DataResult<StatResponseDto> Delete(int id) {
		return new() {
			Model=service.DeleteStat(id),
			StatusCode=200,
			Message=$"Stat #{id} deleted successfully."
		};
	}
}
