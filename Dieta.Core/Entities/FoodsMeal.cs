using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dieta.Core.Entities
{
    public class FoodsMeal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FoodsMealId { get; set; }
        public int FoodsId { get; set; }
        public int MealsId { get; set; }
        public int Ordenation { get; set; }
        public double Amount{ get; set; }

        public virtual Food Food {get; set;}
        public virtual Meal Meal {get; set;}
    }
}
