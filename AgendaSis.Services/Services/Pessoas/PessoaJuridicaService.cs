using AgendaSis.Application.Models.Pessoas;
using AgendaSis.Domain.Entidades;
using AgendaSis.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaSis.Application.Services.Pessoas
{
    public class PessoaJuridicaService : IPessoaJuridicaService
    {
        private readonly IPessoaJuridicaRepository _repo;

        public PessoaJuridicaService(IPessoaJuridicaRepository repo)
        {
            _repo = repo;
        }

        public async Task<PessoaJuridicaResponseDto> CreateAsync(PessoaJuridicaRequestDto model)
        {
            var pessoa = new PessoaJuridica(
                model.Nome,
                model.Telefone,
                model.Endereco,
                model.Email,
                model.Cnpj,
                model.RazaoSocial,
                model.DataAbertura
            );

            var validationResult = await pessoa.Validate();

            if (!validationResult.IsValid)
            {
                var msg = "Ocorreu os seguintes erros:\r\n";

                foreach (var erro in validationResult.Errors)
                {
                    msg = $"{msg}- {erro.ErrorMessage}\r\n";
                }

                throw new Exception(msg);
            }

            await _repo.CreateAsync(pessoa);

            return new PessoaJuridicaResponseDto
            {
                Id = pessoa.Id,
                Cnpj = pessoa.Cnpj,
                DataAbertura = pessoa.DataAbertura,
                Email = pessoa.Email,
                Endereco = pessoa.Endereco,
                Nome = pessoa.Nome,
                RazaoSocial = pessoa.RazaoSocial,
                Telefone = pessoa.Telefone
            };
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task<List<PessoaJuridicaResponseDto>> GetAllAsync()
        {
            var pessoas = await _repo.GetAllAsync();

            return pessoas.Select(s => new PessoaJuridicaResponseDto
            {
                Id = s.Id,
                Nome = s.Nome,
                RazaoSocial = s.RazaoSocial,
                Cnpj = s.Cnpj,
                DataAbertura = s.DataAbertura,
                Email = s.Email,
                Endereco = s.Endereco,
                Telefone = s.Telefone
            }).ToList();
        }

        public async Task<PessoaJuridicaResponseDto> GetByIdAsync(int id)
        {
            var pessoa = await _repo.GetByIdAsync(id);

            return new PessoaJuridicaResponseDto
            {
                Id = pessoa.Id,
                Nome = pessoa.Nome,
                RazaoSocial = pessoa.RazaoSocial,
                Cnpj = pessoa.Cnpj,
                DataAbertura = pessoa.DataAbertura,
                Email = pessoa.Email,
                Endereco = pessoa.Endereco,
                Telefone = pessoa.Telefone
            };
        }

        public async Task UpdateAsync(int id, PessoaJuridicaRequestDto model)
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
                model.Cnpj,
                model.RazaoSocial,
                model.DataAbertura
            );

            var validationResult = await pessoa.Validate();

            if (!validationResult.IsValid)
            {
                var msg = "Ocorreu os seguintes erros:\r\n";

                foreach (var erro in validationResult.Errors)
                {
                    msg = $"{msg}- {erro.ErrorMessage}\r\n";
                }

                throw new Exception(msg);
            }

            await _repo.UpdateAsync(pessoa);
        }
    }
}
