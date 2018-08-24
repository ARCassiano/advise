using System.Collections.Generic;

namespace DesafioProcessoSeletivo.Classes
{
    public class Venda
    {
        public Venda(Pessoa pessoa, IEnumerable<Produto> produtos)
        {
            this.Pessoa = pessoa;
            this.Produtos = produtos;
        }

        public Pessoa Pessoa { get; private set; }
        public IEnumerable<Produto> Produtos { get; private set; }
    }
}
