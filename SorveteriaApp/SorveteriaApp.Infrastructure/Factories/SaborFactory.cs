using SorveteriaApp.Domain.Entities;

namespace SorveteriaApp.Infrastructure.Factories
{
    public static class SaborFactory
    {
        public static Sabor CriarSabor(string nome, string categoria, string codigo, decimal preco)
        {
            return new Sabor(nome, categoria, codigo, preco);
        }

        public static Sabor CriarSaborFrutas(string nome, string codigo, decimal preco)
        {
            return new Sabor(nome, "Frutas", codigo, preco);
        }

        public static Sabor CriarSaborChocolate(string nome, string codigo, decimal preco)
        {
            return new Sabor(nome, "Chocolate", codigo, preco);
        }

        public static Sabor CriarSaborEspecial(string nome, string codigo, decimal preco)
        {
            return new Sabor(nome, "Especial", codigo, preco);
        }

        public static Sabor CriarSaborCremoso(string nome, string codigo, decimal preco)
        {
            return new Sabor(nome, "Cremoso", codigo, preco);
        }
    }
}
