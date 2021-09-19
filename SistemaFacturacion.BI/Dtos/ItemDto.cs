using SistemaFacturacionApi.Core.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaFacturacionApi.BI.Dtos
{
    public class ItemDto : BaseEntityDto
    {
        public int Quantity { get; set; }
        public float Price { get; set; }
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
