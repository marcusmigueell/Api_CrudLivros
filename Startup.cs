using Api.Net_Core.Negocio;
using Api.Net_Core.Repositorio;

namespace Api.Net_Core {

    public class Startup {

        public void ConfigureServices(IServiceCollection services) {
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app) {

            var builder = new RouteBuilder(app);

            builder.MapRoute("Livros/ParaLer", LivrosParaLer);
            builder.MapRoute("Livros/Lendo", LendoLivros);
            builder.MapRoute("Livros/Lidos", LivrosLidos);
            builder.MapRoute("Cadastro/NovoLivro/{nome}/{autor}", NovoLivroParaLer);
            builder.MapRoute("Livros/Detalhes/{id:int}", ExibeDetalhes);
            builder.MapRoute("Cadastro/NovoLivro", ExibeFormulario);
            builder.MapRoute("Cadastro/Incluir", ProcessaFormulario);

            var rotas = builder.Build();

            app.UseRouter(rotas);
        }

        private Task ProcessaFormulario(HttpContext context) {

            var livro = new Livro() {
                Titulo = context.Request.Form["titulo"].First(),
                Autor = context.Request.Form["autor"].First()
            };

            var repo = new LivroRepositorioCSV();
            repo.Incluir(livro);

            return context.Response.WriteAsync("O livro foi adicionado com sucesso!");
        }

        private Task ExibeFormulario(HttpContext context) {
            
            var html = CarregaArquivoHTML("formulario");
            var HtmlString = Convert.ToString(html);

            if(HtmlString != null)
                return context.Response.WriteAsync(HtmlString);

            return context.Response.WriteAsync("Desculpe! Não foi possivel carregar a página.");
        }

        private object CarregaArquivoHTML(string nomeArquivo)  {

            var nomeCompletoArquivo = $"Html/{nomeArquivo}.html";
            using (var arquivo = File.OpenText(nomeCompletoArquivo)) {
                return arquivo.ReadToEnd();
            }
        }

        private Task ExibeDetalhes(HttpContext context) {

            int id = Convert.ToInt32(context.GetRouteValue("id"));
            var repo = new LivroRepositorioCSV();
            var livro = repo.Todos.First(l => l.Id == id);

            return context.Response.WriteAsync(livro.Detalhes());
        }

        public Task NovoLivroParaLer(HttpContext context) {

            var livro = new Livro()
            {
                Titulo = Convert.ToString(context.GetRouteValue("nome")),
                Autor = Convert.ToString(context.GetRouteValue("autor")),
            };

            var repo = new LivroRepositorioCSV();
            repo.Incluir(livro);

            return context.Response.WriteAsync("O livro foi adicionado com sucesso!");

        }

        public Task Roteamento(HttpContext context) {

            var _repo = new LivroRepositorioCSV();
            var caminhosAtendidos = new Dictionary<string, RequestDelegate> {
                { "/Livros/ParaLer", LivrosParaLer },
                { "/Livros/Lendo", LendoLivros },
                { "/Livros/Lidos", LivrosLidos }
            };

            if (caminhosAtendidos.ContainsKey(context.Request.Path)) {
                var metodo = caminhosAtendidos[context.Request.Path];
                return metodo.Invoke(context);
            }

            context.Response.StatusCode = 404;
            return context.Response.WriteAsync("Caminho inexistente!");

        }

        public Task LivrosParaLer(HttpContext context) {

            var _repo = new LivroRepositorioCSV();

            var conteudoArquivo = CarregaArquivoHTML("para-ler");

            var conteudoString = Convert.ToString(conteudoArquivo);

            if (conteudoString != null) {

                foreach (var livro in _repo.ParaLer.Livros) {
                    conteudoString = conteudoString.Replace("#NOVO-ITEM#", $"<li>{livro.Titulo} - {livro.Autor}</li>#NOVO-ITEM#");
                }

                conteudoString = conteudoString.Replace("#NOVO-ITEM#", " ");

                return context.Response.WriteAsync(conteudoString);
            }

            return context.Response.WriteAsync("Desculpe! Não foi possivel carregar a página.");
        }

        public Task LendoLivros(HttpContext context) {
            var _repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_repo.Lendo.ToString());
        }

        public Task LivrosLidos(HttpContext context) {
            var _repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_repo.Lidos.ToString());
        }
    }
}
