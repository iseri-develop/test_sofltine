using Microsoft.AspNetCore.Mvc;
using SoftlineApp.DTOs;
using SoftlineApp.Services.Interfaces;

namespace SoftlineApp.Controllers
{
    // Define que essa classe é uma API Controller e que responde em rotas como /api/login
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioService _service;

        // O service é injetado via construtor (injeção de dependência)
        public LoginController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var valido = await _service.ValidarLoginAsync(dto);

            if (!valido)
                return Unauthorized("Usuário ou senha inválidos");

            return Ok("Login bem-sucedido!");
        }
    }
}
