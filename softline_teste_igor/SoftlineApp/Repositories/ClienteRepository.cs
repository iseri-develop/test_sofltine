using Microsoft.EntityFrameworkCore;
using SoftlineApp.Data;
using SoftlineApp.Models;
using SoftlineApp.Repositories.Interfaces;

namespace SoftlineApp.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        // Injeção de dependência do DbContext (acesso ao banco)
        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        // Retorna todos os clientes da tabela
        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        // Busca um cliente pelo ID (pode retornar null)
        public async Task<Cliente?> GetByIdAsync(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        // Adiciona um novo cliente no banco
        public async Task AddAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }

        // Atualiza um cliente existente
        public async Task UpdateAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        // Remove um cliente do banco
        public async Task DeleteAsync(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
