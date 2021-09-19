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
    public interface IUserService : IBaseService<User, UserDto> { }
   
    public class UserService : BaseService<User, UserDto>, IUserService
    {
        public UserService(
            UserRepository repository, 
            IMapper mapper, 
            IValidator<UserDto> validator) : base(repository, mapper, validator)
        {

        }
    }
}
