using SistemaFacturacionApi.Core.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaFacturacionApi.Model.Entities
{
    public class Customer : BaseEntity
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public int LastName { get; set; }
        public string SecondLastName { get; set; }
        public int Direction { get; set; }
        public int Telephone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
