using System.Collections.Generic;
using System.Linq;

namespace DesafioProcessoSeletivo.Classes
{
    public class RegraCalculo
    {
        public double Calcular(IEnumerable<Produto> produtos)
        {
            // Regra extensa de cálculo.
            return produtos.Sum(x => x.Preco);
        }
    }
}
