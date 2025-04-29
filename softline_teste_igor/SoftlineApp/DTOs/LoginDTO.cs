using System.ComponentModel.DataAnnotations;

namespace SoftlineApp.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string Login {get; set;} = default!;

        public string Senha {get; set;} = default!;
    }
}