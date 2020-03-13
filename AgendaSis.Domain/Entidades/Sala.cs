namespace AgendaSis.Domain.Entidades
{
    public class Sala : BaseEntity
    {
        protected Sala() { }

        public Sala(string nome, int capacidade, int andar)
        {
            Nome = nome;
            Capacidade = capacidade;
            Andar = andar;
        }

        public void  ChangeValues(string nome, int capacidade, int andar)
        {
            Nome = nome;
            Capacidade = capacidade;
            Andar = andar;
        }

        public string Nome { get; protected set; }
        public int Capacidade { get; protected set; }
        public int Andar { get; protected set; }
    }
}
