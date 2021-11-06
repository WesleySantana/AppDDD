using AppDDD.Core.DomainObjects;
using System;

namespace AppDDD.Catalogo.Domain
{
    public class Produto : Entity, IAggregateRoot
    {
        #region construtor

        public Produto(
            string nome,
            string descricao,
            bool ativo,
            decimal valor,
            DateTime dataCadastro,
            string imagem,
            Guid categoriaId)
        {
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Valor = valor;
            DataCadastro = dataCadastro;
            Imagem = imagem;
            CategoriaId = categoriaId;
        }

        #endregion construtor

        #region propriedades

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string Imagem { get; private set; }
        public int QuantidadeEstoque { get; private set; }

        public Guid CategoriaId { get; private set; }
        public virtual Categoria Categoria { get; private set; }

        #endregion propriedades

        #region ad-hoc setters

        public void Ativar() => Ativo = true;

        public void Desativar() => Ativo = false;

        public void AlterarCategoria(Categoria categoria)
        {
            Categoria = categoria;
            CategoriaId = categoria.Id;
        }

        public void AlterarDescricao(string descricao) => Descricao = descricao;

        public void DebitarEstoque(int quantidade)
        {
            // Se receber um valor negativo, garante que vai ficar positivo
            if (quantidade < 0) quantidade *= -1;
            QuantidadeEstoque -= quantidade;
        }

        public void ReporEstoque(int quantidade) => QuantidadeEstoque += quantidade;

        public bool PossuiEstoque(int quantidade) => QuantidadeEstoque >= quantidade;

        public void Validar()
        {
        }

        #endregion ad-hoc setters
    }

    public class Categoria : Entity
    {
        public Categoria(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;
        }

        public string Nome { get; private set; }
        public int Codigo { get; private set; }

        public override string ToString() => $"{Nome} - {Codigo}";
    }
}