using AutoMapper;
using FluentValidation;
using SistemaFacturacionApi.BI.Dtos;
using SistemaFacturacionApi.Model.Entities;
using SistemaFacturacionApi.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaFacturacionApi.Services.Services
{
    public interface ICustomerService : IBaseService<Customer, CustomerDto> { }
   
    public class CustomerService : BaseService<Customer, CustomerDto>, ICustomerService
    {
        public CustomerService(
            CustomerRepository repository, 
            IMapper mapper, 
            IValidator<CustomerDto> validator) : base(repository, mapper, validator)
        {

        }
    }
}
