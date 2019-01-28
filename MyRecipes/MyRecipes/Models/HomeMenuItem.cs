using System;
using System.Collections.Generic;
using System.Text;

namespace MyRecipes.Models
{
    public enum MenuItemType
    {
        Browse,
        Recipe, 
        Ingredients
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
