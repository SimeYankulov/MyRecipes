using MyRecipes.Models.Dtos;
using MyRecipes.Web.Services.Contracts;
using System.Net.Http.Json;

namespace MyRecipes.Web.Services
{
    public class RecipeBookService : IRecipeBookService
    {
        private readonly HttpClient httpClient;

        public event Action<int> OnRecipeBookChanged;
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

        public async Task<RecipeBookItemDto> DeleteItem(int id)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"api/RecipeBook/{id}");

                if(response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<RecipeBookItemDto>(); 
                }
                return default;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<RecipeBookItemDto>> GetItems(int userId)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/RecipeBook/{userId}/GetItems");

                if (response.IsSuccessStatusCode)
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<RecipeBookItemDto>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<RecipeBookItemDto>>();
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

        public void RaiseEventOnRecipeBookChanged(int qty)
        {
            if(OnRecipeBookChanged != null)
            {
                OnRecipeBookChanged.Invoke(qty);
            }
        }
    }
}
