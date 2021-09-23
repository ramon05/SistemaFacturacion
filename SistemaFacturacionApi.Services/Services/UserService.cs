using BC = BCrypt.Net.BCrypt;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SistemaFacturacionApi.BI.Dtos;
using SistemaFacturacionApi.Core.Abstract;
using SistemaFacturacionApi.Core.Settings;
using SistemaFacturacionApi.Model.Entities;
using SistemaFacturacionApi.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using SistemaFacturacionApi.BI.Extensions;

namespace SistemaFacturacionApi.Services.Services
{
    public interface IUserService : IBaseService<User, UserDto> {
        Task<AuthenticateResponseDto> GetToken(AuthenticateRequestDto model);
        Task<IEntityOperationResult<UserDto>> ChangePassword(int userId, ChangePasswordDto model);
    }
   
    public class UserService : BaseService<User, UserDto>, IUserService
    {
        private readonly JwtSettings _jwtSettings;
        public UserService(
            IUserRepository repository, 
            IMapper mapper, 
            IValidator<UserDto> validator,
            IOptions<JwtSettings> jwtSettings) : base(repository, mapper, validator)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<AuthenticateResponseDto> GetToken(AuthenticateRequestDto model)
        {
            var user = await _repository.Query().
                Where(x => x.UserName == model.Username)
                .Select(x => new { x.Id, x.UserName, x.Name, x.LastName, x.Password})
                .FirstOrDefaultAsync();

            if (user is null)
                return null;

            var isValidPassword = ValidatePassword(user.Password, model.Password);
            if (!isValidPassword)
                return null;

            var response = new AuthenticateResponseDto
            {
                Id = user.Id,
                Username = user.UserName,
                FirstName = user.Name,
                LastName = user.LastName
            };

            response.Token = GerateJwtToken(response);
            return response;
        }

        private string GerateJwtToken(AuthenticateResponseDto user)
        {
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var symmetricSecurityKey = new SymmetricSecurityKey(key);

            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            var claimsIdentity = new ClaimsIdentity(new[] {
                new Claim("id", user.Id.ToString()),
                new Claim("username",user.Username)
            });

            var claims = new Dictionary<string, object>
            {
                { "name", user.FirstName },
                { "lastName", user.LastName },
            };

            var description = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Claims = claims,
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiresInMinutes),
                SigningCredentials = signingCredentials
            };

            var handler = new JwtSecurityTokenHandler();

            var securityToken = handler.CreateToken(description);

            var token = handler.WriteToken(securityToken);

            return token;
        }

        public override async Task<IEntityOperationResult<UserDto>> AddAsync(UserDto dto)
        {
            var validationResult = _validator.Validate(dto);
            if (validationResult.IsValid is false)
                return validationResult.ToOperationResult<UserDto>();

            var entity = _mapper.Map<User>(dto);
            entity.Password = EncodePassword(dto.Password);

            var entityResult = await _repository.Add(entity);

            _mapper.Map(entityResult, dto);

            var result = dto.ToOperationResult();
            return result;
        }

        public async Task<IEntityOperationResult<UserDto>> ChangePassword(int userId, ChangePasswordDto model)
        {
            var user = await _repository.Get(userId);

            if (user is null)
                return new EntityOperationResult<UserDto>
                {
                    Errors = new List<string>()
                    {
                        "User not fount"
                    }
                };

            var valid = model.Password.Equals(model.ConfirmPassword);

            if (!valid)
                return new EntityOperationResult<UserDto>
                {
                    Errors = new List<string>()
                    {
                        "Password is not match"
                    }
                };

            user.Password = EncodePassword(model.Password);
            await _repository.Update(user);

            return new EntityOperationResult<UserDto>();
        }

        private bool ValidatePassword(string passwordHash, string password)
        {
            bool verified = BC.Verify(password, passwordHash);

            return verified;
        }

        private string EncodePassword(string Password)
        {
            var PasswordHash = BC.HashPassword(Password);

            return PasswordHash;
        }
    }
}
