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
    public interface IItemService : IBaseService<Item, ItemDto> { }
    public class ItemService : BaseService<Item, ItemDto>, IItemService
    {
        public ItemService(
            IItemRepository repository,
            IMapper mapper,
            IValidator<ItemDto> validator) : base(repository, mapper, validator)
        {

        }
    }
}
