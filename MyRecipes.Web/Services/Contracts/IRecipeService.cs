using MyRecipes.Models.Dtos;

namespace MyRecipes.Web.Services.Contracts
{
    public interface IRecipeService
    {
        Task<IEnumerable<RecipeDto>> GetItems();

        Task <RecipeDto> GetItem(int id);


    }
}
