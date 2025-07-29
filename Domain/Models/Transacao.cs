using Domain.Models.Enum;

namespace Domain.Models
{
    public class Transacao : Entity
    {
        public TipoTransacao TipoTransacao { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataTransacao { get; set; }
        public string Empresa { get; set; }
    }
}
