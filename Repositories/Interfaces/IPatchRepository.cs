using System.Collections.Generic;

public interface IPatchRepository : IBaseRepository {
	DataResult<List<Patch>> CreateBulk(List<Patch> patches);
	DataResult<List<Patch>> UpdateBulk(List<Patch> patches);
	DataResult<List<Patch>> DeleteBulk(List<int> patchIds);
}
