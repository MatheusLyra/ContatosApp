using ContatosApp.Domain.Interfaces.Repositories;
using ContatosApp.Domain.Interfaces.Services;
using ContatosApp.Domain.Services;
using ContatosApp.Infra.Data.Repositories;

namespace ContatosApp.Presentation
{
    /// <summary>
    /// Classe para configurar as injeções de dependência do projeto
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Método para configurar as injeções de dependência do sistema
        /// </summary>
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();
            services.AddTransient<IUsuarioRepository   , UsuarioRepositoryDapper>();

            services.AddTransient<IContatoDomainService, ContatoDomainService>();
            services.AddTransient<IContatoRepository   , ContatoRepositoryDapper>();
        }
    }
}
