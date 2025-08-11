public interface IResourceService {
	public bool IsOwner<T>(int resourceId, string userId) where T : PlayerOwnedEntity;
}
