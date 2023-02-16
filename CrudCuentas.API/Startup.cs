using CrudCuentas.BLL.Interfaces;
using CrudCuentas.BLL.Services;
using CrudCuentas.DAL.Utilities;
using CrudCuentas.Repositories.DataContext;
using CrudCuentas.Repositories.Interfaces;
using CrudCuentas.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CrudCuentas.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.

            services.AddControllers();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();

            services.AddScoped<ICuentaRepository, CuentaRepository>();
            services.AddScoped<ICuentaService, CuentaService>();

            services.AddScoped<ITipoCuentaRepository, TipoCuentaRepository>();
            //services.AddScoped<ITipoCuentaService, TipoCuentaService>();

            services.AddScoped<IEstadoCuentaRepository, EstadoCuentaRepository>();
            services.AddScoped<IEstadoCuentaService, EstadoCuentaService>();

            services.AddScoped<ITransaccionRepository, TransaccionRepository>();
            services.AddScoped<ITransaccionService, TransaccionService>();


            services.AddScoped<ITipoTransaccionRepository, TipoTransaccionRepository>();
            services.AddScoped<ITipoTransaccionService, TipoTransaccionService>();



            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();


            services.AddSwaggerGen();

            //services.AddAutoMapper(typeof(Startup));
            services.AddAutoMapper(typeof(AutoMapperProfiles));

            //services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDBContext>().AddDefaultTokenProviders();


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            //app.UseHttpsRedirection();

            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseHttpsRedirection();



            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
