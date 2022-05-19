using Api.Net_Core.Html;
using Api.Net_Core.Negocio;
using Api.Net_Core.Repositorio;

namespace Api.Net_Core.Logica {

    public class CadastroLogica {

        public static Task Incluir(HttpContext context) {

            var livro = new Livro() {
                Titulo = context.Request.Form["titulo"].First(),
                Autor = context.Request.Form["autor"].First()
            };

            var repo = new LivroRepositorioCSV();
            repo.Incluir(livro);

            return context.Response.WriteAsync("O livro foi adicionado com sucesso!");
        }

        public static Task ExibeFormulario(HttpContext context) {

            var html = HtmlUtils.CarregaArquivoHTML("formulario");
            var HtmlString = Convert.ToString(html);

            if (HtmlString != null)
                return context.Response.WriteAsync(HtmlString);

            return context.Response.WriteAsync("Desculpe! Não foi possivel carregar a página.");
        }

        public static Task NovoLivro(HttpContext context) {

            var livro = new Livro() {
                Titulo = Convert.ToString(context.GetRouteValue("nome")),
                Autor = Convert.ToString(context.GetRouteValue("autor")),
            };

            var repo = new LivroRepositorioCSV();
            repo.Incluir(livro);

            return context.Response.WriteAsync("O livro foi adicionado com sucesso!");

        }
    }
}
