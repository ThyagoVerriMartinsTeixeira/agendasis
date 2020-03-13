using AgendaSis.Application.Models.Salas;
using AgendaSis.Domain.Entidades;
using AgendaSis.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaSis.Application.Services.Salas
{
    public class SalaService : ISalaService
    {
        private readonly ISalaRepository _salaRepository;

        public SalaService(ISalaRepository salaRepository)
        {
            _salaRepository = salaRepository;
        }

        public async Task<SalaResponseDto> CreateAsync(SalaRequestDto model)
        {
            var sala = new Sala(model.Nome, model.Capacidade, model.Andar);
            await _salaRepository.CreateAsync(sala);
            var modelResponse = new SalaResponseDto
            {
                Id = sala.Id,
                Nome = sala.Nome,
                Andar = sala.Andar,
                Capacidade = sala.Capacidade
            };

            return modelResponse;
        }

        public async Task<IEnumerable<SalaResponseDto>> GetAllAsync()
        {
            var lista = await _salaRepository.GetAllAsync();

            return lista.Select(sala => new SalaResponseDto
            {
                Id = sala.Id,
                Nome = sala.Nome,
                Andar = sala.Andar,
                Capacidade = sala.Capacidade
            });
        }

        public async Task<SalaResponseDto> GetById(int id)
        {
            var sala = await _salaRepository.GetByIdAsync(id);

            return new SalaResponseDto
            {
                Id = sala.Id,
                Andar = sala.Andar,
                Capacidade = sala.Capacidade,
                Nome = sala.Nome
            };
        }
    }
}
