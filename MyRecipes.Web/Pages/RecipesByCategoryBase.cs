﻿using Microsoft.AspNetCore.Components;
using MyRecipes.Models.Dtos;
using MyRecipes.Web.Services.Contracts;

namespace MyRecipes.Web.Pages
{
    public class RecipesByCategoryBase:ComponentBase
    {
        [Parameter]
        public int CategoryId { get; set; }
        [Inject]
        public IRecipeService RecipeService { get; set; }
        [Inject]
        public IManageRecipesLocalStorageService manageRecipeLocalService { get; set; }

        public IEnumerable<RecipeDto> Recipes { get; set; }

        public string CategoryName { get; set; }
        public string ErrorMessage { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                Recipes = await GetRecipeCollectionByCategory(CategoryId);
                    //RecipeService.GetItemsByCategory(CategoryId);

                if(Recipes != null && Recipes.Count() > 0)
                {
                    var recipeDto = Recipes.FirstOrDefault(r => r.CategoryId == CategoryId);
                    if(recipeDto != null)
                    {
                        CategoryName = recipeDto.Category;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        private async Task<IEnumerable<RecipeDto>> GetRecipeCollectionByCategory(int categoryId)
        {
            var recipeCollection = await manageRecipeLocalService.GetCollection();

            if(recipeCollection != null)
            {
                return recipeCollection.Where(p => p.CategoryId == categoryId);
            }
            else
            {
                return await RecipeService.GetItemsByCategory(categoryId);
            }
        }
    }
}
