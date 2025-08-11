using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.EntityFrameworkCore;

public class PatchRepository : BaseRepository, IPatchRepository {
	private AppDbContext _context;

	public PatchRepository(AppDbContext context) : base(context) {
		_context = context;
	}

    public DataResult<List<Patch>> CreateBulk(List<Patch> patches) {
		try {
			_context.Set<Patch>().AddRange(patches);
			_context.SaveChanges();

			return new DataResult<List<Patch>> {
				Model = patches,
				StatusCode = (int) HttpStatusCode.Created,
				Message = "Patches created successfully."
			};
		} catch (DbUpdateException ex) {
			return new DataResult<List<Patch>> {
				StatusCode = (int) HttpStatusCode.BadRequest,
				Message = $"Error: {ex.Message}"
			};
		}
    }

    public DataResult<List<Patch>> UpdateBulk(List<Patch> patches) {
		try {
			_context.Set<Patch>().UpdateRange(patches);
			_context.SaveChanges();

			return new DataResult<List<Patch>> {
				Model = patches,
				StatusCode = (int) HttpStatusCode.OK,
				Message = "Patches updated successfully."
			};
		} catch (DbUpdateException ex) {
			return new DataResult<List<Patch>> {
				StatusCode = (int) HttpStatusCode.BadRequest,
				Message = $"Error: {ex.Message}"
			};
		}
	}

    public DataResult<List<Patch>> DeleteBulk(List<int> patchIds)
	{
		List<Patch> patches = _context.Set<Patch>()
			.Where(patch => patchIds.Contains(patch.Id))
			.ToList();

		if (patches.Count == 0) {
			return new DataResult<List<Patch>> {
				StatusCode = (int) HttpStatusCode.NotFound,
				Message = "Patches not found."
			};
		}

		try {
			_context.Set<Patch>().RemoveRange(patches);
			_context.SaveChanges();
		} catch (DbUpdateException ex) {
			return new DataResult<List<Patch>> {
				StatusCode = (int) HttpStatusCode.BadRequest,
				Message = $"Error: {ex.Message}"
			};
		}

		return new DataResult<List<Patch>> {
			StatusCode = (int) HttpStatusCode.OK,
			Message = "Patches deleted successfully."
		};
	}
}
