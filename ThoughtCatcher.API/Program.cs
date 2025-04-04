using Microsoft.EntityFrameworkCore;
using ThoughtCatcher.Core.Interfaces;
using ThoughtCatcher.Data;
using ThoughtCatcher.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ThoughtCatcherDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<IThoughtRepository, ThoughtRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();