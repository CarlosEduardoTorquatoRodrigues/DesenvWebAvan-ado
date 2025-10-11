using System.ComponentModel.DataAnnotations;

namespace SorveteriaApp.Application.DTOs
{
    public class SaborUpdateDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do sabor é obrigatório")]
        [StringLength(100)]
        [Display(Name = "Nome do Sabor")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A categoria é obrigatória")]
        [StringLength(50)]
        [Display(Name = "Categoria")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "O código do produto é obrigatório")]
        [RegularExpression(@"^[A-Z]{3}\d{4}$", ErrorMessage = "O código deve seguir o padrão: 3 letras maiúsculas + 4 números")]
        [Display(Name = "Código do Produto")]
        public string CodigoProduto { get; set; }

        [Required(ErrorMessage = "O preço por kg é obrigatório")]
        [Range(0.01, 999.99)]
        [Display(Name = "Preço por Kg")]
        [DataType(DataType.Currency)]
        public decimal PrecoPorKg { get; set; }

        [Display(Name = "Disponível")]
        public bool Disponivel { get; set; }
    }
}
