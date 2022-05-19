namespace Api.Net_Core {

    public class Program {

        static void Main(string[] args) {

            IWebHost host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();
            host.Run();
        }
    }
}
