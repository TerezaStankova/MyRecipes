using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace MyRecipes.ViewModels
{
    public class NewViewModel : BaseViewModel
    {
        public NewViewModel()
        {
            Title = "Find recipe";

            //OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        public ICommand OpenWebCommand { get; }
    }
}