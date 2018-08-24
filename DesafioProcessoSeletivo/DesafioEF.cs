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
        }
    }
}
