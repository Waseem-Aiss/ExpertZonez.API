using ExpertZonez.API.Data;
using ExpertZonez.API.Repositories.Implementation;
using ExpertZonez.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddControllers();

builder.Services.AddScoped<IAdminRepository,AdminRepository >();
builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<IWorkerRepository, WorkerRepository>();

builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen(); 
builder.Services.AddOpenApi();

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
