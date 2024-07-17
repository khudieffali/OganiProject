using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ogani.Areas.OganiAdmin.Controllers
{
    [Area(nameof(OganiAdmin))]
    public class DashboardController : Controller
    {
        // GET: DashboardController
        public IActionResult Index()
        {
            return View();
        }
    }
}
