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
                var recipeCategories = await this.recipeRepository.GetCategories();

                if(recipes == null || recipeCategories == null)
                {
                    return NotFound();
                }
                else
                {
                    var recipeDtos = recipes.ConverToDto(recipeCategories);

                    return Ok(recipeDtos);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error retriving data from database");
            }
        }
    }
}
