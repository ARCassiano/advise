using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioProcessoSeletivo.Classes
{
    /* Interface criada com o objetivo de garantir a criação de novas regra de cálculo sem garndes modifiações no sistema*/
    public interface RegraCalculo
    {
        /* Toda classe que extender a interface RegraCalculo deve implementar o método abaixo */
        double Calcular(IEnumerable<Produto> produtos);
    }
}
