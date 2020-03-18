using AgendaSis.Application.Models.Generos;

namespace AgendaSis.Application.Models.Pessoas
{
    public class PessoaFisicaResponseDto : PessoaFisicaDto
    {
        public int Id { get; set; }

        public virtual GeneroResponseDto Genero { get; set; }
    }
}
