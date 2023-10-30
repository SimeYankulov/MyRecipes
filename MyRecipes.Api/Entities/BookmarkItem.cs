namespace MyRecipes.Api.Entities
{
    public class BookmarkItem
    {
        public int Id { get; set; }
        public int BookmarkId { get; set; }
        public int RecipeId { get; set; }

    }
}
