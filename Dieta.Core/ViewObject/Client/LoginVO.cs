using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dieta.Core.ViewObject.Client
{
    public class LoginVO
    {
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        public string? Password { get; set; }
    }
}
