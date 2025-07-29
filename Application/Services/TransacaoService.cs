using Domain.Models;
using Domain.Ports;
using Infra.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class TransacaoService : ITransacaoService
    {
        private readonly ITransacaoRepository _transacaoRepository;
        public TransacaoService(ITransacaoRepository transacaoRepository)
        {
            _transacaoRepository = transacaoRepository;
        }

        public async Task<bool> Adicionar(Transacao Transacao)
        {
            if (!Transacao.ValidarTransacao())
                throw new ArgumentException("Dados do usuário inválidos.");
            await _transacaoRepository.Criar(Transacao);
            return true;
        }

        public async Task<bool> Atualizar(Guid id, Transacao Transacao)
        {
            var transacaoAnterior = await _transacaoRepository.ObterPorId(t => t.Id == id);
            if (transacaoAnterior == null)
                throw new ArgumentException("Usuário não encontrado.");

            transacaoAnterior.Atualizar(Transacao);
            await _transacaoRepository.Atualizar(transacaoAnterior);
            return true;
        }

        public async Task<bool> Excluir(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("ID do usuário inválido.");
            var transacao = await _transacaoRepository.ObterPorId(t => t.Id == id);
            if (transacao == null)
                throw new ArgumentException("Usuário não encontrado");
            await _transacaoRepository.Remover(transacao);
            return true;
        }

        public async Task<IEnumerable<Transacao>> ObterTodos()
        {
            var Transacao = _transacaoRepository.ObterTodos();
            return await Transacao.ToListAsync();
        }

        public async Task<Transacao> ObterPorId(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("ID do usuário inválido.");
            return await _transacaoRepository.ObterPorId(t => t.Id == id);
        }
    }
}
