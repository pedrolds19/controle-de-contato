using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel ObterContato(int id);
        List<ContatoModel> BuscarContatos();
        ContatoModel Adicionar(ContatoModel contato);
        void Editar(ContatoModel contato);
    }
}
