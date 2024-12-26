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

        public IActionResult Apagar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CriarContato([FromBody] ContatoModel contato)
        {
            if (contato == null || string.IsNullOrEmpty(contato.Nome) || string.IsNullOrEmpty(contato.Email) || string.IsNullOrEmpty(contato.Celular))
            {
                return Json(new { sucesso = false, mensagem = "Todos os campos são obrigatórios." });
            }

            try
            {
                // Adiciona o contato ao banco de dados
                _contatoRepositorio.Adicionar(contato);

                return Json(new { sucesso = true, mensagem = "Contato criado com sucesso!"});
            }

            catch (Exception ex)
            {
                return Json(new { sucesso = false, mensagem = $"Erro ao salvar o contato: {ex.Message}" });
            }
        }

        //[HttpPost]
        //public IActionResult EditarContato([FromBody] ContatoModel contato)
        //{
        //    if (contato == null || string.IsNullOrEmpty(contato.Nome) || string.IsNullOrEmpty(contato.Email) || string.IsNullOrEmpty(contato.Celular))
        //    {
        //        return Json(new { sucesso = false, mensagem = "Todos os campos são obrigatórios." });
        //    }

        //    try
        //    {
        //        // Adiciona o contato ao banco de dados
        //        _contatoRepositorio.Editar(contato);

        //        return Json(new { sucesso = true, mensagem = "Contato criado com sucesso!" });
        //    }

        //    catch (Exception ex)
        //    {
        //        return Json(new { sucesso = false, mensagem = $"Erro ao salvar o contato: {ex.Message}" });
        //    }
        //}
    }
}
