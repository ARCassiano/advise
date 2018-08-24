using DesafioProcessoSeletivo.Classes;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DesafioProcessoSeletivo
{
    class DesafioLINQ
    {
        public void Desafio()
        {
            // Registros desafio.
            IEnumerable<Pessoa> pessoas = new List<Pessoa>
            {
                new Pessoa(1, "Henrique", 21, "157.741.852-97"),
                new Pessoa(2, "Matheus", 25, "351.178.954-51"),
                new Pessoa(3, "Julio", 38, "987.757.861-26"),
                new Pessoa(4, "Israel", 38, "986.762.875-63"),
                new Pessoa(5, "Bruno", 78, "324.718.182-77")
            };


            Console.WriteLine();
            Console.WriteLine("Desafio LINQ");

            Console.WriteLine();
            Console.WriteLine("Exercicio 1");

            // 1 - Agrupe os registros por sua idade e selecione a primeira ocorrencia de seu agrupamento;
            /* O list de pessoas foi agrupado por idade, utilizado o Select() e First() será retornado apenas o primeiro registro de cada agrupamento */
            IEnumerable<Pessoa> pessoasAgrupadasPorIdade = pessoas.GroupBy(p => p.Idade).Select(g => g.First());

            /* Imprimir os registros retornados pela consulta em LINQ */
            foreach (Pessoa p in pessoasAgrupadasPorIdade)
                Console.WriteLine(p);


            Console.WriteLine();
            Console.WriteLine("Exercicio 2");

            // 2 - Com esses mesmos registros ordene-os de maneira decrescente com base em seu Documento;
            /* 
             * O primeiro registro de cada agrupamento gerou a lista [pessoasAgrupadasPorIdade]
             * Os registros desta lista foram ordenados com base  no Documento 
             */
            IEnumerable<Pessoa> pessoasOrderByDocumentoDesc = pessoasAgrupadasPorIdade.OrderBy(p => p.Documento);

            /* Impressão dos registros ordenados */ 
            foreach (Pessoa p in pessoasOrderByDocumentoDesc)
                Console.WriteLine(p.ToString());


            Console.WriteLine();
            Console.WriteLine("Exercicio 3");

            // 3 - Agora selecione os demais registros exceto o resultado do segundo desafio;
            /* 
             * Para pegar os registros que não foram listados no agrupamento, deve-se realizar uma união das duas listas para verificar os registros ausentes (GoupJoin) (LEFT JOIN)
             * A compração dos registrso foi realizada através dos ids 
             * Por fim foi solicitado através do WHERE que fosse retornado apenas os registros que existia na lista [pessoas] e não existia na lista [pessoasOrderByDocumentoDesc] 
             */
            var pessoasNaoSelecionadas = pessoas.GroupJoin(
                                                                pessoasOrderByDocumentoDesc,
                                                                p => p.Id,
                                                                po => po.Id,
                                                                (a, x) => new { a, x }).Where(r => r.x.FirstOrDefault() == null).Select(a => a.a);

            
            foreach (var p in pessoasNaoSelecionadas)
                Console.WriteLine(p);


            Console.WriteLine();
            Console.WriteLine("Exercicio 4");

            // 4 - Agora utilizando também os registros abaixo realize uma junção e crie um objeto anônimo contendo o nome da pessoa e o seu email.
            /* 
             * Para unir as duas listas é necesario utilizar o Join (INNER JOIN)
             * A junção foi realizada através do segundo e do terceiro parâmetro
             * O 4° parâmetro retorna a lista de novos objetos
             */

            IEnumerable<EmailPessoa> emails = new List<EmailPessoa>
            {
                new EmailPessoa("emaildohenrique@email.com", 1),
                new EmailPessoa("emaildomatheus@email.com", 2),
                new EmailPessoa("emaildojulio@email.com", 3),
                new EmailPessoa("emaildoisrael@email.com", 4),
                new EmailPessoa("emaildobruno@email.com", 5)
            };
            var pessoasEmails = pessoas.Join(emails, p => p.Id, e => e.IdPessoa, (p, e) => new { p.Nome, e.Email });

            foreach (var p in pessoasEmails)
                Console.WriteLine(p.Nome + " - " + p.Email);


            Console.WriteLine("Desafio LINQ - Finalizado");

        }
    }
}
