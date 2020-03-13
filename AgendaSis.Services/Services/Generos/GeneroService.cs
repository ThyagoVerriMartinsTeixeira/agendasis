using AgendaSis.Application.Models.Generos;
using AgendaSis.Domain.Entidades;
using AgendaSis.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaSis.Application.Services.Generos
{
    public class GeneroService : IGeneroService
    {
        private readonly IGeneroRepository _repo;

        public GeneroService(IGeneroRepository repo)
        {
            _repo = repo;
        }

        public async Task<GeneroResponseDto> CreateAsync(GeneroRequestDto model)
        {
            var genero = new Genero(model.Nome);

            await _repo.CreateAsync(genero);

            var response = new GeneroResponseDto
            {
                Id = genero.Id,
                Nome = genero.Nome
            };

            return response;
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task<List<GeneroResponseDto>> GetAllAsync()
        {
            var generos = await _repo.GetAllAsync();

            return generos.Select(s => new GeneroResponseDto
            {
                Id = s.Id,
                Nome = s.Nome
            }).ToList();
        }

        public async Task<GeneroResponseDto> GetById(int id)
        {
            var genero = await _repo.GetByIdAsync(id);

            return new GeneroResponseDto
            {
                Id = genero.Id,
                Nome = genero.Nome
            };
        }
    }
}
