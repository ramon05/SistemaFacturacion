﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaFacturacionApi.BI.Dtos;
using SistemaFacturacionApi.Model.Entities;
using SistemaFacturacionApi.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaFacturacionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<User, UserDto>
    {
        public UserController(IUserService service) : base(service)
        {
        }
    }
}