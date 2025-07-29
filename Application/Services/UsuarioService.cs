using Domain.Models;
using Domain.Ports;
using Infra.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> Adicionar(Usuario usuario)
        {
            if (!usuario.ValidarUsuario())
                throw new ArgumentException("Dados do usuário inválidos.");
            await _usuarioRepository.Criar(usuario);
            return true;
        }

        public async Task<bool> Atualizar(Guid id, Usuario usuario)
        {
            var usuarioAnterior = await _usuarioRepository.ObterPorId(t => t.Id == id);
            if (usuarioAnterior == null)
                throw new ArgumentException("Usuário não encontrado.");

            usuarioAnterior.Atualizar(usuario);
            await _usuarioRepository.Atualizar(usuarioAnterior);
            return true;
        }

        public async Task<bool> Excluir(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("ID do usuário inválido.");
            var usuario = await _usuarioRepository.ObterPorId(t => t.Id == id);
            if (usuario == null)
                throw new ArgumentException("Usuário não encontrado");
            await _usuarioRepository.Remover(usuario);
            return true;
        }

        public async Task<IEnumerable<Usuario>> ObterTodos()
        {
            var usuario = _usuarioRepository.ObterTodos();
            return await usuario.ToListAsync();
        }

        public async Task<Usuario> ObterPorId(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("ID do usuário inválido.");
            return await _usuarioRepository.ObterPorId(t => t.Id == id);
        }
    }
}