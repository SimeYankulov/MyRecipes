using Microsoft.AspNetCore.Components;
using MyRecipes.Models.Dtos;
using MyRecipes.Web.Services.Contracts;

namespace MyRecipes.Web.Pages
{
    public class RecipesBase:ComponentBase
    {
        [Inject]
        public IRecipeService RecipeService { get; set; }

        [Inject]
        public IRecipeBookService RecipeBookService { get; set; }

        public IEnumerable<RecipeDto> Recipes { get; set; }

        public String ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                
                Recipes = await RecipeService.GetItems();

                var recipeBookItems = await RecipeBookService.GetItems(HardCoded.UserId);

                var totalQty = recipeBookItems.Count();

                RecipeBookService.RaiseEventOnRecipeBookChanged(totalQty);


            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
            }
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
