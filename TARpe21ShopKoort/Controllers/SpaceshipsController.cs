using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TARpe21ShopRisto.Models;
using TARpe21ShopRisto.Data;

namespace TARpe21ShopRisto.Controllers
{
    public class SpaceshipsController : Controller
    {
        private readonly TARpe21ShopRistoContext _context;

        public SpaceshipsController(TARpe21ShopRistoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var result = _context.spaceships
                .OrderBy(X => X.CreatedAt)
                .Select(X => new SpaceshipIndexViewModel
                {
                    Id = X.Id,
                    Name = X.Name,
                    Type = X.Type,
                    PassengerCount = X.PassengerCount,
                    EnginePower = X.EnginePower,

                });
            return View(result);
            }
    }
}
