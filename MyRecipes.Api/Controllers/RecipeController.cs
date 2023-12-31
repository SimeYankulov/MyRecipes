﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyRecipes.Api.Extensions;
using MyRecipes.Api.Repositories.Contracts;
using MyRecipes.Models.Dtos;

namespace MyRecipes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepository recipeRepository;

        public RecipeController(IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeDto>>> GetItems()
        {
            try
            {
                var recipes = await this.recipeRepository.GetItems();

                if (recipes == null)
                {
                    return NotFound();
                }
                else
                {
                    var recipeDtos = recipes.ConverToDto();

                    return Ok(recipeDtos);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error retriving data from database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<RecipeDto>> GetItem(int id)
        {
            try
            {
                var recipe = await this.recipeRepository.GetItem(id);
                

                if(recipe == null)
                {
                    return BadRequest();
                }
                else
                {
                    var recipeDto = recipe.ConverToDto();
                        
                    return Ok(recipeDto);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error retriving data from database");
            }
        }

        [HttpGet]
        [Route(nameof(GetRecipeCategories))]
        public async Task<ActionResult<IEnumerable<RecipeCategoryDto>>> GetRecipeCategories()
        {
            try
            {
                var recipeCategories = await recipeRepository.GetCategories();

                var recipeCategoryDtos = recipeCategories.ConvertToDto();

                return Ok(recipeCategoryDtos);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                                  "Error retriving data from database");
            }
        }
        [HttpGet]
        [Route("{categoryId}/GetItemsByCategory")]
        public async Task<ActionResult<IEnumerable<RecipeDto>>> GetItemsByCategory(int categoryId)
        {
            try
            {
                var recipes = await recipeRepository.GetItemsByCategory(categoryId);
 
                var recipeDtos = recipes.ConverToDto();

                return Ok(recipeDtos);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                                 "Error retriving data from database");
            }

        }
    }
}
