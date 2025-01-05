using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }
        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarContatos();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ObterContato(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ObterContato(id);
            return View(contato); ;
        }

        [HttpPost]
        public IActionResult CriarContato(ContatoModel contato)
        {
            try
            {
                _contatoRepositorio.Adicionar(contato);
                TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Erro ao cadastrar o contato, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");

            }
        }

        [HttpPost]
        public IActionResult EditarContato(ContatoModel contato)
        {
            try
            {
                _contatoRepositorio.Editar(contato);
                TempData["MensagemSucesso"] = "Contato editado com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao editar o contato, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult ApagarContato(int id)
        {
            try
            {
                _contatoRepositorio.Excluir(id);
                TempData["MensagemSucesso"] = "Contato excluido com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao excluir o contato, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
