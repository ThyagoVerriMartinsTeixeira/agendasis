using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaSis.Application.Models.Agendas;
using AgendaSis.Application.Services.Agendas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendaSis.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly IAgendaService svc;

        public AgendaController(IAgendaService service)
        {
            svc = service;
        }

        // GET: api/Agenda
        [HttpGet]
        public async Task<IEnumerable<AgendaResponseDto>> Get()
        {
            return await svc.GetAllAsync();
        }

        // GET: api/Agenda/5
        [HttpGet("{id}", Name = "GetAgendaById")]
        public async Task<AgendaResponseDto> Get(int id)
        {
            return await svc.GetByIdAsync(id);
        }

        // POST: api/Agenda
        [HttpPost]
        public async Task<AgendaResponseDto> Post([FromBody] AgendaRequestDto model)
        {
            var pessoa = await svc.CreateAsync(model);

            return pessoa;
        }

        // PUT: api/Agenda/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] AgendaRequestDto model)
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
