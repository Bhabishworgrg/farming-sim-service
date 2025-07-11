using System.Collections.Generic;

public interface IBaseRepository {
	public DataResult<T> Create<T>(T model) where T : class;
	public DataResult<T> Read<T>(int id) where T : class;
	public DataResult<List<T>> ReadAll<T>() where T : class;
	public DataResult<T> Update<T>(int id, T model) where T : class;
	public DataResult<T> Delete<T>(int id) where T : class;
}
