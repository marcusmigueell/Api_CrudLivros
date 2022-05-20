using Api.Net_Core.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Api.Net_Core.Logica {

    public class LivrosController : Controller {

        public IActionResult ParaLer() {
            var _repo = new LivroRepositorioCSV();
            ViewBag.Livros = _repo.ParaLer.Livros;
            return View("lista");
        }

        public IActionResult Lendo() {
            var _repo = new LivroRepositorioCSV();
            ViewBag.Livros = _repo.Lendo.Livros;
            return View("lista");
        }

        public IActionResult Lidos() {
            var _repo = new LivroRepositorioCSV();
            ViewBag.Livros = _repo.Lidos.Livros;
            return View("lista");
        }

        public string Detalhes(int id) {
            var repo = new LivroRepositorioCSV();
            var livro = repo.Todos.First(l => l.Id == id);
            return livro.Detalhes();
        }

    }
}
