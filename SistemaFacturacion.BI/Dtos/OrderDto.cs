using SistemaFacturacionApi.Core.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaFacturacionApi.BI.Dtos
{
    public class OrderDto : BaseEntityDto
    {
        public string NumberOrder { get; set; }
        public DateTime DateOrder { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
    }
}
