using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Vue.Controllers
{
    public class PrescriptionsController : Controller
    {
        [Route("/prescriptions")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
