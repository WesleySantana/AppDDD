using AppDDD.Core.DomainObjects;

namespace AppDDD.Catalogo.Domain.Domains
{
    public class Categoria : Entity
    {
        #region construtores

        public Categoria(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;

            Validar();
        }

        #endregion construtores

        #region propriedades

        public string Nome { get; private set; }
        public int Codigo { get; private set; }

        #endregion propriedades

        #region ad-hoc setters

        public override string ToString() => $"{Nome} - {Codigo}";

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome da categoria não pode estar vazio");
            Validacoes.ValidarSeIgual(Codigo, 0, "O campo Codigo não pode ser 0");
        }

        #endregion ad-hoc setters
    }
}