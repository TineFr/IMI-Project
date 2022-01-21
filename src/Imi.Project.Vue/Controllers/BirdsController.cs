using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Vue.Controllers
{
    public class BirdsController : Controller
    {
        [Route("/birds")]
        public IActionResult Index()
        {
            return View();
        }


    }
}
