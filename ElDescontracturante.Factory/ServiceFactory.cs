using ElDescontracturante.AccesoADatos;
using ElDescontracturante.AccesoADatos.Repositorios;
using ElDescontracturante.InterfazAccesoADatos;
using ElDescontracturante.InterfazLogicaDominio;
using ElDescontracturante.LogicaDominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Factory
{
    public class ServiceFactory
    {
        private readonly IServiceCollection services;

        public ServiceFactory(IServiceCollection services)
        {
            this.services = services;
        }

        public void AddCustomServices()
        {
            services.AddScoped<IAudioRepositorio, AudioRepositorio>();
            services.AddScoped<ILogicaAudio, LogicaAudio>();

        }

        public void AddDbContextService()
        {
            services.AddDbContext<DbContext, ElDescontracturanteContext>();
        }
    }
}