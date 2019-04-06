using Microsoft.Extensions.DependencyInjection;
using Pizzaria.Application.Services;
using Pizzaria.Application.Services.Interfaces;
using Pizzaria.Domain.Business;
using Pizzaria.Domain.Business.Interfaces;
using Pizzaria.Domain.Repository.Interfaces;
using Pizzaria.Infra.Data.Context;

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
            #region Repository            
            dependencies.AddScoped<IAdicionaisPizzaRepository, AdicionaisPizzaRepository>();
            dependencies.AddScoped<IPedidoRepository, PedidoRepository>();
            dependencies.AddScoped<ISaboresPizzaRepository, SaboresPizzaRepository>();
            dependencies.AddScoped<ITamanhosPizzaRepository, TamanhosPizzaRepository>();
            dependencies.AddScoped<PizzariaContext>();
            #endregion

            #region Services 
            dependencies.AddScoped<IPedidosService, PedidosService>();
            dependencies.AddScoped<ISaboresPizzaService, SaboresPizzaService>();
            dependencies.AddScoped<ITamanhosPizzaService, TamanhosPizzaService>();
            dependencies.AddScoped<IAdicionaisPizzaService, AdicionaisPizzaService>();
            #endregion region

            #region Business 
            dependencies.AddScoped<IMontagemPedidoBusiness, MontagemPedidoBusiness>();
            dependencies.AddScoped<IPersonalizacaoPedidoBusiness, PersonalizacaoPedidoBusiness>();
            dependencies.AddScoped<IResumoPedidoBusiness, ResumoPedidoBusiness>();
            dependencies.AddScoped<IFinalizaPedidoBusiness, FinalizaPedidoBusiness>();
            #endregion region
        }
    }
}