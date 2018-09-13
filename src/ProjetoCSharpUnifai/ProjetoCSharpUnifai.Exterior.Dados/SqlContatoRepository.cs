using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using carlosschults.ProjetoCSharpUnifai.Aplicacao;
using carlosschults.ProjetoCSharpUnifai.Dominio;
using Dapper;

namespace carlosschults.ProjetoCSharpUnifai.Exterior.Dados
{
    public class SqlContatoRepository : IContatoRepository
    {
        private readonly string connString;

        public SqlContatoRepository(string connString)
        {
            this.connString = connString ?? throw new ArgumentNullException();
        }

        public void Save(Contato contato)
        {
            if (contato == null)
                throw new ArgumentNullException(nameof(contato));

            using (var conexao = new SqlConnection(connString))
            {
                conexao.Open();
                var newTeste = conexao.Execute("insert into contatos (nome, telefone, email) Values(@nome, @telefone, @email)", contato);
            }
        }

        public IEnumerable<Contato> All()
        {
            var resultado = Enumerable.Empty<Contato>();

            using (var conexao = new SqlConnection(connString))
            {
                conexao.Open();
                resultado = conexao.Query<ContatoDb>("select * from contatos")
                    .Select(x => new Contato(x.Id, x.Nome, x.Telefone, x.Email));
            }

            return resultado;
        }

        public void Delete(int id)
        {
            using (var conexao = new SqlConnection(connString))
            {
                conexao.Open();
                conexao.Execute("delete from contatos where id = @id", new { id = id });
            }
        }

        public void Update(Contato contato)
        {
            if (contato == null)
                throw new ArgumentNullException(nameof(contato));

            using (var conexao = new SqlConnection(connString))
            {
                conexao.Open();
                conexao.Execute("update contatos set email = @email, telefone = @telefone", contato);
            }
        }

        private class ContatoDb
        {
            public int Id;
            public string Nome;
            public string Telefone;
            public string Email;
        }
    }
}
