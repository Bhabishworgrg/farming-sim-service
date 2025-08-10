using System.Collections.Generic;

public class PlayerFullResponseDto : PlayerResponseDto {
	public IEnumerable<StorageResponseDto> Storage { get; set; } = null!;
	public IEnumerable<PatchResponseDto> Patches { get; set; } = null!;
	public IEnumerable<BuildingResponseDto> Buildings { get; set; } = null!;
}
