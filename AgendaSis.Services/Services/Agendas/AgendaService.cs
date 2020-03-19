using AgendaSis.Application.Models.Agendas;
using AgendaSis.Application.Models.Pessoas;
using AgendaSis.Application.Models.Salas;
using AgendaSis.Domain.Entidades;
using AgendaSis.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaSis.Application.Services.Agendas
{
    public class AgendaService : IAgendaService
    {
        private readonly IAgendaRepository _repo;

        public AgendaService(IAgendaRepository repo)
        {
            _repo = repo;
        }

        public async Task<AgendaResponseDto> CreateAsync(AgendaRequestDto model)
        {
            var agenda = new Agenda(
                Convert.ToDateTime(model.Data),
                Convert.ToDateTime($"{model.Data} {model.HoraInicio}"),
                Convert.ToDateTime($"{model.Data} {model.HoraFim}"),
                model.SalaId,
                model.PessoaId,
                model.QuantidadePessoas
            );

            await _repo.CreateAsync(agenda);

            return new AgendaResponseDto
            {
                Id = agenda.Id,
                Data = agenda.Data.ToString("dd/MM/yyyy"),
                HoraInicio = agenda.HoraInicio.ToString("HH:mm"),
                HoraFim = agenda.HoraFim.ToString("HH:mm"),
                QuantidadePessoas = agenda.QuantidadePessoas,
                PessoaId = agenda.PessoaId,
                SalaId = agenda.SalaId
            };
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<AgendaResponseDto>> GetAllAsync()
        {
            var agendas = await _repo.GetAllWithPessoaAndSalaAsync();

            return agendas.Select(agenda => new AgendaResponseDto
            {
                Id = agenda.Id,
                Data = agenda.Data.ToString("dd/MM/yyyy"),
                HoraInicio = agenda.HoraInicio.ToString("HH:mm"),
                HoraFim = agenda.HoraFim.ToString("HH:mm"),
                QuantidadePessoas = agenda.QuantidadePessoas,
                PessoaId = agenda.PessoaId,
                SalaId = agenda.SalaId,
                Pessoa = new PessoaResponseDto { Nome = agenda.Pessoa.Nome },
                Sala = new SalaResponseDto
                {
                    Id = agenda.SalaId,
                    Andar = agenda.Sala.Andar,
                    Nome = agenda.Sala.Nome,
                    Capacidade = agenda.Sala.Capacidade
                }
            });
        }

        public async Task<AgendaResponseDto> GetByIdAsync(int id)
        {
            var agendas = await _repo.GetByIdWithPessoaAndSalaAsync(id);

            return new AgendaResponseDto
            {
                Id = agendas.Id,
                Data = agendas.Data.ToString("dd/MM/yyyy"),
                HoraInicio = agendas.HoraInicio.ToString("HH:mm"),
                HoraFim = agendas.HoraFim.ToString("HH:mm"),
                QuantidadePessoas = agendas.QuantidadePessoas,
                PessoaId = agendas.PessoaId,
                SalaId = agendas.SalaId,
                Pessoa = new PessoaResponseDto { Nome = agendas.Pessoa.Nome },
                Sala = new SalaResponseDto
                {
                    Id = agendas.SalaId,
                    Andar = agendas.Sala.Andar,
                    Nome = agendas.Sala.Nome,
                    Capacidade = agendas.Sala.Capacidade
                }
            };
        }

        public async Task UpdateAsync(int id, AgendaRequestDto model)
        {
            var agenda = await _repo.GetByIdAsync(id);

            if (agenda == null)
            {
                throw new Exception($"Agenda com o id {id} não encontrada");
            }

            agenda.UpdateValues(Convert.ToDateTime(model.Data),
                                 Convert.ToDateTime($"{model.Data} {model.HoraInicio}"),
                                 Convert.ToDateTime($"{model.Data} {model.HoraFim}"),
                                 model.SalaId,
                                 model.PessoaId,
                                 model.QuantidadePessoas);

            var validationResult = await agenda.Validate();

            if (!validationResult.IsValid)
            {
                var msg = "Ocorreu os seguintes erros:\n";

                foreach (var erro in validationResult.Errors)
                {
                    msg = $"{msg}- {erro.ErrorMessage}\n";
                }

                throw new Exception(msg);
            }

            await _repo.UpdateAsync(agenda);



        }
    }
}
