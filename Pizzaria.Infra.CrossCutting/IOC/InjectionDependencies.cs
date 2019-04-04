using Microsoft.Extensions.DependencyInjection;

namespace Pizzaria.Infra.CrossCutting.IOC
{
    public static class InjectionDependencies
    {
        /// <summary>
        /// Responsável por realizar o registro das dependências.
        /// </summary>
        /// <param name="dependencies">Lista a qual será adicionada as dependências</param>
        public static void RegisterDependencies(IServiceCollection dependencies)
        {     
            //dependencies.AddScoped<IPedidoAppService, LivroPedidoService>();
        }
    }
}