using Microsoft.AspNetCore.Mvc;

namespace Schedule.Web.UI.Controllers
{
    public class SchedulerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
