using ExpertZonez.API.Data;
using ExpertZonez.API.Repositories.Implementation;
using ExpertZonez.API.Repositories.Implementation.App_Implementation;
using ExpertZonez.API.Repositories.Interfaces;
using ExpertZonez.API.Repositories.Interfaces.App_Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddControllers();

builder.Services.AddScoped<IAdminRepository,AdminRepository >();
builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<IWorkerRepository, WorkerRepository>();
builder.Services.AddScoped<IHomeRepository, HomeRepository>();

builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen(); 
builder.Services.AddOpenApi();
builder.Services.AddCors(options =>
{
    options.AddPolicy("expert-zonez-policy", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // React Url for API
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    app.UseSwaggerUI();
}

app.UseCors("expert-zonez-policy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
