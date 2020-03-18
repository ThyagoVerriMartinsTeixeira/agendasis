using AgendaSis.Application.Models.Pessoas;
using AgendaSis.Application.Services.Pessoas;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaSis.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasFisicasController : ControllerBase
    {
        private readonly IPessoaFisicaService svc;

        public PessoasFisicasController(IPessoaFisicaService service)
        {
            svc = service;
        }

        // GET: api/PessoasFisicas
        [HttpGet]
        public async Task<IEnumerable<PessoaFisicaResponseDto>> Get()
        {
            return await svc.GetAllAsync();
        }

        // GET: api/PessoasFisicas/5
        [HttpGet("{id}", Name = "GetPessoaFisicaById")]
        public async Task<PessoaFisicaResponseDto> Get(int id)
        {
            return await svc.GetByIdAsync(id);
        }

        // POST: api/PessoasFisicas
        [HttpPost]
        public async Task<PessoaFisicaResponseDto> Post([FromBody] PessoaFisicaRequestDto model)
        {
            var pessoa = await svc.CreateAsync(model);

            return pessoa;
        }

        // PUT: api/PessoasFisicas/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] PessoaFisicaRequestDto model)
        {
            await svc.UpdateAsync(id, model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await svc.DeleteAsync(id);
        }
    }
}
