using MyRecipes.Api.Entities;

namespace MyRecipes.Api.Repositories.Contracts
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<Recipe>> GetItems();
        Task<IEnumerable<RecipeCategory>> GetCategories();
        Task<Recipe> GetItem(int id);
        Task<RecipeCategory> GetCategory(int id);

    }
}
