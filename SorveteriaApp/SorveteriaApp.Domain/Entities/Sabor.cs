using System;
using System.ComponentModel.DataAnnotations;

namespace SorveteriaApp.Domain.Entities
{
    public class Sabor
    {
        public int Id { get; private set; }

        [Required(ErrorMessage = "O nome do sabor é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string Nome { get; private set; }

        [Required(ErrorMessage = "A categoria é obrigatória")]
        [StringLength(50, ErrorMessage = "A categoria deve ter no máximo 50 caracteres")]
        public string Categoria { get; private set; }

        [Required(ErrorMessage = "O código do produto é obrigatório")]
        [RegularExpression(@"^[A-Z]{3}\d{4}$", ErrorMessage = "O código deve seguir o padrão: 3 letras maiúsculas + 4 números (ex: SOR0001)")]
        public string CodigoProduto { get; private set; }

        [Range(0.01, 999.99, ErrorMessage = "O preço deve estar entre R$ 0,01 e R$ 999,99")]
        public decimal PrecoPorKg { get; private set; }

        public bool Disponivel { get; private set; }

        public DateTime DataCriacao { get; private set; }

        // Construtor privado para EF
        private Sabor() { }

        // Construtor para criação de novos sabores
        public Sabor(string nome, string categoria, string codigoProduto, decimal precoPorKg)
        {
            ValidarDados(nome, categoria, codigoProduto, precoPorKg);
            
            Nome = nome;
            Categoria = categoria;
            CodigoProduto = codigoProduto.ToUpper();
            PrecoPorKg = precoPorKg;
            Disponivel = true;
            DataCriacao = DateTime.Now;
        }

        // Métodos de negócio
        public void Atualizar(string nome, string categoria, string codigoProduto, decimal precoPorKg)
        {
            ValidarDados(nome, categoria, codigoProduto, precoPorKg);
            
            Nome = nome;
            Categoria = categoria;
            CodigoProduto = codigoProduto.ToUpper();
            PrecoPorKg = precoPorKg;
        }

        public void MarcarComoDisponivel() => Disponivel = true;
        
        public void MarcarComoIndisponivel() => Disponivel = false;

        public void AtualizarPreco(decimal novoPreco)
        {
            if (novoPreco <= 0)
                throw new ArgumentException("O preço deve ser maior que zero");
            
            PrecoPorKg = novoPreco;
        }

        private void ValidarDados(string nome, string categoria, string codigoProduto, decimal precoPorKg)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome do sabor não pode ser vazio");

            if (string.IsNullOrWhiteSpace(categoria))
                throw new ArgumentException("Categoria não pode ser vazia");

            if (string.IsNullOrWhiteSpace(codigoProduto) || 
                !System.Text.RegularExpressions.Regex.IsMatch(codigoProduto, @"^[A-Z]{3}\d{4}$"))
                throw new ArgumentException("Código do produto deve seguir o padrão: 3 letras maiúsculas + 4 números");

            if (precoPorKg <= 0)
                throw new ArgumentException("Preço deve ser maior que zero");
        }
    }
}
