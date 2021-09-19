using SistemaFacturacionApi.Core.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaFacturacionApi.BI.Dtos
{
    public class CustomerDto : BaseEntityDto
    {
        public string Name { get; set; }
        public int LastName { get; set; }
        public int Direction { get; set; }
        public int Telephone { get; set; }
    }
}
