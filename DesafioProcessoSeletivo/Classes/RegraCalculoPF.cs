using System.Collections.Generic;
using System.Linq;

namespace DesafioProcessoSeletivo.Classes
{
    /* Classe filha da interface RegraCalculo, responsável pelo gerenciamento da regra de cálculo para pessoas físicas */
    public class RegraCalculoPF:RegraCalculo
    {
        public double Calcular(IEnumerable<Produto> produtos)
        {
            // Regra extensa de cálculo.
            return produtos.Sum(x => x.Preco);
        }
    }
}
