
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dieta.Core.Entities
{
    public class Meal
    {
        public int MealId { get; set; }
        public string NameMeal { get; set; }
        public DateTime Date { get; set; }
        public int Ordenation { get; set; }
    
        public virtual List<Diet> Diets { get; set; }


        //public virtual List<Alimentos> Alimentos { get; set; }

        //alt
        public virtual List<FoodsMeal> FoodsMeals { get; set; }
    }
}
