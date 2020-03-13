using AgendaSis.Application.Models.Salas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgendaSis.Application.Services.Salas
{
    public interface ISalaService
    {
        Task<IEnumerable<SalaResponseDto>> GetAllAsync();
        Task<SalaResponseDto> CreateAsync(SalaRequestDto model);
        Task<SalaResponseDto> GetById(int id);
    }
}
