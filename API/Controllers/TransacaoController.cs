using Domain.Models;
using Domain.Ports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoService _transacaoService;
        public TransacaoController(ITransacaoService transacaoService)
        {
            _transacaoService = transacaoService;
        }

        // GET: api/<TransacaoController>
        [HttpGet]
        public async Task<IEnumerable<Transacao>> Get()
        {
            return await _transacaoService.ObterTodos();
        }

        // GET api/<TransacaoController>/5
        [HttpGet("{id}")]
        public async Task<Transacao> Get(Guid id)
        {
            return await _transacaoService.ObterPorId(id);
        }

        // POST api/<TransacaoController>
        [HttpPost]
        public async Task<bool> Post([FromBody] Transacao transacao)
        {
            return await _transacaoService.Adicionar(transacao);
        }

        // PUT api/<TransacaoController>/5
        [HttpPut("{id}")]
        public async Task<bool> Put(Guid id, [FromBody] Transacao transacao)
        {
            return await _transacaoService.Atualizar(id, transacao);
        }

        // DELETE api/<TransacaoController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("ID do usuário inválido.");
            }
            var usuario = await _transacaoService.ObterPorId(Guid.Parse(id.ToString()));
            if (usuario != null)
            {
                return await _transacaoService.Excluir(usuario.Id);
            }
            else
            {
                throw new KeyNotFoundException("Usuário não encontrado.");
            }
        }
    }
}
