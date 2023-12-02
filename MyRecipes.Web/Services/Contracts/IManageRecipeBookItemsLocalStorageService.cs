using MyRecipes.Models.Dtos;

namespace MyRecipes.Web.Services.Contracts
{
    public interface IManageRecipeBookItemsLocalStorageService
    {
        Task<List<RecipeBookItemDto>> GetCollectionn();
        Task RemoveCollectionn();
        Task SaveCollection(List<RecipeBookItemDto> items);
    }
}