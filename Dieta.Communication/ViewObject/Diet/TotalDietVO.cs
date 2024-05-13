using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dieta.Communication.ViewObject.Diet
{
    public class TotalDietVO
    {
        public int Id { get; set; }
        public double Carb { get; set; }
        public double Fat { get; set; }
        public double Protein { get; set; }
        public double Kcal { get; set; }
        public double Fiber { get; set; }
    }
}
