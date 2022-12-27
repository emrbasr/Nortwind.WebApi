using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace NorthwindConsole
{
    public class CategoryManager
    {
        List<Category> _categories;
        HttpClient _httpClient;
        public CategoryManager()
        {
            _categories = new();
            _httpClient = new();
            _httpClient.BaseAddress = new Uri(GenelTanimlar.NorthwindApiUri);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            try
            {



                var responce = _httpClient.GetAsync("api/categories").Result;
                if (responce.IsSuccessStatusCode)
                {
                    var content = await responce.Content.ReadAsStringAsync();
                    _categories = new List<Category>();
                    _categories = JsonConvert.DeserializeObject<List<Category>>(content);

                }
            }
            catch (Exception ex)
            {

                await Console.Out.WriteLineAsync(ex.Message);
            }


            return _categories;
        }

        public async Task<Category> GetCategorByIdAsync(int id)
        {
            Category category = new Category();
            try
            {
                var responce = _httpClient.GetAsync("api/categories/" + id.ToString()).Result;
                if (responce.IsSuccessStatusCode)
                {
                    var content = await responce.Content.ReadAsStringAsync();

                    category = JsonConvert.DeserializeObject<Category>(content);

                }
            }
            catch (Exception ex)
            {

                await Console.Out.WriteLineAsync(ex.Message);
            }


            return category;
        }


        public async Task PostCategoryAsync(Category category)
        {
            try
            {


                var json = JsonConvert.SerializeObject(category);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("api/categories", data);

                var result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {

                await Console.Out.WriteLineAsync(ex.Message);
            }
        }

        public async Task PutCategoryAsync(Category category)
        {
            try
            {
                var json = JsonConvert.SerializeObject(category);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var response = _httpClient.PutAsync("api/categories/" + category.id.ToString(), data).Result;

                var result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {

                await Console.Out.WriteLineAsync(ex.Message);
            }


        }


        public async Task DeleteCategory(int id)
        {
            try
            {

                var result = _httpClient.DeleteAsync("api/categories/" + id.ToString()).Result;

            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }

    }
}
