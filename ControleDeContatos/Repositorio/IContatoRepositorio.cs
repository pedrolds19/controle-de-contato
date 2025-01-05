using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel ObterContato(int id);
        List<ContatoModel> BuscarContatos();
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Editar(ContatoModel contato);
        bool Excluir(int id);
    }
}
