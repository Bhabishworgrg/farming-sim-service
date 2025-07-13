using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

public class BaseRepository : IBaseRepository {
	private AppDbContext _context;

	public BaseRepository(AppDbContext context) {
		_context = context;
	}

    public DataResult<T> Create<T>(T model) where T : class {
		try {
			EntityEntry<T> entry = _context.Set<T>().Add(model);
			_context.SaveChanges();

            return new DataResult<T> {
				Model = entry.Entity,
				StatusCode = (int) HttpStatusCode.Created,
				Message = $"{typeof(T).Name} created successfully."
			};
		} catch (DbUpdateException ex) {
			return new DataResult<T> {
				StatusCode = (int) HttpStatusCode.BadRequest,
				Message = $"Error: {ex.Message}"
			};
		}
    }

    public DataResult<T> Read<T>(int id) where T : class {
		T? entity = _context.Set<T>().Find(id);
		if (entity == null) {
			return new DataResult<T> {
				StatusCode = (int) HttpStatusCode.NotFound,
				Message = $"{typeof(T).Name} not found."
			};
		}

		return new DataResult<T> {
			Model = entity,
			StatusCode = (int) HttpStatusCode.OK,
			Message = $"{typeof(T).Name} retrieved successfully."
		};
    }

    public DataResult<List<T>> ReadAll<T>() where T : class {
		List<T> list = _context.Set<T>().ToList();
		return new DataResult<List<T>> {
			Model = list,
			StatusCode = (int) HttpStatusCode.OK,
			Message = $"{typeof(T).Name}s retrieved successfully."
		};
    }

    public DataResult<T> Update<T>(T model) where T : class {
		try {
			EntityEntry<T> entry = _context.Set<T>().Update(model);
			_context.SaveChanges();

			return new DataResult<T> {
				Model = entry.Entity,
				StatusCode = (int) HttpStatusCode.OK,
				Message = $"{typeof(T).Name} updated successfully."
			};
		} catch (DbUpdateException ex) {
			return new DataResult<T> {
				StatusCode = (int) HttpStatusCode.BadRequest,
				Message = $"Error: {ex.Message}"
			};
		}
    }

    public DataResult<T> Delete<T>(int id) where T : class {
		T? entity = _context.Set<T>().Find(id);
		if (entity == null) {
			return new DataResult<T> {
				StatusCode = (int) HttpStatusCode.NotFound,
				Message = $"{typeof(T).Name} not found."
			};
		}

		try {
			_context.Set<T>().Remove(entity);
			_context.SaveChanges();
		} catch (DbUpdateException ex) {
			return new DataResult<T> {
				StatusCode = (int) HttpStatusCode.BadRequest,
				Message = $"Error: {ex.Message}"
			};
		}

		return new DataResult<T> {
			StatusCode = (int) HttpStatusCode.OK,
			Message = $"{typeof(T).Name} deleted successfully."
		};
	}
}
