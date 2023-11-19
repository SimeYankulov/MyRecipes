using Microsoft.EntityFrameworkCore;
using MyRecipes.Api.Data;
using MyRecipes.Api.Entities;
using MyRecipes.Api.Repositories.Contracts;
using MyRecipes.Models.Dtos;

namespace MyRecipes.Api.Repositories
{
    public class RecipeBookRepository : IRecipeBookRepository
    {
        private readonly MyRecipesDBContext myRecipesDBContext;

        public RecipeBookRepository(MyRecipesDBContext myRecipesDBContext)
        {
            this.myRecipesDBContext = myRecipesDBContext;
        }

        private async Task<bool> BookmarkExists(int bookmarkId, int recipeId)
        {
            return await this.myRecipesDBContext.RecipeBookItems.AnyAsync(b => b.RecipeBookId == bookmarkId
                                                                            && b.RecipeId == recipeId);
        }
        public async Task<RecipeBookItem> AddItem(RecipeBookItemToAddDto itemToAddDto)
        {
            if(await BookmarkExists(itemToAddDto.RecipeBookId,itemToAddDto.RecipeId) == false)
            {

                var item = await (from recipe in this.myRecipesDBContext.Recipes
                                  where recipe.Id == itemToAddDto.RecipeId
                                  select new RecipeBookItem
                                  {
                                      RecipeBookId = itemToAddDto.RecipeBookId,
                                      RecipeId = recipe.Id

                                  }).SingleOrDefaultAsync();

                if (item != null)
                {
                    var result = await this.myRecipesDBContext.RecipeBookItems.AddAsync(item);
                    await this.myRecipesDBContext.SaveChangesAsync();

                    return result.Entity;
                }

            }

            return null;
        }

        public Task<RecipeBookItem> DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<RecipeBookItem> GetItem(int id)
        {
            return await (from recipeBook in this.myRecipesDBContext.RecipeBooks
                          join recipeBookItem in this.myRecipesDBContext.RecipeBookItems
                          on recipeBook.Id equals recipeBookItem.RecipeBookId
                          where recipeBookItem.Id == id
                          select new RecipeBookItem
                          {

                              Id = recipeBookItem.Id,
                              RecipeId = recipeBookItem.RecipeId,
                              RecipeBookId = recipeBookItem.RecipeBookId

                          }).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<RecipeBookItem>> GetItems(int userId)
        {
            return await (from recipeBook in this.myRecipesDBContext.RecipeBooks
                          join recipeBookItem in this.myRecipesDBContext.RecipeBookItems
                          on recipeBook.Id equals recipeBookItem.RecipeBookId
                          where recipeBook.UserId == userId
                          select new RecipeBookItem
                          {
                              Id = recipeBookItem.Id,
                              RecipeId = recipeBookItem.RecipeId,
                              RecipeBookId = recipeBookItem.RecipeBookId
                          
                          }).ToListAsync();
        }
    }
}
