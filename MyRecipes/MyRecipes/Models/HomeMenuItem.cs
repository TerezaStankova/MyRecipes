using System;
using System.Collections.Generic;
using System.Text;

namespace MyRecipes.Models
{
    public enum MenuItemType
    {        
        MyRecipes,
        Browse,
        Ingredients
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
