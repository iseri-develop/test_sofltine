using System.ComponentModel.DataAnnotations;

namespace SoftlineApp.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = default!;

        public string Fantasia { get; set; } = default!;

        [Required]
        public string Documento { get; set; } = default!;

        public string Endereco { get; set; } = default!;
    }
}
