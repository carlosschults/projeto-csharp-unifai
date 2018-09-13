using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using carlosschults.ProjetoCSharpUnifai.Aplicacao;
using Dapper;

namespace carlosschults.ProjetoCsharpUnifai.Exterior.Apresentacao.WinForm
{
    internal class DefaultContatoService : IContatoService
    {
        public IEnumerable<ContatoDto> GetAll()
        {
            IEnumerable<ContatoDto> contatos = Enumerable.Empty<ContatoDto>();

            var stringConexao = @"Server=srv010\smartbiohml;User Id=software;Password=smart123;Database=IPMSYSTEM_Carlos_Schults02;";
            using (var conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();
                contatos = conexao.Query<ContatoDto>("select * from contatos");
            }

            return contatos;
        }

        public OperationResult Save(ContatoDto contato)
        {
            // TODO remover duplicação
            var stringConexao = @"Server=srv010\smartbiohml;User Id=software;Password=smart123;Database=IPMSYSTEM_Carlos_Schults02;";
            using (var conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();
                var newTeste = conexao.Execute("insert into contatos (nome, telefone, email) Values(@nome, @telefone, @email)", contato);
            }

            // TODO fazer uma validação de verdade
            return new OperationResult(true, null);
        }

        public OperationResult Delete(int id)
        {
            var stringConexao = @"Server=srv010\smartbiohml;User Id=software;Password=smart123;Database=IPMSYSTEM_Carlos_Schults02;";
            using (var conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();
                conexao.Execute("delete from contatos where id = @id", new { id = id});
            }

            // TODO fazer uma validação de verdade
            return new OperationResult(true, null);
        }

        public ContatoDto Get(int id)
        {
            ContatoDto contato = null;

            var stringConexao = @"Server=srv010\smartbiohml;User Id=software;Password=smart123;Database=IPMSYSTEM_Carlos_Schults02;";
            using (var conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();
                contato = conexao.Query<ContatoDto>("select * from contatos where id = @id", new { id = id }).Single();
            }

            return contato;
        }

        public OperationResult Update(ContatoDto contato)
        {
            var stringConexao = @"Server=srv010\smartbiohml;User Id=software;Password=smart123;Database=IPMSYSTEM_Carlos_Schults02;";
            using (var conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();
                conexao.Execute("update contatos set telefone = @telefone, email = @email where id = @id", contato);
            }

            // TODO fazer uma validação de verdade
            return new OperationResult(true, null);
        }
    }
}