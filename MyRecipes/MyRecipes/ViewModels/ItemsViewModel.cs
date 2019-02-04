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
                await App.RecipesRepo.AddNewRecipeAsync(newItem);
            });

            MessagingCenter.Subscribe<ItemDetailPage, MyRecipe>(this, "UpdateItem", async (obj, item) =>
            {
                var newItem = item as MyRecipe;                
                await App.RecipesRepo.SaveItemAsync(newItem);
            });

            MessagingCenter.Subscribe<ItemDetailPage, MyRecipe>(this, "DeleteItem", async (obj, item) =>
            {
                var deleteItem = item as MyRecipe;
                //Items.Remove(deleteItem);
                await App.RecipesRepo.DeleteItemAsync(deleteItem);
                RecipesRepository.Recipes.Remove(deleteItem);
                try
                {
                    Items.Clear();
                    var items = RecipesRepository.Recipes;
                    foreach (MyRecipe i in items)
                    {
                        Items.Add(i);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            });
        }

        

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            await App.RecipesRepo.GetAllRecipesAsync();

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