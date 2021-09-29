using SistemaFacturacionApi.Core.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaFacturacionApi.BI.Dtos
{
    public class UserDto : BaseEntityDto
    {
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public int Direction { get; set; }
        public string Telephone { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Signature { get; set; }
        public string FullName { get; set; }
    }
}
