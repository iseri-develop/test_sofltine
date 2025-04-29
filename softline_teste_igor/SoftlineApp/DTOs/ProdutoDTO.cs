using System.ComponentModel.DataAnnotations;

namespace SoftlineApp.DTOs
{
    public class ProdutoDTO
    {
        public int Id { get; set; }

        [Required]
        public string Descricao { get; set; } = default!;

        [Required]
        public string CodigoDeBarras { get; set; } = default!;

        [Range(0.01, 999999.99)]
        public decimal ValorVenda { get; set; }

        public decimal PesoBruto { get; set; }

        public decimal PesoLiquido { get; set; }
    }
}
