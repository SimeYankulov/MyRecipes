using Microsoft.AspNetCore.Components;
using MyRecipes.Models.Dtos;
using MyRecipes.Web.Services.Contracts;

namespace MyRecipes.Web.Pages
{
    public class RecipeBookBase:ComponentBase
    {
        [Inject]
        public IRecipeBookService RecipeBookService { get; set; }
        
        public IEnumerable<RecipeBookItemDto> items { get; set; }
        public String ErrorMessage { get; set; }


        protected override async Task OnInitializedAsync()
        {
            try
            {
                items = await RecipeBookService.GetItems(HardCoded.UserId);
            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
            }
        }
    }
}
