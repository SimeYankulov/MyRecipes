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

        public Task<RecipeCategory> GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Recipe> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Recipe>> GetItems()
        {

            var recipes = await this.myRecipesDBContext.Recipes.ToListAsync();

            return recipes;
            
        }
    }
}
