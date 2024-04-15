using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dieta.Core.Data
{
    public class FoodsMeal
    {
        [Key]
        public int AlimentosId { get; set; }
        [Key]
        public int RefeicaoId { get; set; }
        public int Ordenation { get; set; }

        public virtual Food Alimento {get; set;}
        public virtual Meal Refeicao {get; set;}
    }
}
