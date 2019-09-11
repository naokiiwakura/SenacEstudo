using Domain.Aplication;
using Domain.Infra;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Service;
using System;

namespace CrossCutting
{
    public class ProjetoInjector
    {
        public static void RegistrarServicos(IServiceCollection services)
        {
            //Repositories
            services.AddScoped<IFamiliaRepository, FamiliaRepository>();

            //Services
            services.AddScoped<IFamiliaService, FamiliaService>();
        }
    }
}
