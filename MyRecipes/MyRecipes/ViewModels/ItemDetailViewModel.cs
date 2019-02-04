using System;

using MyRecipes.Models;

namespace MyRecipes.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public MyRecipe MyRecipe { get; set; }
        //public Obse bool edit { get; set; }
        public bool ShowEdit { get; set; }
        //IObservable<bool> Edit { get; set; }

        public ItemDetailViewModel(MyRecipe item = null)
        {
            Title = item?.Title;
            MyRecipe = item;
            //Edit = (IObservable<bool>) false;
            ShowEdit = false;
        }

        void setShowEdit(bool editable) {
            ShowEdit = editable;
        }
    }
}
