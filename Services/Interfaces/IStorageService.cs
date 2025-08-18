using System.Collections.Generic;

public interface IStorageService {
	public DataResult<StorageResponseDto> Create(StorageRequestDto requestDto);
	public DataResult<StorageResponseDto> Read(int id);
	public DataResult<List<StorageResponseDto>> ReadAll();
	public DataResult<StorageResponseDto> Update(int id, StorageRequestDto requestDto);
	public DataResult<StorageResponseDto> Delete(int id);
	public bool IsOwner(int id, string userId);
}
