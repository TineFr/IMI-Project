using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Vue.Controllers
{
    public class CagesController : Controller
    {
        [Route("/cages")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
