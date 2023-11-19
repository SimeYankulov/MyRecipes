using MyRecipes.Api.Entities;
using MyRecipes.Models.Dtos;

namespace MyRecipes.Api.Repositories.Contracts
{
    public interface IRecipeBookRepository
    {
        Task<RecipeBookItem> AddItem(RecipeBookItemToAddDto bookmarkItemToAddDto);
        Task<RecipeBookItem> DeleteItem(int id);
        Task<RecipeBookItem> GetItem(int id);
        Task<IEnumerable<RecipeBookItem>> GetItems(int id);
    }
}
