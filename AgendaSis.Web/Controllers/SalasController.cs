using AgendaSis.Application.Models.Salas;
using AgendaSis.Application.Services.Salas;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaSis.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalasController : ControllerBase
    {
        private readonly ISalaService svc;

        public SalasController(ISalaService service)
        {
            svc = service;
        }

        // GET: api/Salas
        [HttpGet]
        public async Task<IEnumerable<SalaResponseDto>> Get()
        {
            return await svc.GetAllAsync();
        }

        // GET: api/Salas/5
        [HttpGet("{id}", Name = "GetSalaById")]
        public async Task<SalaResponseDto> Get(int id)
        {
            return await svc.GetById(id);
        }

        // POST: api/Salas
        [HttpPost]
        public async Task<SalaResponseDto> Post([FromBody] SalaRequestDto model)
        {
            var response = await svc.CreateAsync(model);

            return response;
        }

        // PUT: api/Salas/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] SalaRequestDto model)
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
