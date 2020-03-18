namespace AgendaSis.Application.Models.Salas
{
    public abstract class SalaDto
    {
        public string Nome { get; set; }
        public int Capacidade { get; set; }
        public int Andar { get; set; }
    }
}
