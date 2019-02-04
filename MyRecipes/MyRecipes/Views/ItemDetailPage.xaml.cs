using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MyRecipes.Models;
using MyRecipes.ViewModels;
using MyRecipes.Services;

namespace MyRecipes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;
        public MyRecipe MyRecipe { get; set; }
        public bool edit { get; set; }

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
            MyRecipe = viewModel.MyRecipe;
            edit = false;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new MyRecipe
            {
                Title = "Pizza",
                Ingredients = "Olive, cheese, tomatoes",
                Description = "This is an description for pizza baking. You can add your own recipes. Just click + (ADD)."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }

        async void Update_Clicked(object sender, EventArgs e)
        {
            if (MyRecipe != null)
            {
                if (MyRecipe.Title == null || MyRecipe.Title.Length == 0){
                    await this.DisplayAlert("Confirm", $"Your recipe is missing title", "Ok");                    
                }

                else if (await this.DisplayAlert("Confirm", $"Are you sure you want to update {MyRecipe.Title}?", "Yes", "No") == true)
                {
                    MessagingCenter.Send(this, "UpdateItem", MyRecipe);
                    await Navigation.PopAsync();
                }
            }
        }

        async void Edit_Clicked(object sender, EventArgs e)
        {
            edit = true;
            if (MyRecipe != null)
            {
                if (await this.DisplayAlert("Confirm", $"Are you sure you want to edit {MyRecipe.Title}?", "Yes", "No") == true)
                {                    
                    edit = true;
                }
                else {                     
                    edit = false;
                    }

                editableTitle.IsVisible = edit;
            }
        }

        async void OnDelete(object sender, EventArgs e)
        {            
            if (MyRecipe != null)
            {
                if (await this.DisplayAlert("Confirm", $"Are you sure you want to delete {MyRecipe.Title}?", "Yes", "No") == true)
                {                   
                    MessagingCenter.Send(this, "DeleteItem", MyRecipe);
                    await Navigation.PopAsync();                                    
                }
            }           
        }
    }
}