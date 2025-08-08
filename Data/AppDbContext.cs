using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : IdentityDbContext {
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

	public DbSet<Player> Players => Set<Player>();
	public DbSet<Patch> Patches => Set<Patch>();
	public DbSet<Building> Buildings => Set<Building>();
	public DbSet<Storage> Storage => Set<Storage>();
}
