using System.ComponentModel.DataAnnotations;

namespace SorveteriaApp.Application.DTOs
{
    public class SaborCreateDto
    {
        [Required(ErrorMessage = "O nome do sabor é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        [Display(Name = "Nome do Sabor")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A categoria é obrigatória")]
        [StringLength(50, ErrorMessage = "A categoria deve ter no máximo 50 caracteres")]
        [Display(Name = "Categoria")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "O código do produto é obrigatório")]
        [RegularExpression(@"^[A-Z]{3}\d{4}$", ErrorMessage = "O código deve seguir o padrão: 3 letras maiúsculas + 4 números (ex: SOR0001)")]
        [Display(Name = "Código do Produto")]
        public string CodigoProduto { get; set; }

        [Required(ErrorMessage = "O preço por kg é obrigatório")]
        [Range(0.01, 999.99, ErrorMessage = "O preço deve estar entre R$ 0,01 e R$ 999,99")]
        [Display(Name = "Preço por Kg")]
        [DataType(DataType.Currency)]
        public decimal PrecoPorKg { get; set; }
    }
}
