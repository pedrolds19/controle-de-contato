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

        public void Editar(ContatoModel contato)
        {
            throw new NotImplementedException();
        }

  
    }
}
