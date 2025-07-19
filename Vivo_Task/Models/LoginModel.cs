using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vivo_Task.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "O campo de e-mail é obrigatório")]
        public string? matricula { get; set; }
        [Required(ErrorMessage = "O campo de senha é obrigatório")]
        public string Password { get; set; }
    }
}
