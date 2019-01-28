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
    public partial class IngredientsPage : ContentPage
    {

        readonly IList<Recipe> recipes = new ObservableCollection<Recipe>();   
        readonly RecipeManager manager = new RecipeManager();

        public IngredientsPage()
        {         
            InitializeComponent();
            BindingContext = recipes;
            noRecipeLabel.IsVisible = false;
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

        async void OnFindButtonClicked(object sender, EventArgs e)
        {
            // Turn on network indicator
            this.IsBusy = true;            

            try
            {
                recipes.Clear();
                string query = newRecipe.Text;
                var recipeCollection = await manager.GetAllByIngredients(query);
                    
                    foreach (Recipe recipe in recipeCollection)
                {
                    if (recipe.thumbnail == "") recipe.thumbnail = "RecipeBook.png";
                    if (recipes.All(b => b.title != recipe.title))
                    recipes.Add(recipe);
                }
                if (recipeCollection != null && (recipeCollection.Count() > 0)) { noRecipeLabel.IsVisible = false; }
                else { noRecipeLabel.IsVisible = true; }
            }
            finally
            {
                this.IsBusy = false;
            }
        }


        void OnClickedRecipe(object sender, ItemTappedEventArgs e)
        {
            Recipe recipe = (Recipe)e.Item;
            string Uri = recipe.href;
            Device.OpenUri(new Uri(Uri));            
        }
    }
}