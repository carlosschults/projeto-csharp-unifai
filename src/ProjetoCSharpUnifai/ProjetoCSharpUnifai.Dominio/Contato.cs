using System;

namespace carlosschults.ProjetoCSharpUnifai.Dominio
{
    public class Contato
    {
        private readonly int id;
        private readonly string nome;
        private readonly string telefone;
        private readonly string email;

        public int Id => id;

        public string Nome => nome;

        public string Telefone => telefone;

        public string Email => email;

        public Contato(int id, string nome, string telefone, string email)
        {
            this.id = ValidarId(id);
            this.nome = ValidarNome(nome);
            this.telefone = ValidarTelefone(telefone);
            this.email = ValidarEmail(email);
        }

        private string ValidarEmail(string email)
        {
            if (email.Contains("@") && !email.EndsWith("@"))
                return email;

            throw new ArgumentException("E-mail precisa ser válido (conter uma @).", nameof(email));
        }

        private string ValidarTelefone(string telefone)
        {
            for (var i = 0; i < telefone.Length; i++)
            {
                if (i == 21)
                    throw new ArgumentException("Telefone deve ter no máximo 20 caracteres.", nameof(telefone));

                if (!Char.IsNumber(telefone[i]))
                    throw new ArgumentException("Telefone deve conter apenas números!", nameof(telefone));
            }

            return telefone;
        }

        private string ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome não pode ser vazio.", nameof(telefone));

            if (nome.Length > 30)
                throw new ArgumentException("Nome deve ter no máximo 30 caracteres.", nameof(telefone));

            return nome;
        }

        private int ValidarId(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id não pode ser negativo.");

            return id;
        }
    }
}
