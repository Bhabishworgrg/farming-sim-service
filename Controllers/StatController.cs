using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/stats")]
public class StatController : ControllerBase {
	private IStatService _service;

	public StatController(IStatService service) {
		_service = service;
	}

	[HttpPost]
	public DataResult<StatResponseDto> Create(StatRequestDto requestDto) {
		return _service.Create(requestDto);
	}

	[HttpGet("{id}")]
	public DataResult<StatResponseDto> Read(int id) {
		return _service.Read(id);
	}

	[HttpGet]
	public DataResult<List<StatResponseDto>> ReadAll() {
		return _service.ReadAll(); 
	}

	[HttpPut("{id}")]
	public DataResult<StatResponseDto> Update(int id, StatRequestDto requestDto) {
		return _service.Update(id, requestDto);
	}

	[HttpDelete("{id}")]
	public DataResult<StatResponseDto> Delete(int id) {
		return _service.Delete(id);
	}
}
