using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MyRecipes.Models;
using MyRecipes.ViewModels;

namespace MyRecipes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new MyRecipe
            {
                Title = "Pizza",
                Ingredients = "Olive, cheese, tomatoes",
                Description = "This is an description for pizza baking."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}