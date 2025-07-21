using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(
	options => options.UseNpgsql(connectionString)
);

builder.Services.AddIdentityCore<IdentityUser>()
	.AddEntityFrameworkStores<AppDbContext>()
	.AddSignInManager();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddControllers();

builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddScoped<IStatService, StatService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IAuthService, AuthService>();

WebApplication app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
