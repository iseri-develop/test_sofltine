using Microsoft.AspNetCore.Mvc;
using SoftlineApp.DTOs;
using SoftlineApp.Services.Interfaces;

namespace SoftlineApp.Controllers
{
    // Define que essa classe é uma API Controller e que responde em rotas como /api/cliente
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;

        // O service é injetado via construtor (injeção de dependência)
        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        // GET /api/cliente
        // Retorna todos os clientes cadastrados
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _service.GetAllAsync();
            return Ok(clientes); // Retorna 200 OK com a lista de clientes
        }

        // GET /api/cliente/{id}
        // Retorna um cliente específico pelo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _service.GetByIdAsync(id);
            if (cliente == null)
                return NotFound(); // Retorna 404 se não encontrar

            return Ok(cliente); // Retorna 200 com os dados do cliente
        }

        // POST /api/cliente
        // Cria um novo cliente com os dados enviados no corpo da requisição
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClienteDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // Retorna 400 se os dados estiverem inválidos

            await _service.AddAsync(dto); // Adiciona o cliente via service

            // Retorna 201 Created com o local do recurso e os dados criados
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        // PUT /api/cliente/{id}
        // Atualiza um cliente existente
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ClienteDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("ID da URL não bate com o corpo da requisição"); // Validação extra

            await _service.UpdateAsync(dto); // Chama o service para atualizar
            return NoContent(); // 204 No Content = sucesso, sem conteúdo de volta
        }

        // DELETE /api/cliente/{id}
        // Remove um cliente do sistema
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id); // Chama o service para deletar
            return NoContent(); // 204 No Content
        }
    }
}
