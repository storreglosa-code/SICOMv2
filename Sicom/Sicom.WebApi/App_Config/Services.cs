using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Sicom.Dominio.Context;
using Sicom.Dominio.Contracts;
using Sicom.Dominio.Entidades;
using Sicom.Dominio.Implementation;
using Sicom.Servicio.Contracts;
using Sicom.Servicio.Implementation;


namespace Sicom.WebApi.App_Config
{
    public static class Services
    {
        public static void BindServices(this IServiceCollection services)
        {
            //Servicios
            services.AddScoped(typeof(IServicio<>), typeof(Servicio<>));
            services.AddScoped<IEstablecimientoServicio, EstablecimientoServicio>();
            services.AddScoped<IModeloCelularServicio, ModeloCelularServicio>();
            services.AddScoped<IObservacionServicio, ObservacionServicio>();
            services.AddScoped<ILineaAdministrativaServicio, LineaAdministrativaServicio>();

            //Repositorios
            services.AddScoped(typeof(IRepositorio<>), typeof(Repositorio<>));

            //Contexto
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

    }
}
