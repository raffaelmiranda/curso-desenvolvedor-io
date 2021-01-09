using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStore.WebApp.MVC.Controllers
{
    public abstract class ControllerBase: Controller
    {
        protected Guid ClienteId = Guid.Parse("9B4C02C0-7BFC-4BF0-BDE2-1B8E6638D8A6");
    }
}
