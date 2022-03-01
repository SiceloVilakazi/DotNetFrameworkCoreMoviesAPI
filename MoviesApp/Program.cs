global using Microsoft.EntityFrameworkCore;
global using Movies.BusinessEntities;
global using Movies.BusinessLogic;
global using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<MovieService>();
builder.Services.AddScoped<MovieActorService>();
builder.Services.AddScoped<ActorService>();
builder.Services.AddScoped<AgentService>();
builder.Services.AddScoped<ActorAgentService>();
#region Movie Handlers
builder.Services.AddMediatR(typeof(GetMovieListHandler).Assembly);
builder.Services.AddMediatR(typeof(DeleteMovieHandler).Assembly);
builder.Services.AddMediatR(typeof(EditMovieHandler).Assembly);
builder.Services.AddMediatR(typeof(AddMovieHandler).Assembly);
builder.Services.AddMediatR(typeof(GetMovieByIdHandler).Assembly);
#endregion
#region Actor Handlers
builder.Services.AddMediatR(typeof(GetActorListHandler).Assembly);
builder.Services.AddMediatR(typeof(DeleteActorHandler).Assembly);
builder.Services.AddMediatR(typeof(EditActorHandler).Assembly);
builder.Services.AddMediatR(typeof(AddActorHandler).Assembly);
builder.Services.AddMediatR(typeof(GetActorByIdHandler).Assembly);
builder.Services.AddMediatR(typeof(GetActorNamesByMovieHandler).Assembly);
builder.Services.AddMediatR(typeof(GetTotalActorsByAgentHandler).Assembly);
#endregion

#region Agent Handlers
builder.Services.AddMediatR(typeof(GetAgentListHandler).Assembly);
builder.Services.AddMediatR(typeof(DeleteAgentHandler).Assembly);
builder.Services.AddMediatR(typeof(EditAgentHandler).Assembly);
builder.Services.AddMediatR(typeof(AddAgentHandler).Assembly);
builder.Services.AddMediatR(typeof(GetAgentByIdHandler).Assembly);
#endregion

#region ActorAgent Handlers 
builder.Services.AddMediatR(typeof(GetActorAgentsListHandler).Assembly);
builder.Services.AddMediatR(typeof(DeleteActorAgentHandler).Assembly);
builder.Services.AddMediatR(typeof(EditActorAgentHandler).Assembly);
builder.Services.AddMediatR(typeof(AddActorAgentHandler).Assembly);
builder.Services.AddMediatR(typeof(GetActorAgentByIdHandler).Assembly);
#endregion

#region MovieActor Handlers
builder.Services.AddMediatR(typeof(GetMovieActorHandler).Assembly);
builder.Services.AddMediatR(typeof(DeleteMovieActorHandler).Assembly);
builder.Services.AddMediatR(typeof(EditMovieActorHandler).Assembly);
builder.Services.AddMediatR(typeof(AddMovieActorHandler).Assembly);
builder.Services.AddMediatR(typeof(GetMovieActorByIdHandler).Assembly);
#endregion

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

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
