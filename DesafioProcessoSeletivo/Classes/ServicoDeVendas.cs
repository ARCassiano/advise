using System;

namespace DesafioProcessoSeletivo.Classes
{
    public class ServicoDeVendas
    {
        private readonly RegraCalculo RegraCalculo;

        public ServicoDeVendas()
        {
            this.RegraCalculo = new RegraCalculo();
        }

        public void Vender(Venda venda)
        {
            // Calcula o preco total 
            var precoTotal = this.RegraCalculo.Calcular(venda.Produtos);

            // Registra a ordem de pagamento para o cliente....
            Console.WriteLine(":D");
        }
    }
}
