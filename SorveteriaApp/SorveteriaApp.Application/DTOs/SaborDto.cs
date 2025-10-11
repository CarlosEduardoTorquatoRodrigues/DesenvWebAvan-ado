using System;

namespace SorveteriaApp.Application.DTOs
{
    public class SaborDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string CodigoProduto { get; set; }
        public decimal PrecoPorKg { get; set; }
        public bool Disponivel { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
