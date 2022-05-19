using Api.Net_Core.Html;
using Api.Net_Core.Negocio;
using Api.Net_Core.Repositorio;

namespace Api.Net_Core.Logica {

    public class LivrosLogica {

        public static string CarregaLista(IEnumerable<Livro> livros) {

            var conteudoArquivo = HtmlUtils.CarregaArquivoHTML("para-ler");

            if (conteudoArquivo != null) {

                foreach (var livro in livros) {
                    conteudoArquivo = conteudoArquivo.Replace("#NOVO-ITEM#", $"<li>{livro.Titulo} - {livro.Autor}</li>#NOVO-ITEM#");
                }

                return conteudoArquivo.Replace("#NOVO-ITEM#", "");
            }

            return "Desculpe! Não foi possivel carregar a página.";
        }

        public static Task ParaLer(HttpContext context) {
            var _repo = new LivroRepositorioCSV();
            var html = CarregaLista(_repo.ParaLer.Livros);
            return context.Response.WriteAsync(html);
        }

        public static Task Lendo(HttpContext context) {
            var _repo = new LivroRepositorioCSV();
            var html = CarregaLista(_repo.Lendo.Livros);
            return context.Response.WriteAsync(html);
        }

        public static Task Lidos(HttpContext context) {
            var _repo = new LivroRepositorioCSV();
            var html = CarregaLista(_repo.Lidos.Livros);
            return context.Response.WriteAsync(html);
        }

        public static Task Detalhes(HttpContext context) {

            int id = Convert.ToInt32(context.GetRouteValue("id"));
            var repo = new LivroRepositorioCSV();
            var livro = repo.Todos.First(l => l.Id == id);

            return context.Response.WriteAsync(livro.Detalhes());
        }

        public static Task Teste(HttpContext context) {
            return context.Response.WriteAsync("Nova funcionalidade implementada!");
        }
    }
}
