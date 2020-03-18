using AgendaSis.Application.Models.Generos;
using AgendaSis.Application.Models.Pessoas;
using AgendaSis.Domain.Entidades;
using AgendaSis.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaSis.Application.Services.Pessoas
{
    public class PessoaFisicaService : IPessoaFisicaService
    {
        private readonly IPessoaFisicaRepository _repo;

        public PessoaFisicaService(IPessoaFisicaRepository repo)
        {
            _repo = repo;
        }

        public async Task<PessoaFisicaResponseDto> CreateAsync(PessoaFisicaRequestDto model)
        {
            var pessoa = new PessoaFisica(
                model.Nome,
                model.Telefone,
                model.Endereco,
                model.Email,
                model.Cpf,
                model.GeneroId,
                model.DataNascimento
            );

            var validationResult = await pessoa.Validate();

            if (!validationResult.IsValid)
            {
                var msg = "Ocorreu os seguintes erros:\n";

                foreach (var erro in validationResult.Errors)
                {
                    msg = $"{msg}- {erro.ErrorMessage}\n";
                }

                throw new Exception(msg);
            }

            await _repo.CreateAsync(pessoa);

            return new PessoaFisicaResponseDto
            {
                Id = pessoa.Id,
                Cpf = pessoa.Cpf,
                DataNascimento = pessoa.DataNascimento,
                Email = pessoa.Email,
                Endereco = pessoa.Endereco,
                Nome = pessoa.Nome,
                Telefone = pessoa.Telefone,
                GeneroId = pessoa.GeneroId
            };
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task<List<PessoaFisicaResponseDto>> GetAllAsync()
        {
            var pessoas = await _repo.GetAllWithGenerosAsync();

            return pessoas.Select(s => new PessoaFisicaResponseDto
            {
                Id = s.Id,
                Nome = s.Nome,
                Cpf = s.Cpf,
                DataNascimento = s.DataNascimento,
                Email = s.Email,
                Endereco = s.Endereco,
                Telefone = s.Telefone,
                GeneroId = s.GeneroId,
                Genero = new GeneroResponseDto { Id = s.Genero.Id, Nome = s.Genero.Nome }
            }).ToList();
        }

        public async Task<PessoaFisicaResponseDto> GetByIdAsync(int id)
        {
            var pessoa = await _repo.GetByIdWithGenerosAsync(id);

            return new PessoaFisicaResponseDto
            {
                Id = pessoa.Id,
                Nome = pessoa.Nome,
                Cpf = pessoa.Cpf,
                DataNascimento = pessoa.DataNascimento,
                Email = pessoa.Email,
                Endereco = pessoa.Endereco,
                Telefone = pessoa.Telefone,
                GeneroId = pessoa.GeneroId,
                Genero = new GeneroResponseDto { Id = pessoa.Genero.Id, Nome = pessoa.Genero.Nome }
            };
        }

        public async Task UpdateAsync(int id, PessoaFisicaRequestDto model)
        {
            var pessoa = await _repo.GetByIdAsync(id);

            if (pessoa == null)
            {
                throw new Exception($"Pessoa Física com o id {id} não encontrada");
            }

            pessoa.UpdateValues(
                model.Nome,
                model.Telefone,
                model.Endereco,
                model.Email,
                model.Cpf,
                model.GeneroId,
                model.DataNascimento
            );

            var validationResult = await pessoa.Validate();

            if (!validationResult.IsValid)
            {
                var msg = "Ocorreu os seguintes erros:\n";

                foreach (var erro in validationResult.Errors)
                {
                    msg = $"{msg}- {erro.ErrorMessage}\n";
                }

                throw new Exception(msg);
            }

            await _repo.UpdateAsync(pessoa);
        }
    }
}
