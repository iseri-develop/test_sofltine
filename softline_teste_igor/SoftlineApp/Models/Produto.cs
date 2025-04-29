namespace SoftlineApp.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = default!;
        public string CodigoDeBarras { get; set; } = default!;
        public decimal ValorVenda { get; set; }
        public decimal PesoBruto { get; set; }
        public decimal PesoLiquido { get; set; }
    }
}