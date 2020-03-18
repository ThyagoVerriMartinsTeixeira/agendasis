using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaSis.Infra.Filtros
{
    public class JsonExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var erroValidacao = context.Exception.Message.StartsWith("Ocorreu os seguintes erros:");
            var result = new ObjectResult(new
            {
                code = erroValidacao ? 400 : 500,
                message = context.Exception.Message,
                details = context.Exception?.InnerException?.Message
            })
            {

                StatusCode = erroValidacao ? 400 : 500
            };
            context.Result = result;
        }
    }
}
