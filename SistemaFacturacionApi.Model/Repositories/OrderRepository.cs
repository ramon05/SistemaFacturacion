using SistemaFacturacionApi.Model.Context;
using SistemaFacturacionApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaFacturacionApi.Model.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order> { }
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(SistemaFacturacionDbContext context) : base(context)
        {
        }
    }
}
