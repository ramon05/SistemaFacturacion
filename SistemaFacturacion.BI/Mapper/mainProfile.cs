using AutoMapper;
using SistemaFacturacionApi.BI.Dtos;
using SistemaFacturacionApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaFacturacionApi.BI.Mapper
{
    public class mainProfile : Profile
    {
        public mainProfile()
        {
            #region Customer

            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();

            #endregion

            #region Item    

            CreateMap<Item, ItemDto>();
            CreateMap<ItemDto, Item>();

            #endregion

            #region Order

            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();

            #endregion

            #region User

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            #endregion

            #region Product

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            #endregion

        }
    }
}
