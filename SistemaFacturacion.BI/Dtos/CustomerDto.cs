using SistemaFacturacionApi.Core.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaFacturacionApi.BI.Dtos
{
    public class CustomerDto : BaseEntityDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Direction { get; set; }
        public string Telephone { get; set; }
    }
}
