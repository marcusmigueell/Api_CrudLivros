using Api.Net_Core.Negocio;
using Api.Net_Core.Repositorio;

namespace Api.Net_Core {

    public class Program {

        static void Main(string[] args) {

            var _repo = new LivroRepositorioCSV();

            IWebHost host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();
            host.Run();

            //ImprimeLista(_repo.ParaLer);
            //ImprimeLista(_repo.Lendo);
            //ImprimeLista(_repo.Lidos);
        }

        static void ImprimeLista(ListaDeLeitura lista) {
            Console.WriteLine(lista);
        }
    }
}
