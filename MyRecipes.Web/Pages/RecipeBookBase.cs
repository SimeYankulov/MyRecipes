using Microsoft.AspNetCore.Components;
using MyRecipes.Models.Dtos;
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
