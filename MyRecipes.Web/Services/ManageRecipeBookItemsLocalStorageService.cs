using Blazored.LocalStorage;
using MyRecipes.Models.Dtos;
using MyRecipes.Web.Services.Contracts;

namespace MyRecipes.Web.Services
{
    public class ManageRecipeBookItemsLocalStorageService : IManageRecipeBookItemsLocalStorageService
    {
        private readonly ILocalStorageService localStorageService;
        private readonly IRecipeBookService recipeBookService;

        private const string key = "RecipeBookCollection";

        public ManageRecipeBookItemsLocalStorageService(ILocalStorageService localStorageService,
                                                            IRecipeBookService recipeBookService)
        {
            this.localStorageService = localStorageService;
            this.recipeBookService = recipeBookService;
        }

        public async Task<List<RecipeBookItemDto>> GetCollectionn()
        {
            return await this.localStorageService.GetItemAsync<List<RecipeBookItemDto>>(key)
                            ?? await AddCollection();
        }

        public async Task RemoveCollectionn()
        {
            await this.localStorageService.RemoveItemAsync(key);
        }

        public async Task SaveCollection(List<RecipeBookItemDto> items)
        {
            await this.localStorageService.SetItemAsync(key, items);
        }

        private async Task<List<RecipeBookItemDto>> AddCollection()
        {
            var recipeBookCollection = await this.recipeBookService.GetItems(HardCoded.UserId);

            if(recipeBookCollection != null) 
            {
                await this.localStorageService.SetItemAsync(key, recipeBookCollection);

            }
            return recipeBookCollection;
        }
    }
}
