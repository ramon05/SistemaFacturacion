using SistemaFacturacionApi.Core.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaFacturacionApi.BI.Dtos
{
    public class ProductDto : BaseEntityDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
    }
}
