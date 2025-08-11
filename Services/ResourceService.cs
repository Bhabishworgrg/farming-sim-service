public class ResourceService : IResourceService {
	private IBaseRepository _repository;

	public ResourceService(IBaseRepository repository) {
		_repository = repository;
	}

    public bool IsOwner<T>(int resourceId, string userId) where T : PlayerOwnedEntity {
		T? entity = _repository.Read<T>(resourceId).Model;
		if (entity == null) {
			return false;
		}

		Player? player = _repository.Read<Player>(entity.PlayerId).Model;
		if (player == null) {
			return false;
		}

		return player.UserId == userId;
    }
}
