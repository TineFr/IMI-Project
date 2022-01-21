using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Vue.Controllers
{
    public class MedicinesController : Controller
    {
        [Route("/medicines")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
