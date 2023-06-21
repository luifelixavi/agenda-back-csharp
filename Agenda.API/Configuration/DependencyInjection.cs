

using Agenda.API.Data.Repositorie;
using Agenda.API.Domain.Interface;
using Agenda.API.Domain.Model;

namespace Agenda.API.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IServicoRepositorie, ServicoRepositorie>();
            services.AddScoped<IEspecialidadeRepositorie, EspecialidadeRepositorie>();
            services.AddScoped<ICadastroRepositorie, CadastroRepositorie>();
            services.AddSingleton<BaseModel>();

            return services;
        }
    }
}
