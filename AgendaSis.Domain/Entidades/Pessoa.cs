namespace AgendaSis.Domain.Entidades
{
    public abstract class Pessoa : BaseEntity
    {
        protected Pessoa() { }

        protected Pessoa(string nome, string telefone, string endereco, string email)
        {
            Nome = nome;
            Telefone = telefone;
            Endereco = endereco;
            Email = email;
        }

        protected void UpdateValues(string nome, string telefone, string endereco, string email)
        {
            Nome = nome;
            Telefone = telefone;
            Endereco = endereco;
            Email = email;
        }

        public string Nome { get; protected set; }
        public string Telefone { get; protected set; }
        public string Endereco { get; protected set; }
        public string Email { get; protected set; }
    }
}
