using SistemaFacturacionApi.Core.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaFacturacionApi.Model.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
            Items = new HashSet<Item>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }

        public virtual ICollection<Item> Items { get; set; }

    }
}
