using Domain.Models;
using Infra.Data.Context;
using Infra.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Infra.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext context) : base(context) { }
    }
}
