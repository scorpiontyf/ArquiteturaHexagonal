namespace Domain.Models
{
    public class Usuario : Entity
    {
        public string Nome { get; private set; }
        public int Idade => DateTime.Now.Month < DataNascimento.Month ? DateTime.Now.Year - DataNascimento.Year : (DateTime.Now.Year - DataNascimento.Year) - 1;
        public DateOnly DataNascimento { get; private set; }
        public Usuario(string nome, DateOnly dataNascimento)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Atualizar(Usuario usuario)
        {
            bool usuarioValido = ValidarUsuario();

            if (!usuarioValido) throw new ArgumentException("Dados do usuário inválidos.");

            Nome = usuario.Nome;
            DataNascimento = usuario.DataNascimento;
            UpdatedAt = DateTime.UtcNow;
        }

        public bool ValidarUsuario()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                return false;
            if (DataNascimento == default || DataNascimento.Year > DateTime.Now.Year)
                return false;
            return true;
        }
    }
}
