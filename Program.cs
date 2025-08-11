using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(
	options => options.UseNpgsql(connectionString)
);

builder.Services.AddIdentityCore<IdentityUser>()
	.AddRoles<IdentityRole>()
	.AddEntityFrameworkStores<AppDbContext>();

builder.Services.Configure<IdentityOptions>(options =>
	options.User.RequireUniqueEmail = true
);

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

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IAuthorizationHandler, AdminOrOwnerHandler<Building>>();
builder.Services.AddScoped<IAuthorizationHandler, AdminOrOwnerHandler<Patch>>();
builder.Services.AddScoped<IAuthorizationHandler, AdminOrOwnerHandler<Storage>>();

builder.Services.AddScoped<IResourceService, ResourceService>();

builder.Services.AddAuthorization(options =>
	options.AddPolicy("AdminOrOwner", policy =>
		policy.Requirements.Add(new AdminOrOwnerRequirement()))
);

builder.Services.AddControllers();

builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IPatchService, PatchService>();
builder.Services.AddScoped<IBuildingService, BuildingService>();
builder.Services.AddScoped<IStorageService, StorageService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();

WebApplication app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers().RequireAuthorization(policyNames: "AdminOrOwner");

using (IServiceScope scope = app.Services.CreateScope()) {
	RoleManager<IdentityRole> roleManager = scope.ServiceProvider
		.GetRequiredService<RoleManager<IdentityRole>>();

	string[] roles = { "Admin", "Player" };
	foreach (string role in roles) {
		if (!roleManager.RoleExistsAsync(role).Result) {
			roleManager.CreateAsync(new IdentityRole(role)).Wait();
		}
	}
}

app.Run();
