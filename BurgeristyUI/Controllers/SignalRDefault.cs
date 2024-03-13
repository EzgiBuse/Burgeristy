using Microsoft.AspNetCore.Mvc;

namespace BurgeristyUI.Controllers
{
    public class SignalRDefault : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
