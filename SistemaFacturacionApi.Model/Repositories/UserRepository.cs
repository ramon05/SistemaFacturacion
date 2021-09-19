using SistemaFacturacionApi.Model.Context;
using SistemaFacturacionApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaFacturacionApi.Model.Repositories
{
    public interface IUserRepository : IBaseRepository<User> { }
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(SistemaFacturacionDbContext context) : base(context)
        {
        }
    }
}
