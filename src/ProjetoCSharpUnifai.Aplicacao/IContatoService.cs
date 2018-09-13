using System.Collections.Generic;

namespace carlosschults.ProjetoCSharpUnifai.Aplicacao
{
    public interface IContatoService
    {
        IEnumerable<ContatoDto> GetAll();
        OperationResult Save(ContatoDto contato);
        OperationResult Delete(int id);
    }
}