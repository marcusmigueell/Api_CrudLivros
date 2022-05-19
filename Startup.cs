using Api.Net_Core.Mvc;

namespace Api.Net_Core {

    public class Startup {

        public void ConfigureServices(IServiceCollection services) {
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app) {

            var builder = new RouteBuilder(app);
            builder.MapRoute("{classe}/{metodo}", RoteamentoPadrao.TratamentoPadrao);

            var rotas = builder.Build();

            app.UseRouter(rotas);
        }
    }
}
