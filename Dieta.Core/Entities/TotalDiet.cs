using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dieta.Core.Entities
{
    public class TotalDiet
    {
        public int Id { get; set; }
        public int? DietId { get; set; }
        public double Carb { get; set; }
        public double Fat { get; set; }
        public double Protein { get; set; }
        public double Kcal { get; set; }
        public double Fiber { get; set; }
        

        public virtual Diet Diet { get; set; }
    }
}
