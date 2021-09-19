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
    public interface IProductService : IBaseService<Product, ProductDto> { }
    public class ProductService : BaseService<Product, ProductDto>, IProductService
    {
        public ProductService(
            IProductRepository repository,
            IMapper mapper,
            IValidator<ProductDto> validator) : base(repository, mapper, validator)
        {
        }
    }
}
