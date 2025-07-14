using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext {
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

	public DbSet<Stat> Stats => Set<Stat>();
	public DbSet<Player> Players => Set<Player>();
}
