using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SorveteriaApp.Application.DTOs;
using SorveteriaApp.Application.Interfaces;
using SorveteriaApp.Domain.Entities;
using SorveteriaApp.Domain.Interfaces;

namespace SorveteriaApp.Application.Services
{
    public class SaborService : ISaborService
    {
        private readonly ISaborRepository _saborRepository;

        public SaborService(ISaborRepository saborRepository)
        {
            _saborRepository = saborRepository;
        }

        public async Task<IEnumerable<SaborDto>> GetAllSaboresAsync()
        {
            var sabores = await _saborRepository.GetAllAsync();
            return sabores.Select(MapToDto);
        }

        public async Task<SaborDto> GetSaborByIdAsync(int id)
        {
            var sabor = await _saborRepository.GetByIdAsync(id);
            return sabor != null ? MapToDto(sabor) : null;
        }

        public async Task<IEnumerable<SaborDto>> GetSaboresByCategoriaAsync(string categoria)
        {
            var sabores = await _saborRepository.GetByCategoriaAsync(categoria);
            return sabores.Select(MapToDto);
        }

        public async Task<IEnumerable<SaborDto>> GetSaboresDisponiveisAsync()
        {
            var sabores = await _saborRepository.GetDisponiveisAsync();
            return sabores.Select(MapToDto);
        }

        public async Task<SaborDto> CreateSaborAsync(SaborCreateDto saborDto)
        {
            // Validação de código único
            if (await _saborRepository.CodigoExistsAsync(saborDto.CodigoProduto))
            {
                throw new InvalidOperationException("Já existe um sabor com este código");
            }

            var sabor = new Sabor(
                saborDto.Nome,
                saborDto.Categoria,
                saborDto.CodigoProduto,
                saborDto.PrecoPorKg
            );

            await _saborRepository.AddAsync(sabor);
            return MapToDto(sabor);
        }

        public async Task UpdateSaborAsync(SaborUpdateDto saborDto)
        {
            var sabor = await _saborRepository.GetByIdAsync(saborDto.Id);
            if (sabor == null)
            {
                throw new KeyNotFoundException("Sabor não encontrado");
            }

            // Validação de código único (exceto o próprio sabor)
            var saborComMesmoCodigo = await _saborRepository.GetByCodigoAsync(saborDto.CodigoProduto);
            if (saborComMesmoCodigo != null && saborComMesmoCodigo.Id != saborDto.Id)
            {
                throw new InvalidOperationException("Já existe outro sabor com este código");
            }

            sabor.Atualizar(
                saborDto.Nome,
                saborDto.Categoria,
                saborDto.CodigoProduto,
                saborDto.PrecoPorKg
            );

            if (saborDto.Disponivel)
                sabor.MarcarComoDisponivel();
            else
                sabor.MarcarComoIndisponivel();

            await _saborRepository.UpdateAsync(sabor);
        }

        public async Task DeleteSaborAsync(int id)
        {
            var sabor = await _saborRepository.GetByIdAsync(id);
            if (sabor == null)
            {
                throw new KeyNotFoundException("Sabor não encontrado");
            }

            await _saborRepository.DeleteAsync(id);
        }

        public async Task<bool> CodigoExistsAsync(string codigo, int? saborId = null)
        {
            var sabor = await _saborRepository.GetByCodigoAsync(codigo);
            
            if (sabor == null)
                return false;

            if (saborId.HasValue && sabor.Id == saborId.Value)
                return false;

            return true;
        }

        private SaborDto MapToDto(Sabor sabor)
        {
            return new SaborDto
            {
                Id = sabor.Id,
                Nome = sabor.Nome,
                Categoria = sabor.Categoria,
                CodigoProduto = sabor.CodigoProduto,
                PrecoPorKg = sabor.PrecoPorKg,
                Disponivel = sabor.Disponivel,
                DataCriacao = sabor.DataCriacao
            };
        }
    }
}
