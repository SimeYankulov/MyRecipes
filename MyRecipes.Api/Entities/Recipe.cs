using System.Diagnostics.CodeAnalysis;

namespace MyRecipes.Api.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
    }
}
