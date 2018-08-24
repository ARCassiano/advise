using System;

namespace DesafioProcessoSeletivo.Classes
{
    public class ServicoDeVendas
    {
        private readonly RegraCalculo RegraCalculo;

        /* O método construtor passou a receber a instância de RegraCalculo
         * Desta forma aplicando a inversão de controle e utilizando o conceito de Single Responsibility */
        public ServicoDeVendas(RegraCalculo regraCalculo)
        {
            this.RegraCalculo = regraCalculo;
        }

        public void Vender(Venda venda)
        {
            // Calcula o preco total 
            var precoTotal = this.RegraCalculo.Calcular(venda.Produtos);

            // Registra a ordem de pagamento para o cliente....
            Console.WriteLine("");
            Console.WriteLine(":D");
            Console.WriteLine("Valor total: " + precoTotal);
        }
    }
}
