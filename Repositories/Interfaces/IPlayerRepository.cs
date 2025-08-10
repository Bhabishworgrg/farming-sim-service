public interface IPlayerRepository : IBaseRepository{
	public DataResult<Player> ReadByUserId(string userId);
}
