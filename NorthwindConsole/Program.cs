namespace NorthwindConsole
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            CategoryManager manager = new CategoryManager();

            #region 1. Yontem
            //try
            //{

            //    HttpClient client = new HttpClient();
            //    client.BaseAddress = new Uri(GenelTanimlar.NorthwindApiUri);
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //    var responce = client.GetAsync("api/categories").Result;
            //    if (responce.IsSuccessStatusCode)
            //    {
            //        var content = await responce.Content.ReadAsStringAsync();
            //        List<Category> categories = new List<Category>();
            //        categories = JsonConvert.DeserializeObject<List<Category>>(content);

            //        foreach (var item in categories)
            //        {
            //            await Console.Out.WriteLineAsync(item.id + " " + item.name);

            //        }
            //    }
            //}
            //catch (Exception ex)
            //{

            //    await Console.Out.WriteLineAsync(ex.Message);
            //} 
            #endregion

            #region 2. Yontem Manager sisnifi ile calismak




            #region HttpGet ile Calismak
            //var result = manager.GetAllCategoriesAsync().Result;

            //foreach (var item in result)
            //{
            //    await Console.Out.WriteLineAsync(item.id + " " + item.name);
            //}

            //var result = manager.GetCategorByIdAsync(3).Result;
            //await Console.Out.WriteLineAsync(result.name);

            #endregion

            #region HttpPost ile calismak

            Category category = new Category { name = "Testil", description = "Tekstil" };
            manager.PostCategoryAsync(category);

            var result = manager.GetAllCategoriesAsync().Result;

            foreach (var item in result)
            {
                await Console.Out.WriteLineAsync(item.id + " " + item.name);
            }
            #endregion


            #region Put ile calismak

            //Category category = new Category { id = 10, name = "Erkek Giyim", description = "Erkek Giyim" };
            //manager.PutCategoryAsync(category);


            #endregion

            #region Delete işlemi

            //var sonuc = manager.DeleteCategory(10);

            //await Console.Out.WriteLineAsync(sonuc.Status.ToString());


            #endregion

            #endregion

        }
    }
}