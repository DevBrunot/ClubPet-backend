using Microsoft.AspNetCore.Mvc;
using ClubPetAPI.Data;
using System.Collections.Generic;
using MeuProjetoAPI.Models;

namespace ClubPetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuariosController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> GetUsuarios()
        {
            return Ok(_usuarioRepository.GetUsuarios());
        }

        [HttpGet("{id}")]
        public ActionResult<Usuario> GetUsuario(int id)
        {
            var usuario = _usuarioRepository.GetUsuario(id);
            if (usuario == null)
            {
                return NotFound(new { Message = "Usuário não encontrado." });
            }
            return Ok(usuario);
        }

        [HttpPost]
        public ActionResult<Usuario> PostUsuario(Usuario usuario)
        {
            var novoUsuario = _usuarioRepository.AddUsuario(usuario);
            return CreatedAtAction(nameof(GetUsuario), new { id = novoUsuario.Id }, novoUsuario);
        }

        [HttpPut("{id}")]
        public IActionResult PutUsuario(int id, Usuario usuario)
        {
            var atualizado = _usuarioRepository.UpdateUsuario(id, usuario);
            if (!atualizado)
            {
                return NotFound(new { Message = "Usuário não encontrado para atualização." });
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario(int id)
        {
            var deletado = _usuarioRepository.DeleteUsuario(id);
            if (!deletado)
            {
                return NotFound(new { Message = "Usuário não encontrado para exclusão." });
            }
            return NoContent();
        }
    }
}
