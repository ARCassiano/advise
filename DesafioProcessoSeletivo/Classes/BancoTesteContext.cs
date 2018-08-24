using System.Collections.Generic;
using System.Text;
using System.Configuration.Assemblies;
using Microsoft.EntityFrameworkCore;

namespace DesafioProcessoSeletivo.Classes
{
    /* Classe responsável por gerenciar a conexão com o banco de dados e todas as suas opeções */
    class BancoTesteContext : DbContext
    {
        /* O DbSet Usuario fica responsável por mapear a tabela Usuario o banco de dados */
        public DbSet<Usuario> Usuario { get; set; }

        /* Constrtutor Default */
        public BancoTesteContext()
        {
        }

        /* Método herdado de DbContext e com sobrecarga na classe filha, responsável por realizar as configurações iniciais  */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /* String de conexão com o Banco de dados */
            optionsBuilder.UseSqlServer(
                "Data Source=Ntbk_vaio;Initial Catalog=BancoTeste;User ID=UsuarioAplicao;Password=MinhaSenhaSeguraDaAplicacao");
        }
    }
}
