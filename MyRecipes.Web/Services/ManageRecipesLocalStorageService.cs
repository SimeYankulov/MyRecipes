using Blazored.LocalStorage;
using MyRecipes.Models.Dtos;
using MyRecipes.Web.Services.Contracts;
using System.Net.NetworkInformation;

namespace MyRecipes.Web.Services
{
    public class ManageRecipesLocalStorageService : IManageRecipesLocalStorageService
    {
        private readonly ILocalStorageService localStorageService;
        private readonly IRecipeService recipeService;

        private const string key = "RecipeCollection";

        public ManageRecipesLocalStorageService(ILocalStorageService localStorageService,
                                                   IRecipeService recipeService)
        {
            this.localStorageService = localStorageService;
            this.recipeService = recipeService;
        }

        public async Task<IEnumerable<RecipeDto>> GetCollection()
        {
            return await localStorageService.GetItemAsync<IEnumerable<RecipeDto>>(key)
                          ?? await AddCollection();
        }
        public async Task RemoveCollection()
        {
            await localStorageService.RemoveItemAsync(key);
        }

        private async Task<IEnumerable<RecipeDto>> AddCollection()
        {
            var recipeCollection = await recipeService.GetItems();

            if (recipeCollection != null)
            {
                await localStorageService.SetItemAsync(key, recipeCollection);
            }
            return recipeCollection;
        }
    }
}
