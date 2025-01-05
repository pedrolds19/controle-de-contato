using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;


        public ContatoRepositorio(BancoContext bancoContext)
        {
            this._bancoContext = bancoContext;
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();

            return contato;
        }

        public ContatoModel ObterContato(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public List<ContatoModel> BuscarContatos()
        {
            return _bancoContext.Contatos.ToList();
        }

        public ContatoModel Editar(ContatoModel contato)
        {
            ContatoModel contatoDB = ObterContato(contato.Id);

            if (contatoDB == null) throw new System.Exception("Houve um erro na atualização do contato");

            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();

            return contatoDB;
        }

        public bool Excluir(int id)
        {
            ContatoModel contatoDB = ObterContato(id);

            if (contatoDB == null) throw new System.Exception("Houve um erro na exclusão do contato");
 
            _bancoContext.Contatos.Remove(contatoDB);
            _bancoContext.SaveChanges();

            return true;
        }


    }
}
