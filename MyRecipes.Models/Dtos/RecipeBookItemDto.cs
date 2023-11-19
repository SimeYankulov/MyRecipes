using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipes.Models.Dtos
{
    public class RecipeBookItemDto
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int RecipeBookId { get; set; }
        public string RecipeTitle { get; set; }
        public string RecipeDescription { get; set; }
        public string RecipeImageUrl { get; set; }
    }
}
