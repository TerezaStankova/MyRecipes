using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyRecipes.Views;
using MyRecipes.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MyRecipes
{
    public partial class App : Application
    {
        public static RecipesRepository RecipesRepo { get; private set; }

        public App(string dbPath)
        {
            InitializeComponent();

            RecipesRepo = new RecipesRepository(dbPath);

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
