using System.Collections.Generic;
using carlosschults.ProjetoCSharpUnifai.Dominio;

namespace carlosschults.ProjetoCSharpUnifai.Aplicacao
{
    public interface IContatoRepository
    {
        void Save(Contato contato);
        IEnumerable<Contato> All();
        void Delete(int id);
        void Update(Contato contato);
    }
}
