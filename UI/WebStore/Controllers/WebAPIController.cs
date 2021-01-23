using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Interfaces.TestAPI;

namespace WebStore.Controllers
{
    public class WebAPIController : Controller
    {
        private readonly IValuesServices _ValueService;

        public WebAPIController(IValuesServices valuesServices) => _ValueService = valuesServices;

        public IActionResult Index()
        {
            var values = _ValueService.Get();

            return View(values); ;
        }
    }
}
