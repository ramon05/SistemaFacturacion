using SistemaFacturacionApi.Core.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaFacturacionApi.Model.Entities
{
    public class Order : BaseEntity
    {
        public Order()
        {
            Items = new HashSet<Item>();
        }
        public string NumberOrder { get; set; }
        public DateTime DateOrder { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
