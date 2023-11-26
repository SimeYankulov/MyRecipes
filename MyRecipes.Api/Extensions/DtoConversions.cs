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

        public static RecipeDto ConverToDto(this Recipe recipe,
                                                    RecipeCategory recipeCategory)
        {
            return new RecipeDto
            {
                Id = recipe.Id,
                Title = recipe.Title,
                Description = recipe.Description,
                ImageUrl = recipe.ImageUrl,
                CategoryId = recipeCategory.Id,
                Category = recipeCategory.Name
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
