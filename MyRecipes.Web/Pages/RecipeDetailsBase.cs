using Microsoft.AspNetCore.Components;
using MyRecipes.Models.Dtos;
using MyRecipes.Web.Services.Contracts;

namespace MyRecipes.Web.Pages
{
    public class RecipeDetailsBase:ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IRecipeService RecipeService{ get; set; }
        [Inject]
        public IRecipeBookService RecipeBookService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }    
        public RecipeDto Recipe{ get; set; }

        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Recipe = await RecipeService.GetItem(Id);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        protected async Task AddToRecipeBook_Click(RecipeBookItemToAddDto item)
        {
            try
            {
                var recipeBookItemDto = await RecipeBookService.AddItem(item);
                NavigationManager.NavigateTo("/RecipeBook");
            }
            catch (Exception)
            {

            }
        }
    }
}

       