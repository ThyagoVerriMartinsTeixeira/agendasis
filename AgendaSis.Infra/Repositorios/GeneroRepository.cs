using AgendaSis.Domain.Entidades;
using AgendaSis.Domain.Interfaces;
using AgendaSis.Infra.Contexto;

namespace AgendaSis.Infra.Repositorios
{
    public class GeneroRepository : GenericRepository<Genero>, IGeneroRepository
    {
        public GeneroRepository(MeuContexto dbContext) : base(dbContext)
        {
        }
    }
}
