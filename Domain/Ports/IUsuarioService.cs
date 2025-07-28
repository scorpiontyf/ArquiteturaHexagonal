using Domain.Models;

namespace Domain.Ports
{
    public interface IUsuarioService
    {
        Task<bool> AdicionarUsuarioAsync(Usuario usuario);
        Task<bool> AtualizarUsuarioAsync(Guid id, Usuario usuario);
        Task<bool> ExcluirUsuarioAsync(Guid id);
        Task<IEnumerable<Usuario>> ObterTodosUsuariosAsync();
        Task<Usuario> ObterUsuarioPorIdAsync(Guid id);
    }
}
