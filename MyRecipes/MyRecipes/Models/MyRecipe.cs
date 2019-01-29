using SQLite;
using System.ComponentModel;

namespace MyRecipes.Models
{
    [Table("MyRecipe")]
    public class MyRecipe : INotifyPropertyChanged
    {
        private int Id;
        [PrimaryKey, AutoIncrement]
        public int ID
        {
            get
            {
                return Id;
            }
            set
            {
                this.Id = value;
                OnPropertyChanged(nameof(ID));
            }
        }
        private string _title;
        [NotNull, MaxLength(100)]
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                this._title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        private string _ingredients;
        [MaxLength(500)]
        public string Ingredients
        {
            get
            {
                return _ingredients;
            }
            set
            {
                this._ingredients = value;
                OnPropertyChanged(nameof(Ingredients));
            }
        }

        private string _description;
        [NotNull, MaxLength(500)]
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                this._description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this,
              new PropertyChangedEventArgs(propertyName));
        }
    }
}
