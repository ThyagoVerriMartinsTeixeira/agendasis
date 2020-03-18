using AgendaSis.Application.Models.Salas;
using AgendaSis.Domain.Entidades;
using AgendaSis.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaSis.Application.Services.Salas
{
    public class SalaService : ISalaService
    {
        private readonly ISalaRepository _repo;

        public SalaService(ISalaRepository repo)
        {
            _repo = repo;
        }

        public async Task<SalaResponseDto> CreateAsync(SalaRequestDto model)
        {
            var sala = new Sala(model.Nome, model.Capacidade, model.Andar);

            var validationResult = await sala.Validate();

            if (!validationResult.IsValid)
            {
                var msg = "Ocorreu os seguintes erros:\n";

                foreach (var erro in validationResult.Errors)
                {
                    msg = $"{msg}- {erro.ErrorMessage}\n";
                }

                throw new Exception(msg);
            }

            await _repo.CreateAsync(sala);

            var modelResponse = new SalaResponseDto
            {
                Id = sala.Id,
                Nome = sala.Nome,
                Andar = sala.Andar,
                Capacidade = sala.Capacidade
            };

            return modelResponse;
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<SalaResponseDto>> GetAllAsync()
        {
            var lista = await _repo.GetAllAsync();

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
            var sala = await _repo.GetByIdAsync(id);

            return new SalaResponseDto
            {
                Id = sala.Id,
                Andar = sala.Andar,
                Capacidade = sala.Capacidade,
                Nome = sala.Nome
            };
        }

        public async Task UpdateAsync(int id, SalaRequestDto model)
        {
            var sala = await _repo.GetByIdAsync(id);

            if (sala == null)
            {
                throw new Exception($"Sala com o id {id} não encontrada");
            }

            sala.ChangeValues(model.Nome, model.Capacidade, model.Andar);

            var validationResult = await sala.Validate();

            if (!validationResult.IsValid)
            {
                var msg = "Ocorreu os seguintes erros:\n";

                foreach (var erro in validationResult.Errors)
                {
                    msg = $"{msg}- {erro.ErrorMessage}\n";
                }

                throw new Exception(msg);
            }

            await _repo.UpdateAsync(sala);
        }
    }
}
