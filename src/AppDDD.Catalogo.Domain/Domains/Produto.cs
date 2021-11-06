using AppDDD.Catalogo.Domain.ValueObjects;
using AppDDD.Core.DomainObjects;
using System;

namespace AppDDD.Catalogo.Domain.Domains
{
    public class Produto : Entity, IAggregateRoot
    {
        #region construtores

        public Produto(
            string nome,
            string descricao,
            bool ativo,
            decimal valor,
            Guid categoriaId,
            DateTime dataCadastro,
            string imagem,
            Dimensoes dimensoes)
        {
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Valor = valor;
            DataCadastro = dataCadastro;
            Imagem = imagem;
            CategoriaId = categoriaId;
            Dimensoes = dimensoes;

            Validar();
        }

        #endregion construtores

        #region propriedades

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string Imagem { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public Dimensoes Dimensoes { get; set; }

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

        public void AlterarDescricao(string descricao)
        {
            Validacoes.ValidarSeVazio(descricao, "O campo Descricao do produto não pode estar vazio");
            Descricao = descricao;
        }

        public void DebitarEstoque(int quantidade)
        {
            // Se receber um valor negativo, garante que vai ficar positivo
            if (quantidade < 0) quantidade *= -1;

            if (!PossuiEstoque(quantidade)) throw new DomainException("Estoque insuficiente");
            QuantidadeEstoque -= quantidade;
        }

        public void ReporEstoque(int quantidade) => QuantidadeEstoque += quantidade;

        public bool PossuiEstoque(int quantidade) => QuantidadeEstoque >= quantidade;

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome do produto não pode estar vazio");
            Validacoes.ValidarSeVazio(Descricao, "O campo Descricao do produto não pode estar vazio");
            Validacoes.ValidarSeIgual(CategoriaId, Guid.Empty, "O campo CategoriaId do produto não pode estar vazio");
            Validacoes.ValidarSeMenorQue(Valor, 1, "O campo Valor do produto não pode se menor igual a 0");
            Validacoes.ValidarSeVazio(Imagem, "O campo Imagem do produto não pode estar vazio");
        }

        #endregion ad-hoc setters
    }
}