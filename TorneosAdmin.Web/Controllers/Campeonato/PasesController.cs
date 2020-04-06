using Microsoft.AspNetCore.Mvc;

namespace TorneosAdmin.Web.Controllers
{
    public class PasesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}