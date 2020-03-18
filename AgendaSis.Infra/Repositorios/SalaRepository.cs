using AgendaSis.Domain.Entidades;
using AgendaSis.Domain.Interfaces;
using AgendaSis.Infra.Contexto;

namespace AgendaSis.Infra.Repositorios
{
    public class SalaRepository : GenericRepository<Sala>, ISalaRepository
    {
        public SalaRepository(MeuContexto dbContext) : base(dbContext)
        {
        }
    }
}
