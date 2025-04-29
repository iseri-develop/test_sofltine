using SoftlineApp.DTOs;
using SoftlineApp.Models;
using SoftlineApp.Repositories.Interfaces;
using SoftlineApp.Services.Interfaces;

namespace SoftlineApp.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;

        // Injeção de dependência do repositório
        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        // Retorna todos os clientes do banco, convertendo para DTOs
        public async Task<IEnumerable<ClienteDTO>> GetAllAsync()
        {
            var clientes = await _repository.GetAllAsync();

            // Faz a conversão de Cliente (model) para ClienteDTO
            return clientes.Select(c => new ClienteDTO
            {
                Id = c.Id,
                Nome = c.Nome,
                Fantasia = c.Fantasia,
                Documento = c.Documento,
                Endereco = c.Endereco
            });
        }

        // Retorna um cliente específico por ID (convertido para DTO)
        public async Task<ClienteDTO?> GetByIdAsync(int id)
        {
            var c = await _repository.GetByIdAsync(id);
            if (c == null) return null;

            return new ClienteDTO
            {
                Id = c.Id,
                Nome = c.Nome,
                Fantasia = c.Fantasia,
                Documento = c.Documento,
                Endereco = c.Endereco
            };
        }

        // Adiciona um novo cliente (converte DTO → Model)
        public async Task AddAsync(ClienteDTO dto)
        {
            var cliente = new Cliente
            {
                Nome = dto.Nome,
                Fantasia = dto.Fantasia,
                Documento = dto.Documento,
                Endereco = dto.Endereco
            };

            await _repository.AddAsync(cliente);
        }

        // Atualiza um cliente existente, se ele existir
        public async Task UpdateAsync(ClienteDTO dto)
        {
            var cliente = await _repository.GetByIdAsync(dto.Id);
            if (cliente == null) return;

            cliente.Nome = dto.Nome;
            cliente.Fantasia = dto.Fantasia;
            cliente.Documento = dto.Documento;
            cliente.Endereco = dto.Endereco;

            await _repository.UpdateAsync(cliente);
        }

        // Remove um cliente por ID (apenas se existir)
        public async Task DeleteAsync(int id)
        {
            var cliente = await _repository.GetByIdAsync(id);
            if (cliente != null)
            {
                await _repository.DeleteAsync(cliente);
            }
        }
    }
}
