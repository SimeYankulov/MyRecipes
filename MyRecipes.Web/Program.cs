using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyRecipes.Web;
using MyRecipes.Web.Services;
using MyRecipes.Web.Services.Contracts;

var builder = WebAssemblyHostBuilder.CreateDefault(args);


builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7102/") });

builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IRecipeBookService, RecipeBookService>();

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<IManageRecipesLocalStorageService, ManageRecipesLocalStorageService>();
builder.Services.AddScoped<IManageRecipeBookItemsLocalStorageService, ManageRecipeBookItemsLocalStorageService>();


await builder.Build().RunAsync();
