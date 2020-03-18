using AgendaSis.Application.Models.Pessoas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaSis.Application.Services.Pessoas
{
    public interface IPessoaFisicaService
    {
        Task<List<PessoaFisicaResponseDto>> GetAllAsync();
        Task<PessoaFisicaResponseDto> GetByIdAsync(int id);
        Task<PessoaFisicaResponseDto> CreateAsync(PessoaFisicaRequestDto model);
        Task UpdateAsync(int id, PessoaFisicaRequestDto model);
        Task DeleteAsync(int id);
    }
}
