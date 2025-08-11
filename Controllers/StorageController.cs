using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class StorageController {
	private IStorageService _service;

	public StorageController(IStorageService service) {
		_service = service;
	}

	[HttpPost]
	public DataResult<StorageResponseDto> Create(StorageRequestDto requestDto) {
		return _service.Create(requestDto);
	}

	[HttpGet("{id}")]
	public DataResult<StorageResponseDto> Read([FromRoute] int id) {
		return _service.Read(id);
	}

	[HttpGet]
	public DataResult<List<StorageResponseDto>> ReadAll() {
		return _service.ReadAll(); 
	}

	[HttpPut("{id}")]
	public DataResult<StorageResponseDto> Update([FromRoute] int id, StorageRequestDto requestDto) {
		return _service.Update(id, requestDto);
	}

	[HttpDelete("{id}")]
	public DataResult<StorageResponseDto> Delete([FromRoute] int id) {
		return _service.Delete(id);
	}
}
