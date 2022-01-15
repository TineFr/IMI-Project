using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Vue.Controllers
{
    public class FactsController : Controller
    {
        [Route("/facts")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
