using System;

using MyRecipes.Models;

namespace MyRecipes.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public MyRecipe MyRecipe { get; set; }        

        public ItemDetailViewModel(MyRecipe item = null)
        {
            Title = item?.Title;
            MyRecipe = item;            
        }

        
    }
}
