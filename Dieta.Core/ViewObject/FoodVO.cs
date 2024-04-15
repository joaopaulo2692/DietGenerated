namespace Dieta.Core.ViewObject

{
    public class FoodVO
    {
        public int FoodId { get; set; }
        public string? Food { get; set; }
        public double Carb { get; set; }
        public double Fat { get; set; }
        public double Protein { get; set; }
        public double Kcal { get; set; }
        public double Fiber { get; set; }
        public double Amount { get; set; }
        public int Meal {  get; set; }
        public int MealOrdenation {  get; set; }
    }
}
