namespace MyRecipes.Api.Entities
{
    public class RecipeBookItem
    {
        public int Id { get; set; }
        public int RecipeBookId { get; set; }
        public int RecipeId { get; set; }

    }
}
