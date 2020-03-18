using AgendaSis.Application.Models.Generos;
using AgendaSis.Application.Services.Generos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaSis.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly IGeneroService svc;

        public GenerosController(IGeneroService service)
        {
            svc = service;
        }

        // GET: api/Generos
        [HttpGet]
        public async Task<IEnumerable<GeneroResponseDto>> Get()
        {
            return await svc.GetAllAsync();
        }

        // GET: api/Generos/5
        [HttpGet("{id}", Name = "GetGeneroById")]
        public async Task<GeneroResponseDto> Get(int id)
        {
            return await svc.GetById(id);
        }

        // POST: api/Generos
        [HttpPost]
        public async Task<GeneroResponseDto> Post([FromBody] GeneroRequestDto model)
        {
            var response = await svc.CreateAsync(model);

            return response;
        }

        // PUT: api/Generos/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Generos/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await svc.DeleteAsync(id);
        }
    }
}
