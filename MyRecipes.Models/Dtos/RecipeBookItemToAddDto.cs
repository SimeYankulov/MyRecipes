using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipes.Models.Dtos
{
    public class RecipeBookItemToAddDto
    {
        public int RecipeBookId { get; set; }
        public int RecipeId { get; set; }
    }
}
