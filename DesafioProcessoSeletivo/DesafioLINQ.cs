using DesafioProcessoSeletivo.Classes;
using System.Collections.Generic;

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

            // 1 - Agrupe os registros por sua idade e selecione a primeira ocorrencia de seu agrupamento;


            // 2 - Com esses mesmos registros ordene-os de maneira decrescente com base em seu Documento;


            // 3 - Agora selecione os demais registros exceto o resultado do segundo desafio;


            // 4 - Agora utilizando também os registros abaixo realize uma junção e crie um objeto anônimo contendo o nome da pessoa e o seu email.
            IEnumerable<EmailPessoa> emails = new List<EmailPessoa>
            {
                new EmailPessoa("emaildohenrique@email.com", 1),
                new EmailPessoa("emaildomatheus@email.com", 2),
                new EmailPessoa("emaildojulio@email.com", 3),
                new EmailPessoa("emaildoisrael@email.com", 4),
                new EmailPessoa("emaildobruno@email.com", 5)
            };


        }
    }
}
