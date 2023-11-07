using Microsoft.AspNetCore.Components;
using MyRecipes.Models.Dtos;

namespace MyRecipes.Web.Pages
{
    public class DisplayRecipeBase:ComponentBase
    {
        [Parameter]
        public IEnumerable<RecipeDto> Recipes { get; set; }
        
    }
}
