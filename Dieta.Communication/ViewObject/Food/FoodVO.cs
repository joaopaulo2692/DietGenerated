using System.ComponentModel.DataAnnotations;

namespace Dieta.Communication.ViewObject.Food

{
    public class FoodVO
    {
        [Required(ErrorMessage = "É necessário informar o id do alimento")]
        public int FoodId { get; set; }
        public string? Food { get; set; }
        public double Carb { get; set; }
        public double Fat { get; set; }
        public double Protein { get; set; }
        public double Kcal { get; set; }
        public double Fiber { get; set; }
        public double Amount { get; set; }
        [Required(ErrorMessage = "É necessário informar em qual refeição vai ser adicionado")]
        public int Meal { get; set; }
        [Required(ErrorMessage = "É necessário informar a ordem do alimento a ser adicionado")]
        public int MealOrdenation { get; set; }
    }
}
