using Microsoft.AspNetCore.Mvc;
using SoftlineApp.DTOs;
using SoftlineApp.Services.Interfaces;

namespace SoftlineApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UsuarioDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.CadastrarAsync(dto);
            return Created("", dto);
        }
    }
}
