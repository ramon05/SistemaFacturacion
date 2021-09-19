﻿using FluentValidation.Results;
using SistemaFacturacionApi.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaFacturacionApi.BI.Extensions
{
    public static class EntityOperationResultExtensions
    {
        public static IEntityOperationResult<TDto> ToOperationResult<TDto>(this TDto dto)
        {
            return new EntityOperationResult<TDto>(dto);
        }

        public static IEntityOperationResult<TDto> ToOperationResult<TDto>(this ValidationResult validationResult)
        {
            return new EntityOperationResult<TDto>
            {
                Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
            };
        }
    }
}
