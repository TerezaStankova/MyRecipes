using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MyRecipes.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MyRecipes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {

        readonly IList<Recipe> recipes = new ObservableCollection<Recipe>();
        readonly RecipeManager manager = new RecipeManager();

        public AboutPage()
        {         
            InitializeComponent();
            BindingContext = recipes;
        }

        async void OnRefresh(object sender, EventArgs e)
        {
            // Turn on network indicator
            this.IsBusy = true;

            try
            {
                var recipeCollection = await manager.GetAll();

                foreach (Recipe recipe in recipeCollection)
                {
                    if (recipe.thumbnail == "") recipe.thumbnail = "http://www.cookuk.co.uk/images/children_spaghetti_face/children-recipe-pic1-smaller.gif";
                    if (recipes.All(b => b.title != recipe.title))
                        recipes.Add(recipe);
                }
            }
            finally
            {
                this.IsBusy = false;
            }
        }

        async void OnFindButtonClicked(object sender, EventArgs e)
        {
            // Turn on network indicator
            this.IsBusy = true;

            try
            {
                recipes.Clear();
                string query = newRecipe.Text;
                var recipeCollection = await manager.GetAll(query);

                foreach (Recipe recipe in recipeCollection)
                {
                    if (recipe.thumbnail == "") recipe.thumbnail = "RecipeBook.png";
                    if (recipes.All(b => b.title != recipe.title))
                    recipes.Add(recipe);
                }
            }
            finally
            {
                this.IsBusy = false;
            }
        }

        async void OnAddNewRecipe(object sender, EventArgs e)
        {
            /*await Navigation.PushModalAsync(
                new AddEditBookPage(manager, books));*/
        }

        async void OnEditRecipe(object sender, ItemTappedEventArgs e)
        {
            //await Navigation.PushModalAsync(
               // new AddEditBookPage(manager, recipes, (Recipe)e.Item));
        }

        void OnClickedRecipe(object sender, ItemTappedEventArgs e)
        {
            Recipe recipe = (Recipe)e.Item;
            string Uri = recipe.href;
            Device.OpenUri(new Uri(Uri));            
        }

        async void OnDeleteRecipe(object sender, EventArgs e)
        {
           /* MenuItem item = (MenuItem)sender;
            Recipe recipe = item.CommandParameter as Recipe;
            if (recipe != null)
            {
                if (await this.DisplayAlert("Delete Recipe?",
                    "Are you sure you want to delete the recipe '"
                        + recipe.Title + "'?", "Yes", "Cancel") == true)
                {
                    this.IsBusy = true;
                    try
                    {
                        await manager.Delete(recipe.ISBN);
                        recipes.Remove(recipe);
                    }
                    finally
                    {
                        this.IsBusy = false;
                    }

                }
            }*/
        }
    }
}