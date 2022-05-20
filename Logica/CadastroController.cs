using Api.Net_Core.Negocio;
using Api.Net_Core.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Api.Net_Core.Logica {

    public class CadastroController {

        public string Incluir(Livro livro) {
            var repo = new LivroRepositorioCSV();
            repo.Incluir(livro);
            return "O livro foi adicionado com sucesso!";
        }

        public IActionResult ExibeFormulario() {
            var html = new ViewResult { ViewName = "Formulario" };
            return html;
        }
    }
}
