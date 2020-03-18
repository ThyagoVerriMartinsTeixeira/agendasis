using AgendaSis.Application.Models.Salas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaSis.Application.Services.Salas
{
    public interface ISalaService
    {
        Task<IEnumerable<SalaResponseDto>> GetAllAsync();
        Task<SalaResponseDto> CreateAsync(SalaRequestDto model);
        Task<SalaResponseDto> GetById(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, SalaRequestDto model);
    }
}
