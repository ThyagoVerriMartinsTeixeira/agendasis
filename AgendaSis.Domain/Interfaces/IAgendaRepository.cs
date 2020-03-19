using AgendaSis.Domain.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaSis.Domain.Interfaces
{
    public interface IAgendaRepository : IGenericRepository<Agenda>
    {
        Task<List<Agenda>> GetAllWithPessoaAndSalaAsync();
        Task<Agenda> GetByIdWithPessoaAndSalaAsync(int id);
    }
}