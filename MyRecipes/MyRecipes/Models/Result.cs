using System;
using System.Collections.Generic;
using System.Text;

namespace MyRecipes.Models
{
    public class Result
    {
        public string title { get; set; }
        public double version { get; set; }
        public string href { get; set; }
        public List<Recipe> results { get; set; }
    }
}
