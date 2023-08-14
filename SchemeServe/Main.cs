using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SchemeServe;
using SchemeServe.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<JsonConverter, CustomLocationIdsConverter>();

builder.Services.AddScoped<OrganizationDbContext>();
builder.Services.AddSingleton<HttpClient>();

builder.Services.AddDbContext<OrganizationDbContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var run = builder.Build();

if (run.Environment.IsDevelopment())
{
    run.UseSwagger();
    run.UseSwaggerUI();
}

run.UseHttpsRedirection();

run.UseAuthorization();

run.MapControllers();

run.Run();