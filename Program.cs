﻿using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddScoped<IStatService, StatService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();

WebApplication app = builder.Build();
app.MapControllers();
app.Run();
