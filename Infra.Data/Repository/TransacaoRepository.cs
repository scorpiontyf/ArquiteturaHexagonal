using Domain.Models;
using Infra.Data.Context;
using Infra.Data.Repository.Interfaces;

namespace Infra.Data.Repository
{
    public class TransacaoRepository : Repository<Transacao>, ITransacaoRepository
    {
        public TransacaoRepository(AppDbContext context) : base(context) { }
    }
}
