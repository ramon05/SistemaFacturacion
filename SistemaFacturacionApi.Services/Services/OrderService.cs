using AutoMapper;
using FluentValidation;
using SistemaFacturacionApi.BI.Dtos;
using SistemaFacturacionApi.Model.Entities;
using SistemaFacturacionApi.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaFacturacionApi.Services.Services
{
    public interface IOrderService : IBaseService<Order, OrderDto> { }
   
    public class OrderService : BaseService<Order, OrderDto>, IOrderService
    {
        public OrderService(
            IOrderRepository repository, 
            IMapper mapper, 
            IValidator<OrderDto> validator) : base(repository, mapper, validator)
        {

        }
    }
}
