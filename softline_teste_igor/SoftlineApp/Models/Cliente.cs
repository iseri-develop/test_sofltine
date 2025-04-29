namespace SoftlineApp.Models
{
public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = default!;
        public string Fantasia { get; set; } = default!;
        public string Documento { get; set; } = default!;
        public string Endereco { get; set; } = default!;
    }
}