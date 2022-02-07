using System.Text.Json.Serialization;
using ShipManagementApi.Helpers;
using ShipManagementApi.DAL;

namespace ShipManagementApi
{
    public class Startup
    {
        // add services to the DI container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>();
            services.AddCors();
            services.AddControllers().AddJsonOptions(x =>
            {
                // ignore omitted parameters on models to enable optional params (e.g. Ship update)
                x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // configure DI for application 
            services.AddTransient<IRepository, Repository<DataContext>>();
        }

        // configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            // global error handler
            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseEndpoints(x => x.MapControllers());
        }
    }
}