﻿using HairManager.Comunication.Responses;
using HairManager.Exceptions.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace HairManager.Api.Filtros;

public class FiltroDasExceptions : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is HairManagerException)
        {
            TratarHairManagerException(context);
        }
        else
        {
            LancarErroDesconhecido(context);
        }
    }

    private static void TratarHairManagerException(ExceptionContext context)
    {
        if (context.Exception is ErrosDeValidacaoException)
            TratarErrosValidacaoException(context);
    }

    private static void TratarErrosValidacaoException(ExceptionContext context)
    {
        var erroDeValidacaoException = context.Exception as ErrosDeValidacaoException;

        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.Result = new ObjectResult(new ResponseErroDTO(erroDeValidacaoException.MensagensDeErro));
    }

    private static void LancarErroDesconhecido(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(new ResponseErroDTO(ResourceMensagensDeErro.ERRO_DESCONHECIDO));
    }
}