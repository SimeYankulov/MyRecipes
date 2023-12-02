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
        public IManageRecipesLocalStorageService manageRecipeLocalService { get; set; }

        [Inject]
        public IManageRecipeBookItemsLocalStorageService manageRecipeBookItemsLocalService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }    
        public RecipeDto Recipe{ get; set; }

        public string ErrorMessage { get; set; }

        private List<RecipeBookItemDto> RecipeBookItems{ get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                RecipeBookItems = await manageRecipeBookItemsLocalService.GetCollectionn();
                Recipe = await GetRecipeById(Id);
                    //RecipeService.GetItem(Id);
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

                if(recipeBookItemDto != null)
                {
                    RecipeBookItems.Add(recipeBookItemDto);
                    await manageRecipeBookItemsLocalService.SaveCollection(RecipeBookItems);
                }

                NavigationManager.NavigateTo("/RecipeBook");

            }
            catch (Exception)
            {

            }
        }

        private async Task<RecipeDto> GetRecipeById(int id)
        {
            var recipeDtos = await manageRecipeLocalService.GetCollection();

            if(recipeDtos != null)
            {
                return recipeDtos.SingleOrDefault(p => p.Id == id);
            }

            return null;
        }
    }
}

       