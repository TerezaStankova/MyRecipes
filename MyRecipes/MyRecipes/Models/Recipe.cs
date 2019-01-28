using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Newtonsoft.Json;

namespace MyRecipes.Models
{
    public class Recipe
    {
        public string title { get; set; }
        public string href { get; set; }
        public string ingredients { get; set; }
        [DefaultValue("RecipeBook.png")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string thumbnail { get; set; }
    }
}
