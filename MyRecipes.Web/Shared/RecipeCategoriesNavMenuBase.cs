using Microsoft.AspNetCore.Components;
using MyRecipes.Models.Dtos;
using MyRecipes.Web.Services.Contracts;

namespace MyRecipes.Web.Shared
{
    public class RecipeCategoriesNavMenuBase:ComponentBase
    {
        [Inject]
        public IRecipeService RecipeService { get; set; }
        public IEnumerable<RecipeCategoryDto> RecipeCategoryDtos { get; set; }
    
        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                RecipeCategoryDtos = await RecipeService.GetRecipeCategories();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }

}
