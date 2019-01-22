using System;
using System.Collections.Generic;
using System.Text;

namespace MyRecipes.Models
{
    public class Recipe
    {
        public string title { get; set; }
        public string href { get; set; }
        public string ingredients { get; set; }
        public string thumbnail { get; set; }
    }
}
