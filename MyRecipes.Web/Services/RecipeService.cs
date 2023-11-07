using MyRecipes.Models.Dtos;
using MyRecipes.Web.Services.Contracts;
using System.Net.Http.Json;

namespace MyRecipes.Web.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly HttpClient httpClient;

        public RecipeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<RecipeDto> GetItem(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Recipe/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.NoContent) 
                    {
                        return default(RecipeDto);
                    }
                    return await response.Content.ReadFromJsonAsync<RecipeDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} message: {message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public async Task<IEnumerable<RecipeDto>> GetItems()
        {
            try
            {
                var response = await this.httpClient.GetAsync("api/Recipe");

                if (response.IsSuccessStatusCode)
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<RecipeDto>();
                    }

                    return await response.Content.ReadFromJsonAsync<IEnumerable<RecipeDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} message: {message}");
                }
            }
            
            catch (Exception)
            {
                throw;
            }
        }
    }
}
