using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyRecipes.Models
{
    public class RecipeManager
    {
        const string Url = "http://www.recipepuppy.com/api/";
       
        //private string authorizationKey;

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("q", "omelet");
            return client;
        }

        public async Task<IEnumerable<Recipe>> GetAll()
        {
            // TODO: use GET to retrieve books
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(Url);
            Result allResult = JsonConvert.DeserializeObject<Result>(result);
            List<Recipe> recipes = allResult.results;
            return recipes;
        }

        public async Task<IEnumerable<Recipe>> GetAll(string query)
        {
            // TODO: use GET to retrieve books
            HttpClient client = GetClient();
            string queryUrl = Url + "?q=" + query;
            string result = await client.GetStringAsync(queryUrl);
            Result allResult = JsonConvert.DeserializeObject<Result>(result);
            List<Recipe> recipes = allResult.results;
            return recipes;
        }
    }
}
