using AgendaSis.Domain.Entidades;
using AgendaSis.Domain.Interfaces;
using AgendaSis.Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaSis.Infra.Repositorios
{
    public class AgendaRepository : GenericRepository<Agenda>, IAgendaRepository
    {
        public AgendaRepository(MeuContexto dbContext)
            : base(dbContext)
        {
        }

        public async Task<List<Agenda>> GetAllWithPessoaAndSalaAsync()
        {
            return await contexto.Set<Agenda>()
                                 .Include(i => i.Pessoa)
                                 .Include(i => i.Sala)
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public async Task<Agenda> GetByIdWithPessoaAndSalaAsync(int id)
        {
            return await contexto.Set<Agenda>()
                                 .Include(i => i.Pessoa)
                                 .Include(i => i.Sala)
                                 .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}