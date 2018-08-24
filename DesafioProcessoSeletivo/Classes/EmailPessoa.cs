namespace DesafioProcessoSeletivo.Classes
{
    public class EmailPessoa
    {
        public EmailPessoa(string email, long idPessoa)
        {
            this.Email = email;
            this.IdPessoa = idPessoa;
        }

        public string Email { get; private set; }
        public long IdPessoa { get; private set; }
    }
}
