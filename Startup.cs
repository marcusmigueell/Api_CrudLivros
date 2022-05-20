namespace Api.Net_Core {

    public class Startup {

        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app) {
            app.UseMvcWithDefaultRoute();
        }
    }
}
