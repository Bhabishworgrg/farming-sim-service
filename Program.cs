using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(
	options => options.UseNpgsql(connectionString)
);

builder.Services.AddIdentityCore<IdentityUser>()
	.AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options => 
		options.TokenValidationParameters = new TokenValidationParameters {
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,
			RequireExpirationTime = true,
			ValidIssuer = builder.Configuration["Api:Issuer"],
			ValidAudience = builder.Configuration["Api:Audience"],
			IssuerSigningKey = new SymmetricSecurityKey(
				Encoding.UTF8.GetBytes(builder.Configuration["Api:SecretKey"]!)
			)
		}
	);

builder.Services.AddAuthorization();

builder.Services.AddControllers();

builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddScoped<IStatService, StatService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IAuthService, AuthService>();

WebApplication app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers().RequireAuthorization();
app.Run();
