namespace DesafioProcessoSeletivo.Classes
{
    public class Pessoa
    {
        public Pessoa(long id, string nome, int idade, string documento)
        {
            this.Id = id;
            this.Nome = nome;
            this.Idade = idade;
            this.Documento = documento;
        }

        public long Id { get; private set; }
        public string Nome { get; private set; }
        public int Idade { get; private set; }
        public string Documento { get; private set; }

        /* Sobrecarga do método ToString para facilitar a visualição dos objetos no console */
        public override string ToString()
        {
            return "Pesoa={Id=" + this.Id + ", Nome=" + this.Idade + ", Idade=" + this.Idade + ", Documento=" + this.Documento +"}";
        }
    }
}
