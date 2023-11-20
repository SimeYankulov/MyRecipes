using MyRecipes.Models.Dtos;

namespace MyRecipes.Web.Services.Contracts
{
    public interface IRecipeBookService   
    {
        Task<List<RecipeBookItemDto>> GetItems(int userId);
        Task<RecipeBookItemDto> AddItem(RecipeBookItemToAddDto item);
        Task<RecipeBookItemDto> DeleteItem(int id);
    }
}
