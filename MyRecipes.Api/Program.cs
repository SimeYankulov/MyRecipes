using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using MyRecipes.Api.Data;
using MyRecipes.Api.Repositories;
using MyRecipes.Api.Repositories.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyRecipesDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyRecipesConnection"))
    );

builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IRecipeBookRepository, RecipeBookRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{ 
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors( policy =>
    policy.WithOrigins("https://localhost:7050","https://localhost:7050")
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType)
    ); 

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
