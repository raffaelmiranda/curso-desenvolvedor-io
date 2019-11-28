using DevIO.Api.Controllers;
using DevIO.Business.Interfaces;
using Elmah.Io.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace DevIO.Api.V2.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/teste")]
    public class TesteController : MainController
    {
        private readonly ILogger _logger;

        public TesteController(INotificador notificador, IUser appUser, ILogger<TesteController> logger) : base(notificador, appUser)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Valor()
        {
            try
            {
                var i = 0;
                var result = 42 / i;
            }
            catch (DivideByZeroException e)
            {
                e.Ship(HttpContext);
            }

            //throw new Exception("Error");

            //_logger.LogTrace("Log de Trace");
            //_logger.LogDebug("Log de Debug");
            //_logger.LogInformation("Log de Informação");
            //_logger.LogWarning("Log de Aviso");
            //_logger.LogError("Log de Erro");
            //_logger.LogCritical("Log de Problema Critico");

            return "Sou a V2";
        }
    }
}