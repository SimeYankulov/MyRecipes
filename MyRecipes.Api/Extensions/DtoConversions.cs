using MyRecipes.Api.Entities;
using MyRecipes.Models.Dtos;

namespace MyRecipes.Api.Extensions
{
    public static class DtoConversions
    {
        public static IEnumerable<RecipeDto> ConverToDto(this IEnumerable<Recipe> recipes, 
                                                           IEnumerable<RecipeCategory> recipeCategories)
        {
            return (from recipe in recipes
                    join recipeCategory in recipeCategories
                    on recipe.CategoryId equals recipeCategory.Id
                    select new RecipeDto
                    {
                        Id = recipe.Id,
                        Title = recipe.Title,
                        Description = recipe.Description,
                        ImageUrl = recipe.ImageUrl,
                        CategoryId = recipeCategory.Id,
                        Category = recipeCategory.Name
                    
                    }).ToList();
        }
    }
}
