using Domain.Models;
using Domain.Ports;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public async Task<IEnumerable<Usuario>> Get()
        {
            return await _usuarioService.ObterTodosUsuariosAsync();
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public async Task<Usuario> Get(Guid id)
        {
            return await _usuarioService.ObterUsuarioPorIdAsync(id);
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public async Task<bool> Post([FromBody] Usuario usuario)
        {
            return await _usuarioService.AdicionarUsuarioAsync(usuario);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public async Task<bool> Put(Guid id, [FromBody] Usuario usuario)
        {
            return await _usuarioService.AtualizarUsuarioAsync(id, usuario);
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("ID do usuário inválido.");
            }
            var usuario = await _usuarioService.ObterUsuarioPorIdAsync(Guid.Parse(id.ToString()));
            if (usuario != null)
            {
                return await _usuarioService.ExcluirUsuarioAsync(usuario.Id);
            }
            else
            {
                throw new KeyNotFoundException("Usuário não encontrado.");
            }
        }
    }
}
