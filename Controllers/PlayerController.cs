using Microsoft.AspNetCore.Authorization;
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

	[Authorize(Roles = Roles.ADMIN)]
	[HttpGet("{id}")]
	public DataResult<PlayerResponseDto> Read([FromRoute] int id) {
		return _service.Read(id);
	}

	[Authorize(Roles = Roles.ADMIN)]
	[HttpGet]
	public DataResult<List<PlayerResponseDto>> ReadAll() {
		return _service.ReadAll(); 
	}

	[HttpGet("me")]
	public DataResult<PlayerFullResponseDto> ReadMe() {
		return _service.ReadMe();
	}

	[Authorize(Roles = Roles.ADMIN)]
	[HttpPut("{id}")]
	public DataResult<PlayerResponseDto> Update([FromRoute] int id, PlayerRequestDto requestDto) {
		return _service.Update(id, requestDto);
	}

	[Authorize(Roles = Roles.ADMIN)]
	[HttpDelete("{id}")]
	public DataResult<PlayerResponseDto> Delete([FromRoute] int id) {
		return _service.Delete(id);
	}
}
