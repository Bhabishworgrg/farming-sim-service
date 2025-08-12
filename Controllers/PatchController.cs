using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]s")]
public class PatchController {
	private IPatchService _service;

	public PatchController(IPatchService service) {
		_service = service;
	}

	[HttpPost]
	public DataResult<PatchResponseDto> Create(PatchRequestDto requestDto) {
		return _service.Create(requestDto);
	}

	[HttpGet("{id}")]
	public DataResult<PatchResponseDto> Read([FromRoute] int id) {
		return _service.Read(id);
	}

	[Authorize(Roles = Roles.ADMIN)]
	[HttpGet]
	public DataResult<List<PatchResponseDto>> ReadAll() {
		return _service.ReadAll(); 
	}

	[HttpPut("{id}")]
	public DataResult<PatchResponseDto> Update([FromRoute] int id, PatchRequestDto requestDto) {
		return _service.Update(id, requestDto);
	}

	[HttpDelete("{id}")]
	public DataResult<PatchResponseDto> Delete([FromRoute] int id) {
		return _service.Delete(id);
	}
}
