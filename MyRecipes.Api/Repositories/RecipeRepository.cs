using Microsoft.EntityFrameworkCore;
using MyRecipes.Api.Data;
using MyRecipes.Api.Entities;
using MyRecipes.Api.Repositories.Contracts;

namespace MyRecipes.Api.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly MyRecipesDBContext myRecipesDBContext;

        public RecipeRepository(MyRecipesDBContext myRecipesDBContext) 
        {
            this.myRecipesDBContext = myRecipesDBContext;
        }
        public async Task<IEnumerable<RecipeCategory>> GetCategories()
        {
            var categories = await this.myRecipesDBContext.RecipeCategories.ToListAsync();

            return categories;
        }

        public async Task<RecipeCategory> GetCategory(int id)
        {
            var category = await this.myRecipesDBContext.RecipeCategories.SingleOrDefaultAsync(c => c.Id == id);

            return category;
        }

        public async Task<Recipe> GetItem(int id)
        {
            var recipe = await this.myRecipesDBContext.Recipes.FindAsync(id);

            return recipe;
        }

        public async Task<IEnumerable<Recipe>> GetItems()
        {

            var recipes = await this.myRecipesDBContext.Recipes.ToListAsync();

            return recipes;
            
        }
    }
}
