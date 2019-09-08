using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevIO.UI.Site.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.UI.Site.Controllers
{  
    public class LifeCycleDIController : Controller
    {
        public OperacaoServices OperacaoService { get; }
        public OperacaoServices OperacaoService2 { get; }

        public LifeCycleDIController(OperacaoServices operacaoServices, OperacaoServices operacaoServices2)
        {
            OperacaoService = operacaoServices;
            OperacaoService2 = operacaoServices2;
        }
        public string Index()
        {
            return
                $"Primeira instância{ Environment.NewLine}" +
                $"Transient :{OperacaoService.Transient.OperacaoId}{Environment.NewLine}" +
                $"Scoped :{OperacaoService.Scoped.OperacaoId}{Environment.NewLine}" +
                $"Singleton :{OperacaoService.Singleton.OperacaoId}{Environment.NewLine}" +
                $"SingletonInstance :{OperacaoService.SingletonInstance.OperacaoId}{Environment.NewLine}" +

                $"{ Environment.NewLine}" +
                $"{ Environment.NewLine}" +

                $"Segunda instância{Environment.NewLine}" +
                $"Transient :{OperacaoService2.Transient.OperacaoId}{Environment.NewLine}" +
                $"Scoped :{OperacaoService2.Scoped.OperacaoId}{Environment.NewLine}" +
                $"Singleton :{OperacaoService2.Singleton.OperacaoId}{Environment.NewLine}" +
                $"SingletonInstance :{OperacaoService2.SingletonInstance.OperacaoId}{Environment.NewLine}";
        }
    }
}