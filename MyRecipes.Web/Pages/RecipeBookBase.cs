using Microsoft.AspNetCore.Components;
using MyRecipes.Models.Dtos;
using MyRecipes.Web.Services;
using MyRecipes.Web.Services.Contracts;

namespace MyRecipes.Web.Pages
{
    public class RecipeBookBase:ComponentBase
    {
        [Inject]
        public IRecipeBookService RecipeBookService { get; set; }
        
        public List<RecipeBookItemDto> items { get; set; }
        public String ErrorMessage { get; set; }


        protected override async Task OnInitializedAsync()
        {
            try
            {
                items = await RecipeBookService.GetItems(HardCoded.UserId);

                var count = items.Count();

                RecipeBookService.RaiseEventOnRecipeBookChanged(count);

            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
            }
        }

        protected async Task DeleteRecipeBookItem_Click(int id)
        {
            var item = await RecipeBookService.DeleteItem(id);

            RemoveItem(id);

            RecipeBookService.RaiseEventOnRecipeBookChanged(items.Count);
        }
        private RecipeBookItemDto GetRecipeBookItem(int id)
        {
            return items.FirstOrDefault(i => i.Id == id);
        }
        private void RemoveItem(int id)
        {
            var item = GetRecipeBookItem(id);

            items.Remove(item);

        }
    }
}
