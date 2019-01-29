using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using MyRecipes.Models;
using MyRecipes.Views;
using MyRecipes.Services;
using System.Linq;


namespace MyRecipes.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<MyRecipe> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "My Recipes";
            Items = new ObservableCollection<MyRecipe>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, MyRecipe>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as MyRecipe;
                Items.Add(newItem);                
                await App.RecipesRepo.AddNewRecipeAsync(newItem.Title, newItem.Ingredients, newItem.Description);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            await App.RecipesRepo.AddAllRecipesAsync();

            try
            {
                Items.Clear();
                var items = RecipesRepository.Recipes;
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}