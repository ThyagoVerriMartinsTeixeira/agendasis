using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaSis.Application.Models.Generos;
using AgendaSis.Application.Services.Generos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet("{id}", Name = "GetGeneroId")]
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

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await svc.DeleteAsync(id);
        }
    }
}
