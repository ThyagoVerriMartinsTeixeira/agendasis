using AgendaSis.Application.Models.Generos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaSis.Application.Services.Generos
{
    public class GeneroFakeService : IGeneroService
    {
        private List<GeneroResponseDto> lista;

        public GeneroFakeService()
        {
            lista = new List<GeneroResponseDto>
            {
                new GeneroResponseDto { Id = 1, Nome = "Masculino" },
                new GeneroResponseDto { Id = 2, Nome = "Feminino" },
                new GeneroResponseDto { Id = 3, Nome = "Trans" },
                new GeneroResponseDto { Id = 4, Nome = "Outros" }
            };
        }

        public async Task<GeneroResponseDto> CreateAsync(GeneroRequestDto model)
        {
            var genero = new GeneroResponseDto
            {
                Id = lista.Count + 1,
                Nome = model.Nome
            };

            await Task.Run(() => Console.WriteLine("Inclui o genero"));

            return genero;
        }

        public async Task DeleteAsync(int id)
        {
            await Task.Run(() => Console.WriteLine("Exclui o genero " + id));
        }

        public async Task<List<GeneroResponseDto>> GetAllAsync()
        {
            await Task.Run(() => Console.WriteLine("Listei o genero"));

            return lista;
        }

        public async Task<GeneroResponseDto> GetById(int id)
        {
            await Task.Run(() => Console.WriteLine("Listei o genero"));

            return lista.FirstOrDefault(f => f.Id == id);
        }
    }
}
