using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyRecipes.Api.Data;
using MyRecipes.Api.Extensions;
using MyRecipes.Api.Repositories.Contracts;
using MyRecipes.Models.Dtos;

namespace MyRecipes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeBookController : ControllerBase
    {
        private readonly IRecipeBookRepository recipeBookRepository;
        private readonly IRecipeRepository recipeRepository;

        public RecipeBookController(IRecipeBookRepository recipeBookRepository,
                                    IRecipeRepository recipeRepository)
        {
            this.recipeBookRepository = recipeBookRepository;
            this.recipeRepository = recipeRepository;
        }

        [HttpGet]
        [Route("{userId}/GetItems")]
        public async Task<ActionResult<IEnumerable<RecipeBookItemDto>>> GetItems(int userId)
        {
            try
            {
                var recipeBookItems = await this.recipeBookRepository.GetItems(userId);

                if (recipeBookItems == null)
                {
                    return NoContent();
                }

                var recipes = await this.recipeRepository.GetItems();

                if (recipes == null)
                {
                    throw new Exception("No recipes exist in the system");
                }

                var recipeBookItemsDto = recipeBookItems.ConverToDto(recipes);

                return Ok(recipeBookItemsDto);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<RecipeBookItemDto>> GetItem(int id)
        {
            try
            {
                var recipeBookItem = await this.recipeBookRepository.GetItem(id);
                if(recipeBookItem == null)
                {
                    return NotFound();
                }
                var recipe = await recipeRepository.GetItem(recipeBookItem.RecipeId);

                if(recipe == null)
                {
                    return NotFound();
                }
                
                var recipeBookItemDto = recipeBookItem.ConverToDto(recipe);
                
                return Ok(recipeBookItemDto);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<RecipeBookItemToAddDto>> PostItem([FromBody] RecipeBookItemToAddDto recipeBookItemToAddDto)
        {
            try
            {
                var newRecipeBookItem = await this.recipeBookRepository.AddItem(recipeBookItemToAddDto);
                
                if(newRecipeBookItem == null)
                {
                    return NoContent();
                }

                var recipe = await recipeRepository.GetItem(newRecipeBookItem.RecipeId);

                if(recipe == null)
                {
                    throw new Exception($"Something went wrong when attemting to retrieve recipe (recipeId:({recipeBookItemToAddDto.RecipeId})");
                }

                var newRecipeBookItemDto = newRecipeBookItem.ConverToDto(recipe);

                return CreatedAtAction(nameof(GetItem), new {id = newRecipeBookItemDto.Id}, newRecipeBookItemDto);
           
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<RecipeBookItemDto>> DeleteItem(int id)
        {
            try
            {
                var recipeBookItem = await this.recipeBookRepository.DeleteItem(id);

                if(recipeBookItem == null)
                {
                    return NotFound();
                }
                
                var recipe = await this.recipeRepository.GetItem(recipeBookItem.RecipeId);

                if(recipe == null)
                {
                    return NotFound();
                }

                var recipeBookItemDto = recipeBookItem.ConverToDto(recipe);

                return Ok(recipeBookItemDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
