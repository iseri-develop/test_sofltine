using System.ComponentModel.DataAnnotations;

namespace SoftlineApp.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }

        [Required] //forçar o preenchimento dos campos no cadastro.
        public string Nome { get; set; } = default!;

        [Required]
        public string Login { get; set; } = default!;

        [Required]
        public string Senha { get; set; } = default!;
    }
}
