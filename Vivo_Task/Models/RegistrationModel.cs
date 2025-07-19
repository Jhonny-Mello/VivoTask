using System.ComponentModel.DataAnnotations;

namespace Vivo_Task.Models
{
    public class RegistrationModel
    {
        [Required]
        public string Matricula { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Cargo { get; set; }
        [Required]
        public bool Fixa { get; set; }
        [Required]
        public string Pdv { get; set; }
        [Required]
        public string Regional { get; set; }
        public string UserAvatar { get; set; }


    }
}
