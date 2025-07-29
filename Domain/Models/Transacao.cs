using Domain.Models.Enum;

namespace Domain.Models
{
    public class Transacao : Entity
    {
        public TipoTransacao TipoTransacao { get; private set; }
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataTransacao { get; private set; }
        public string Empresa { get; private set; }

        public void Atualizar(Transacao transacao)
        {
            bool transacaoValida = ValidarTransacao();

            if (!transacaoValida) throw new ArgumentException("Dados da transação inválidos.");

            TipoTransacao = transacao.TipoTransacao;
            Descricao = transacao.Descricao;
            Valor = transacao.Valor;
            DataTransacao = transacao.DataTransacao;
            Empresa = transacao.Empresa;
        }

        public bool ValidarTransacao()
        {
            if (string.IsNullOrWhiteSpace(Descricao))
                return false;
            if (DataTransacao == default || DataTransacao.Year > DateTime.Now.Year)
                return false;
            return true;
        }
    }
}
