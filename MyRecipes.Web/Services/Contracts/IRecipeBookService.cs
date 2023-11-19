using MyRecipes.Models.Dtos;

namespace MyRecipes.Web.Services.Contracts
{
    public interface IRecipeBookService   
    {
        Task<IEnumerable<RecipeBookItemDto>> GetItems(int userId);
        Task<RecipeBookItemDto> AddItem(RecipeBookItemToAddDto item);

    }
}
