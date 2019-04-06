using AutoMapper;
using Pizzaria.Application.ViewModels;
using Pizzaria.Domain.Business.Dto;
using Pizzaria.Domain.Business.Interfaces;

namespace Pizzaria.Application.Services
{
    public class PedidosService : IPedidosService
    {
        private readonly IMontagemPedidoBusiness _montagemPedidoBusiness;
        private readonly IPersonalizacaoPedidoBusiness _personalizacaoPedidoBusiness;
        private readonly IResumoPedidoBusiness _resumoPedidoBusiness;
        private readonly IFinalizaPedidoBusiness _finalizaPedidoBusiness;

        private readonly IMapper _mapper;

        public PedidosService(IMontagemPedidoBusiness montagemPedidoBusiness,
            IPersonalizacaoPedidoBusiness personalizacaoPedidoBusiness,
            IResumoPedidoBusiness resumoPedidoBusiness,
            IFinalizaPedidoBusiness finalizaPedidoBusiness,
            IMapper mapper)
        {           
            _montagemPedidoBusiness = montagemPedidoBusiness;
            _personalizacaoPedidoBusiness = personalizacaoPedidoBusiness;
            _resumoPedidoBusiness = resumoPedidoBusiness;
            _finalizaPedidoBusiness = finalizaPedidoBusiness;
            _mapper = mapper;
        }

        public PedidoViewModel MontarPedido(MontagemPedidoViewModel montagemPedido)
        {
            var montagemPedidoDto = _mapper.Map<MontagemPedidoDto>(montagemPedido);

            var pedido = _montagemPedidoBusiness.MontarPedido(montagemPedidoDto);

            return _mapper.Map<PedidoViewModel>(pedido);
        }

        public PedidoViewModel PersonalizarPedido(PersonalizacaoPedidoViewModel personalizacaoPedido)
        {
            var personalizacaoPedidoDto = _mapper.Map<PersonalizacaoPedidoDto>(personalizacaoPedido);

            var pedido = _personalizacaoPedidoBusiness.PersonalizarPedido(personalizacaoPedidoDto);

            return _mapper.Map<PedidoViewModel>(pedido);
        }

        public PedidoViewModel ExibirPedido(int identificadorPedido)
        {
            var pedido = _resumoPedidoBusiness.ExibirPedido(identificadorPedido);
            return _mapper.Map<PedidoViewModel>(pedido);
        }

        public void FinalizarPedido(int identificadorPedido)
        {
            _finalizaPedidoBusiness.Finalizar(identificadorPedido);
        }
    }
}