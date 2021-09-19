using SistemaFacturacionApi.Model.Context;
using SistemaFacturacionApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaFacturacionApi.Model.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer> { }
    class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(SistemaFacturacionDbContext context) : base(context)
        {
        }
    }
}
