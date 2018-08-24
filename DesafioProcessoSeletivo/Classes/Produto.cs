namespace DesafioProcessoSeletivo.Classes
{
    public class Produto
    {
        public Produto(string nome, double preco)
        {
            this.Nome = nome;
            this.Preco = preco;
        }

        public string Nome { get; private set; }
        public double Preco { get; private set; }
    }
}
