using Microsoft.AspNetCore.Mvc;

namespace iTransition.Forms.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
