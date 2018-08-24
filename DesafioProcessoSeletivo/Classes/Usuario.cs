namespace DesafioProcessoSeletivo.Classes
{
    /* Classe Model para Usuário */
    public class Usuario
    {
        /* Método construtor da classe Usuario */
        public Usuario(string nome, string email, bool ativo)
        {
            this.Nome = nome;
            this.Email = email;
            this.Ativo = ativo;
        }

        /* Atributos, getters e setters da classe Usuario */
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }

    }
}

