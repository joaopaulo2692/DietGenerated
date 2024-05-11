using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dieta.Communication.ViewObject.Client
{
    public class UserVO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Username{ get; set; }
        public string Email{ get; set; }
        public int Age { get; set; }
        public float Heigth { get; set; }
        public float Weight { get; set; }
        public double BasalMeatabolicRate { get; set; }
        public int TrainingFreq { get; set; }

        public string? DietType { get; set; }
        public string? informationAdd { get; set; }

        [Required(ErrorMessage = "Senha não informada")]
        public string PasswordHash { get; set; }
    }
}
