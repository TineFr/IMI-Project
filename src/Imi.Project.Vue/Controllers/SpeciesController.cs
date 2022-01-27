using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Vue.Controllers
{
    public class SpeciesController : Controller
    {
        [Route("/species")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
