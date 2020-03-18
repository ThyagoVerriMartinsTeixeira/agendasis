using AgendaSis.Application.Models.Pessoas;
using AgendaSis.Application.Services.Pessoas;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaSis.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasJuridicasController : ControllerBase
    {
        private readonly IPessoaJuridicaService svc;

        public PessoasJuridicasController(IPessoaJuridicaService service)
        {
            svc = service;
        }

        // GET: api/PessoasJuridicas
        [HttpGet]
        public async Task<IEnumerable<PessoaJuridicaResponseDto>> Get()
        {
            return await svc.GetAllAsync();
        }

        // GET: api/PessoasJuridicas/5
        [HttpGet("{id}", Name = "GetPessoaJuridicaById")]
        public async Task<PessoaJuridicaResponseDto> Get(int id)
        {
            return await svc.GetByIdAsync(id);
        }

        // POST: api/PessoasJuridicas
        [HttpPost]
        public async Task<PessoaJuridicaResponseDto> Post([FromBody] PessoaJuridicaRequestDto model)
        {
            var pessoa = await svc.CreateAsync(model);

            return pessoa;
        }

        // PUT: api/PessoasJuridicas/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] PessoaJuridicaRequestDto model)
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
