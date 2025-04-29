namespace SoftlineApp.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = default!;
        public string Login { get; set; } = default!;
        public string Senha { get; set; } = default!;
    }
}