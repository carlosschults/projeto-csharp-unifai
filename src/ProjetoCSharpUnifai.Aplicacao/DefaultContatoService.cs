using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using carlosschults.ProjetoCSharpUnifai.Aplicacao;
using carlosschults.ProjetoCSharpUnifai.Dominio;

namespace carlosschults.ProjetoCsharpUnifai.Aplicacao
{
    public class DefaultContatoService : IContatoService
    {
        private readonly IContatoRepository repo;

        public DefaultContatoService(IContatoRepository repo)
        {
            if (repo == null)
                throw new ArgumentNullException();

            this.repo = repo;
        }

        public IEnumerable<ContatoDto> GetAll()
        {
            return repo.All()
                .Select(x =>
                new ContatoDto
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Email = x.Email,
                    Telefone = x.Telefone
                });
        }

        public OperationResult Save(ContatoDto contatoDto)
        {
            Contato contato = null;

            try
            {
                contato = new Contato(0, contatoDto.Nome, contatoDto.Telefone, contatoDto.Email);
            }
            catch (ArgumentException e)
            {
                return new OperationResult(false, e.Message);
            }

            try
            {
                repo.Update(contato);
            }
            catch (Exception e)
            {
                return new OperationResult(false, e.Message);
            }

            return new OperationResult(true, null);
        }

        public OperationResult Delete(int id)
        {
            try
            {
                repo.Delete(id);
            }
            catch (Exception e)
            {
                return new OperationResult(false, e.Message);
            }

            return new OperationResult(true, null);
        }

        public ContatoDto Get(int id)
        {
            return repo.All()
                .Where(x => x.Id == id)
                .Select(x => 
                new ContatoDto
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Email = x.Email,
                    Telefone = x.Email
                })
                .Single();
        }

        public OperationResult Update(ContatoDto contatoDto)
        {
            Contato contato = null;

            try
            {
                contato = new Contato(contatoDto.Id, contatoDto.Nome, contatoDto.Telefone, contatoDto.Email);
            }
            catch (ArgumentException e)
            {
                return new OperationResult(false, e.Message);
            }

            try
            {
                repo.Update(contato);
            }
            catch (Exception e)
            {
                return new OperationResult(false, e.Message);
            }

            return new OperationResult(true, null);
        }
    }
}