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
        [Required(ErrorMessage = "Nome deve ser preechido")]
        public string? Name { get; set; }
        public string Username{ get; set; }
        [Required(ErrorMessage = "E-mail deve ser preechido")]
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
        [Required(ErrorMessage = "Nome da dieta deve ser preechido")]
        public string DietName { get; set; }
    }
}
