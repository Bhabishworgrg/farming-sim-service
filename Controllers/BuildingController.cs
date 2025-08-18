using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]s")]
public class BuildingController {
	private IBuildingService _service;

	public BuildingController(IBuildingService service) {
		_service = service;
	}

	[HttpPost]
	public DataResult<BuildingResponseDto> Create(BuildingRequestDto requestDto) {
		return _service.Create(requestDto);
	}

	[Authorize(Policy = Policies.Owner.Building)]
	[HttpGet("{id}")]
	public DataResult<BuildingResponseDto> Read([FromRoute] int id) {
		return _service.Read(id);
	}

	[Authorize(Roles = Roles.ADMIN)]
	[HttpGet]
	public DataResult<List<BuildingResponseDto>> ReadAll() {
		return _service.ReadAll(); 
	}

	[Authorize(Policy = Policies.Owner.Building)]
	[HttpPut("{id}")]
	public DataResult<BuildingResponseDto> Update([FromRoute] int id, BuildingRequestDto requestDto) {
		return _service.Update(id, requestDto);
	}

	[Authorize(Policy = Policies.Owner.Building)]
	[HttpDelete("{id}")]
	public DataResult<BuildingResponseDto> Delete([FromRoute] int id) {
		return _service.Delete(id);
	}
}
