using AgendaSis.Application.Models.Pessoas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaSis.Application.Services.Pessoas
{
    public interface IPessoaJuridicaService
    {
        Task<List<PessoaJuridicaResponseDto>> GetAllAsync();
        Task<PessoaJuridicaResponseDto> GetByIdAsync(int id);
        Task<PessoaJuridicaResponseDto> CreateAsync(PessoaJuridicaRequestDto model);
        Task UpdateAsync(int id, PessoaJuridicaRequestDto model);
        Task DeleteAsync(int id);
    }
}
