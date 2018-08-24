using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DesafioProcessoSeletivo.Classes
{
    /* Classe filha da interface RegraCalculo, responsável pelo gerenciamento da regra de cálculo para micro e  pequenas empresas */
    class RegraCalculoPJ:RegraCalculo
    {
        public double Calcular(IEnumerable<Produto> produtos)
        {
            // Regra extensa de cálculo.
            /* Aplicando o desconto de 25% e arrendondando os centavos em duas casas decimais */
            return Math.Round(produtos.Sum(x => x.Preco) * 0.75, 2);
        }
    }
}
