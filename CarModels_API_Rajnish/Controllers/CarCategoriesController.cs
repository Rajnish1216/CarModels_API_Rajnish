using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CarModels_API_Rajnish.Controllers
{
    public class CarCategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
