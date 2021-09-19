using SistemaFacturacionApi.Model.Context;
using SistemaFacturacionApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaFacturacionApi.Model.Repositories
{
    public interface IProductRepository : IBaseRepository<Product> { }
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(SistemaFacturacionDbContext context) : base(context)
        {
        }
    }
}
