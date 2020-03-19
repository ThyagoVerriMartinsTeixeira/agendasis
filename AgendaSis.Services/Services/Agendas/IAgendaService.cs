using AgendaSis.Application.Models.Agendas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaSis.Application.Services.Agendas
{
    public interface IAgendaService
    {
        Task<IEnumerable<AgendaResponseDto>> GetAllAsync();
        Task<AgendaResponseDto> CreateAsync(AgendaRequestDto model);
        Task<AgendaResponseDto> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, AgendaRequestDto model);
    }
}
