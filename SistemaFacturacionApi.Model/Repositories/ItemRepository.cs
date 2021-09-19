using SistemaFacturacionApi.Model.Context;
using SistemaFacturacionApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaFacturacionApi.Model.Repositories
{
    public interface IItemRepository : IBaseRepository<Item> { }
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        public ItemRepository(SistemaFacturacionDbContext context) : base(context)
        {
        }
    }
}
