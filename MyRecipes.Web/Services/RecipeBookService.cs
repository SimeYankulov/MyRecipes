using MyRecipes.Models.Dtos;
using MyRecipes.Web.Services.Contracts;
using System.Net.Http.Json;

namespace MyRecipes.Web.Services
{
    public class RecipeBookService : IRecipeBookService
    {
        private readonly HttpClient httpClient;

        public RecipeBookService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<RecipeBookItemDto> AddItem(RecipeBookItemToAddDto item)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync<RecipeBookItemToAddDto>("api/RecipeBook", item);

                if (response.IsSuccessStatusCode)
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(RecipeBookItemDto);
                    }

                    return await response.Content.ReadFromJsonAsync<RecipeBookItemDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();

                    throw new Exception($"Http status:{response.StatusCode} Message -{message}");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<RecipeBookItemDto>> GetItems(int userId)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/RecipeBook/{userId}/GetItems");

                if (response.IsSuccessStatusCode)
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<RecipeBookItemDto>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<RecipeBookItemDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();

                    throw new Exception($"Http status code: {response.StatusCode} Message :{message}");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
