using DesafioProcessoSeletivo.Classes;
using System.Collections.Generic;
using System;

namespace DesafioProcessoSeletivo
{
    class DesafioPOO
    {
        public void Desafio()
        {
            /* 1 - Atualmente a empresa CargasD'Agua realiza pequenas vendas para diferentes pessoas físicas,
             *  porém a empresa começou a crescer e agora começou a atender micro e pequenas empresas também...
             * Como forma de atrair novos clientes a empresa decidiu criar uma nova estratérgia de vendas a fim de 
             *  ofertar um desconto de 25% para essas micro e pequenas empresas.
             * Como a empresa poderia alterar o seu serviço de vendas de modo que possam ser criadas diferentes Regras de
             *  Cálculo para atender diversos cenários e situações. 
             *
             * Obs: Utilize inversão de controle.
             */

            /* Descrição do processo realizado:
             * Foi criada a interface RegraCalculo e as Classes RegraCalculoPJ e RegraCalculoPF extendendo este interface
             * A Classe ServicoDeVendas passou a receber a instância de RegraCalculo (Inversão de Controle)
             * Desta forma sendo possível aplicar o polimorfismo no cálculo de acordo com o tipo de cliente
             * a interface RegraCalculo foi definida com public devido o uso dela na Classe ServicoDeVendas, as mesmas não se encontram no mesmo pacote
             */

            Console.WriteLine("");
            Console.WriteLine("Desafio POO");

            Console.WriteLine("");
            Console.WriteLine("Exercicio 1");
            Pessoa pessoa = new Pessoa(1, "Julião", 25, "325.984.751-85");
            Venda venda = new Venda(pessoa, new List<Produto>
            {
                new Produto("Miojo", 2.5),
                new Produto("Sabonete", 5.75),
                new Produto("Pó de chips", 500)
            });

            /* Utilizando o cálculo para Pessoa Física */
            ServicoDeVendas servicoDeVendas = new ServicoDeVendas(new RegraCalculoPF());
            servicoDeVendas.Vender(venda);

            /* Utilizando o cálculo para Pessoa Júridica */
            ServicoDeVendas servicoDeVendasPJ = new ServicoDeVendas(new RegraCalculoPJ());
            servicoDeVendasPJ.Vender(venda);


            /* 2 - Ainda pensando em orientação a objetos, crie um exemplo utilizando as classes: Pessoa, Venda, Produto 
             *  e ServicoDeVendas a fim de demonstrar o princípios de Single responsibility, Open/closed, Liskov 
             *  substitution e Interface segregation. 
             *  
             * Obs: As classes informadas podem ser alteradas a fim de demonstrar tais princípios. 
             */

            /* Com a inversão de controle aplicado na classe ServicoDeVendas e a criação da interface RegraCalculo, o exercício 2 foi realizado */
            Console.WriteLine("");
            Console.WriteLine("Exercicio 2");

            Console.WriteLine("");
            Console.WriteLine("Desafio POO - Finalizado");
        }
    }
}
