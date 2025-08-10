using System.Linq;
using System.Net;
using Microsoft.EntityFrameworkCore;

public class PlayerRepository : BaseRepository, IPlayerRepository {
	private AppDbContext _context;

	public PlayerRepository(AppDbContext context) : base(context) {
		_context = context;
	}

	public DataResult<Player> ReadByUserId(string userId) {
		Player? player = _context.Players
			.Include(player => player.Storage)
			.Include(player => player.Patches)
			.Include(player => player.Buildings)
			.FirstOrDefault(p => p.UserId == userId);

		if (player == null) {
			return new DataResult<Player> {
				StatusCode = (int) HttpStatusCode.NotFound,
				Message = $"Player not found."
			};
		}

		return new DataResult<Player> {
			Model = player,
			StatusCode = (int) HttpStatusCode.OK,
			Message = $"Player retrieved successfully."
		};
	}
}
