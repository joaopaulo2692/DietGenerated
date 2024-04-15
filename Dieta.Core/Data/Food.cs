using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dieta.Core.Data
{
    public class Food
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FoodId { get; set; }
        public string? FoodName { get; set; }
        public double Carb { get; set; }
        public double Fat { get; set; }
        public double Protein { get; set; }
        public double Kcal { get; set; }
        public string? Prepare { get; set; }
        public double Fiber { get; set; }
        public double Amount {  get; set; }


        public virtual List<FoodsMeal> FoodsMeals { get; set; }

    }
}
