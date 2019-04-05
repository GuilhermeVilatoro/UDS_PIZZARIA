using AutoMapper;
using Pizzaria.Application.ViewModels;
using Pizzaria.Domain.Business.Dto;
using Pizzaria.Domain.Business.Enums;
using Pizzaria.Domain.Models;
using Pizzaria.Domain.Repository.Interfaces;

namespace Pizzaria.Application.Services
{
    public class PedidosService : IPedidosService
    {
        

            public void IniciarPedido(DadosIniciaisPedidoDto dadosIniciaisPedido)
            {
                throw new System.NotImplementedException();
            }

            public void PersonalizarPedido(AdicionaisPizzaViewModel adicionalPizza)
            {
                
            }

            public PedidoViewModel FinalizarPedido(long idPedido)
            {
                throw new System.NotImplementedException();
            }
        
    }
}