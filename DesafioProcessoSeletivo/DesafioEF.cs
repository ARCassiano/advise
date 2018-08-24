using DesafioProcessoSeletivo.Classes;
using System;
using System.Linq;

namespace DesafioProcessoSeletivo
{
    class DesafioEF
    {
        public void Desafio()
        {
            /* Imaginando um banco de dados fictício local(localhost) com porta padrão 1433 chamado BancoTeste com a 
             *  autenticação por usuário e senha, sendo:
             *      usuário = 'UsuarioAplicao',
             *      senha = 'MinhaSenhaSeguraDaAplicacao'.
             *      
             * E neste banco exite a apenas a tabela Usuario, sendo:
             *     CREATE TABLE Usuario(
             *         Id BIGINT IDENTITY PRIMARY KEY,
             *         Nome VARCHAR(70) NOT NULL,
             *         Email VARCHAR(200) NULL,
             *         Ativo BIT NOT NULL DEFAULT(1)
             *     );
             *      
             * 1 - Insira o EFCore na aplicação e crie um DbContext apontando para tal banco e contendo o mapeamento 
             *  da tabela Usuario.
             *  
             * 2 - Utilizando este DbContext realize operações de Inserção, Alteração, Consulta e Deleção de registros.
             */


            // Cole o exemplo do CRUD aqui.
            Console.WriteLine("Desafio EF");

            //CREATE
            Console.WriteLine("CREATE");
            /* Instancia do banco de dados [BancoTeste] */
            using (var db = new BancoTesteContext())
            {   
                /* Inclusão de três usuários no DbSet */
                db.Usuario.Add(new Usuario("Anderson Cassiano1", "anderson.cassiano", true));
                db.Usuario.Add(new Usuario("Anderson Cassiano2", "anderson.cassiano", true));
                db.Usuario.Add(new Usuario("Anderson Cassiano3", "anderson.cassiano", true));

                /* Commit da operação */
                db.SaveChanges();
                Console.WriteLine("Inseriu 3 registros");
            }

            //READ AND UPDATE
            Console.WriteLine("READ AND UPDATE");

            /* Instancia do banco de dados [BancoTeste] */
            using (var db = new BancoTesteContext())
            {
                //READ
                /* Retorne o único registro que possue Id == 3 (LINQ) */
                var usuario = db.Usuario.Single(u => u.Id == 3);
                Console.WriteLine("Encontrou o usuario de ID = 3");

                //UPDATE
                /* Alterar o atributo nome do usuario */
                usuario.Nome = "Anderson Atualizado";

                /* Commit da operação */
                db.SaveChanges();
                Console.WriteLine("Atualizou usuario de ID = 3");
            }

            //READ AND DELETE
            Console.WriteLine("READ AND DELETE");

            /* Instancia do banco de dados [BancoTeste] */
            using (var db = new BancoTesteContext())
            {
                //READ
                /* Retorne o único registro que possue Id == 2 (LINQ) */
                var usuario = db.Usuario.Single(b => b.Id == 2);
                Console.WriteLine("Encontrou o usuario de ID = 2");

                /* Remover usuário */
                db.Usuario.Remove(usuario);

                /* Commit da operação */
                db.SaveChanges();
                Console.WriteLine("Removeu o usuario de ID = 2");

            }

            Console.WriteLine("Desafio EF - Finalizado");

        }
    }
}
