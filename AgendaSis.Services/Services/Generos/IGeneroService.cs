using AgendaSis.Application.Models.Generos;
using AgendaSis.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgendaSis.Application.Services.Generos
{
    public interface IGeneroService
    {
        Task<List<GeneroResponseDto>> GetAllAsync();
        Task<GeneroResponseDto> CreateAsync(GeneroRequestDto model);
        Task<GeneroResponseDto> GetById(int id);
        Task DeleteAsync(int id);
    }
}
