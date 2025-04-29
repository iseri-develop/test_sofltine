using Microsoft.EntityFrameworkCore;
using SoftlineApp.Data;
using SoftlineApp.Models;
using SoftlineApp.Repositories.Interfaces;

namespace SoftlineApp.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        //Injeção de dependência do DbContext (acesso ao banco)
        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        // Busca todos os produtos da tabela
        public async Task<IEnumerable<Produto>> GetAllAsync()
        {
            return await _context.Produtos.ToListAsync();
        }

        // Busca produto por ID
        public async Task<Produto?> GetByIdAsync(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        // Adiciona um novo produto ao banco
        public async Task AddAsync(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
        }

        // Atualiza um produto existente
        public async Task UpdateAsync(Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }

        // Remove um produto do banco
        public async Task DeleteAsync(Produto produto)
        {
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }
    }
}
