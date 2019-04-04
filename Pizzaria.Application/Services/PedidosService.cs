using AutoMapper;
using Pizzaria.Application.ViewModels;
using Pizzaria.Domain.Models;
using Pizzaria.Domain.Repository.Interfaces;

namespace Pizzaria.Application.Services
{
    public class PedidosService : ServiceBase<PedidoViewModel, Pedidos>, IPedidosService
    {
        public PedidosService(IMapper mapper, IRepositoryBase<Pedidos> repository) : base(mapper, repository)
        {
        }
    }
}