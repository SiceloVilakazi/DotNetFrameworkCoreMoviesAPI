global using Microsoft.EntityFrameworkCore;
global using Movies.BusinessEntities;
global using Movies.BusinessLogic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<MovieService>();
builder.Services.AddScoped<MovieActorService>();
builder.Services.AddScoped<ActorService>();
builder.Services.AddScoped<AgentService>();
builder.Services.AddScoped<ActorAgentService>();

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
  
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
