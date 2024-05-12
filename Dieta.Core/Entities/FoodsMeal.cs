﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dieta.Core.Entities
{
    public class FoodsMeal
    {
        public int FoodsId { get; set; }
        public int MealsId { get; set; }
        public int Ordenation { get; set; }
        public double Amount{ get; set; }

        public virtual Food Food {get; set;}
        public virtual Meal Meal {get; set;}
    }
}
