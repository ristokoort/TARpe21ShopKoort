using Microsoft.AspNetCore.Mvc;

namespace TARpe21ShopRisto.Controllers
{
    public class WeatherForecastsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
