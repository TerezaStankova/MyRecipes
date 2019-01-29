using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyRecipes.Models;
using SQLite;
using System.Collections.ObjectModel;

namespace MyRecipes.Services
{
    public class RecipesRepository
    {
        public static IList<MyRecipe> Recipes { get; set; }
        SQLiteAsyncConnection database;
        public string StatusMessage { get; set; }

        public RecipesRepository(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<MyRecipe>().Wait();
            Recipes = new ObservableCollection<MyRecipe>();
        }

        public Task<List<MyRecipe>> GetItemsAsync()
        {
            return database.Table<MyRecipe>().ToListAsync();
        }

        public Task<MyRecipe> GetItemAsync(int id)
        {
            return database.Table<MyRecipe>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(MyRecipe item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(MyRecipe item)
        {
            return database.DeleteAsync(item);
        }

        public async Task AddNewRecipeAsync(string title, string ingredients, string description)
        {
            int result = 0;
            try
            {
                //basic validation to ensure a title was entered
                if (string.IsNullOrEmpty(title))
                    throw new Exception("Title required");

                if (string.IsNullOrEmpty(description))
                    throw new Exception("Description required");

                MyRecipe recipe = new MyRecipe { Title = title, Description = description, Ingredients = ingredients };


                result = await database.InsertAsync(recipe);
                List<MyRecipe> recipes;
                recipes = await database.Table<MyRecipe>().OrderBy(a => a.Title).ToListAsync();
                Recipes.Clear();
                foreach (var c in recipes) Recipes.Add(c);

                //StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, title);
            }
            catch (Exception ex)
            {
                //StatusMessage = string.Format("Failed to add {0}. Error: {1}", title, ex.Message);
            }
        }

        public async Task<List<MyRecipe>> GetAllRecipesAsync()
        {
            try
            {
                Recipes = await database.Table<MyRecipe>().OrderBy(a => a.Title).ToListAsync();
                return await database.Table<MyRecipe>().OrderBy(a => a.Title).ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<MyRecipe>();
        }

        public async Task AddAllRecipesAsync()
        {
            try
            {
                List<MyRecipe> recipes;
                recipes = await database.Table<MyRecipe>().OrderBy(a => a.Title).ToListAsync();
                foreach (var recipe in recipes) Recipes.Add(recipe);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
        }
    }
}
