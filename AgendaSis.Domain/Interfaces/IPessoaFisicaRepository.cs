using AgendaSis.Domain.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaSis.Domain.Interfaces
{
    public interface IPessoaFisicaRepository : IGenericRepository<PessoaFisica>
    {
        Task<List<PessoaFisica>> GetAllWithGenerosAsync();
        Task<PessoaFisica> GetByIdWithGenerosAsync(int id);
    }
}
