using Microsoft.AspNetCore.Components;
using MyRecipes.Models.Dtos;
using MyRecipes.Web.Services.Contracts;

namespace MyRecipes.Web.Pages
{
    public class RecipesBase:ComponentBase
    {
        [Inject]
        public IRecipeService RecipeService { get; set; }

        public IEnumerable<RecipeDto> Recipes { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Recipes = await RecipeService.GetItems();
        }

        protected IOrderedEnumerable<IGrouping<int, RecipeDto>> GetGroupedRecipesByCategory()
        {
            return from recipe in Recipes
                   group recipe by recipe.CategoryId into recipeByCatGroup
                   orderby recipeByCatGroup.Key
                   select recipeByCatGroup;
        }

        protected string GetCategoryName(IGrouping<int, RecipeDto> groupedRecipeDtos)
        {
            return groupedRecipeDtos.FirstOrDefault(rg => rg.CategoryId == groupedRecipeDtos.Key).Category;
        }
    }
}
