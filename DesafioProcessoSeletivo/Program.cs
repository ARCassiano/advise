using System;

namespace DesafioProcessoSeletivo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Neste desafio devem ser concuídos todos os objetivos das classes com o prefixo 'Desafio', \n" +
                "sendo as classes: DesafioEF, DesafioPOO, DesafioLINQ e DesafioXUnit.");


            Console.WriteLine();
            
            /* Execução do Desafio EF */
            DesafioEF desafioEF = new DesafioEF();
            desafioEF.Desafio();

            /* Execução do Desafio LINQ */
            DesafioLINQ desafioLINQ = new DesafioLINQ();
            desafioLINQ.Desafio();

            /* Execução do Desafio POO */
            DesafioPOO desafioPOO = new DesafioPOO();
            desafioPOO.Desafio();

            Console.ReadKey();
        }
    }
}
