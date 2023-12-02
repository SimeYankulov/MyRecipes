using MyRecipes.Api.Entities;
using MyRecipes.Models.Dtos;

namespace MyRecipes.Api.Extensions
{
    public static class DtoConversions
    {
        public static IEnumerable<RecipeCategoryDto> ConvertToDto(this IEnumerable<RecipeCategory> recipeCategories)
        {
            return (from recipeCategory in recipeCategories
                    select new RecipeCategoryDto
                    {
                        Id = recipeCategory.Id,
                        Name = recipeCategory.Name

                    }).ToList();
        }
        public static IEnumerable<RecipeDto> ConverToDto(this IEnumerable<Recipe> recipes)
        {
            return (from recipe in recipes
                    select new RecipeDto
                    {
                        Id = recipe.Id,
                        Title = recipe.Title,
                        Description = recipe.Description,
                        ImageUrl = recipe.ImageUrl,
                        CategoryId = recipe.RecipeCategory.Id,
                        Category = recipe.RecipeCategory.Name
                    
                    }).ToList();
        }

        public static RecipeDto ConverToDto(this Recipe recipe)
        {
            return new RecipeDto
            {
                Id = recipe.Id,
                Title = recipe.Title,
                Description = recipe.Description,
                ImageUrl = recipe.ImageUrl,
                CategoryId = recipe.RecipeCategory.Id,
                Category = recipe.RecipeCategory.Name
            };
        }
        
        public static IEnumerable<RecipeBookItemDto> ConverToDto(this IEnumerable<RecipeBookItem> recipeBookItems,
                                                                   IEnumerable<Recipe> recipes)
        {
            return (from recipeBookItem in recipeBookItems
                    join recipe in recipes
                    on recipeBookItem.RecipeId equals recipe.Id
                    select new RecipeBookItemDto
                    {
                    
                        Id = recipeBookItem.Id,
                        RecipeId = recipeBookItem.RecipeId,
                        RecipeTitle = recipe.Title,
                        RecipeDescription = recipe.Description,
                        RecipeImageUrl = recipe.ImageUrl,
                        RecipeBookId = recipeBookItem.RecipeBookId
                    
                    }).ToList();
        }

        public static RecipeBookItemDto ConverToDto(this RecipeBookItem recipeBookItem,
                                                           Recipe recipe)
        {
            return new RecipeBookItemDto
            {
                Id = recipeBookItem.Id,
                RecipeId = recipeBookItem.RecipeId,
                RecipeTitle = recipe.Title,
                RecipeDescription = recipe.Description,
                RecipeImageUrl = recipe.ImageUrl,
                RecipeBookId = recipeBookItem.RecipeBookId

            };
        }

    }
}
