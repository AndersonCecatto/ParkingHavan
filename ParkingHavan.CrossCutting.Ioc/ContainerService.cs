using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ParkingHavan.Data.Common;
using ParkingHavan.Data.Interfaces.Common;
using ParkingHavan.Data.Interfaces.Repositories;
using ParkingHavan.Data.Repositories;
using ParkingHavan.Data.Repositories.Common;
using ParkingHavan.Domain.Models;
using ParkingHavan.Service.Interfaces;
using ParkingHavan.Service.Services;

namespace ParkingHavan.CrossCutting.Ioc
{
    public static class ContainerService
    {
        public static IServiceCollection AddApplicationServicesCollentions(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddServices();
            services.AddRepositories();

            return services;
        }

        public static IServiceCollection AddApplicationContext(this IServiceCollection services, string connnectionString)
        {
            services.AddDbContext<ParkingContext>(options => options.UseSqlServer(connnectionString));
            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IEstacionamentoRepository, EstacionamentoRepository>();
            services.AddScoped<ITabelaPrecoPeriodoVigenciaRepository, TabelaPrecoPeriodoVigenciaRepository>();
            services.AddScoped<ITabelaPrecoTipoPeriodoRepository, TabelaPrecoTipoPeriodoRepository>();
            services.AddScoped<ITabelaPrecoValoresRepository, TabelaPrecoValoresRepository>();
            services.AddScoped<IPeriodoVigenciaTipoPeriodoRepository, PeriodoVigenciaTipoPeriodoRepository>();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IClienteService<ClienteModel>, ClienteService>();
            services.AddScoped<IEstacionamentoService<EstacionamentoModel>, EstacionamentoService>();
            services.AddScoped<ITabelaPrecoPeriodoVigenciaService<TabelaPrecoPeriodoVigenciaModel>, TabelaPrecoPeriodoVigenciaService>();
            services.AddScoped<ITabelaPrecoTipoPeriodoService<TabelaPrecoTipoPeriodoModel>, TabelaPrecoTipoPeriodoService>();
            services.AddScoped<ITabelaPrecoValoresService<TabelaPrecoValoresModel>, TabelaPrecoValoresService>();

            return services;
        }
    }
}
