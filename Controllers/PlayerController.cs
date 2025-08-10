using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]s")]
public class PlayerController : ControllerBase {
	private IPlayerService _service;

	public PlayerController(IPlayerService service) {
		_service = service;
	}

	[HttpPost]
	public DataResult<PlayerResponseDto> Create(PlayerRequestDto requestDto) {
		return _service.Create(requestDto);
	}

	[HttpGet("{id}")]
	public DataResult<PlayerResponseDto> Read([FromRoute] int id) {
		return _service.Read(id);
	}

	[HttpGet]
	public DataResult<List<PlayerResponseDto>> ReadAll() {
		return _service.ReadAll(); 
	}

	[HttpGet("me")]
	public DataResult<PlayerFullResponseDto> ReadMe() {
		return _service.ReadMe();
	}

	[HttpPut("{id}")]
	public DataResult<PlayerResponseDto> Update([FromRoute] int id, PlayerRequestDto requestDto) {
		return _service.Update(id, requestDto);
	}

	[HttpDelete("{id}")]
	public DataResult<PlayerResponseDto> Delete([FromRoute] int id) {
		return _service.Delete(id);
	}
}
