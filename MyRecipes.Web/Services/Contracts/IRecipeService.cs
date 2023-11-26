using MyRecipes.Models.Dtos;

namespace MyRecipes.Web.Services.Contracts
{
    public interface IRecipeService
    {
        Task<IEnumerable<RecipeDto>> GetItems();
        Task <RecipeDto> GetItem(int id);
        Task<IEnumerable<RecipeCategoryDto>> GetRecipeCategories();
        Task<IEnumerable<RecipeDto>> GetItemsByCategory(int categoryId);
    }
}
