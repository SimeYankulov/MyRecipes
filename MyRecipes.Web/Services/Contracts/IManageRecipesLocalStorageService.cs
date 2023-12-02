using MyRecipes.Models.Dtos;

namespace MyRecipes.Web.Services.Contracts
{
    public interface IManageRecipesLocalStorageService
    {
        Task<IEnumerable<RecipeDto>> GetCollection();
        Task RemoveCollection();
    }
}
