using System.Collections.Generic;

public interface IBaseRepository {
	public DataResult<T> Create<T>(T model) where T : BaseEntity;
	public DataResult<T> Read<T>(int id) where T : BaseEntity;
	public DataResult<List<T>> ReadAll<T>() where T : BaseEntity;
	public DataResult<T> Update<T>(T model) where T : BaseEntity;
	public DataResult<T> Delete<T>(int id) where T : BaseEntity;
}
