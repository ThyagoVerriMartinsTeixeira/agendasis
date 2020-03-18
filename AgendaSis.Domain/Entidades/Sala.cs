using AgendaSis.Domain.Validacao;
using System.Threading.Tasks;

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

        public void ChangeValues(string nome, int capacidade, int andar)
        {
            Nome = nome;
            Capacidade = capacidade;
            Andar = andar;
        }

        public async Task<FluentValidation.Results.ValidationResult> Validate()
        {
            var validator = new SalaValidator();
            return await validator.ValidateAsync(this);
        }

        public string Nome { get; protected set; }
        public int Capacidade { get; protected set; }
        public int Andar { get; protected set; }
    }
}
