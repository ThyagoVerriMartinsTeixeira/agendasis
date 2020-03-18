using AgendaSis.Domain.Entidades;
using AgendaSis.Domain.Interfaces;
using AgendaSis.Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaSis.Infra.Repositorios
{
    public class PessoaFisicaRepository : GenericRepository<PessoaFisica>, IPessoaFisicaRepository
    {
        public PessoaFisicaRepository(MeuContexto dbContext) : base(dbContext)
        {
        }

        public async Task<List<PessoaFisica>> GetAllWithGenerosAsync()
        {
            return await contexto.Set<PessoaFisica>()
                    .Include(i => i.Genero)
                    .AsNoTracking()
                    .ToListAsync();
        }

        public async Task<PessoaFisica> GetByIdWithGenerosAsync(int id)
        {
            return await contexto.Set<PessoaFisica>()
                    .Include(i => i.Genero)
                    .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
