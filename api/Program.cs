using api.Data;
using api.Interfaces;
using api.Repository;
using Microsoft.AspNetCore.Hosting.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//add controllers
builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ApplicationDBContext>(options =>{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddScoped<IBlogRepository,BlogRepository>();
builder.Services.AddScoped<IRouteRepository,RouteRepository>();
//wrm accepteert die stepgoal niet?
builder.Services.AddScoped<IStepgoalRepository,StepgoalRepository>();
builder.Services.AddScoped<IUserRepository,UserRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();


app.Run();


