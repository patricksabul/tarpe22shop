using Microsoft.AspNetCore.Mvc;
using TARpe22ShopVaitmaa.Data;
using TARpe22ShopVaitmaa.Models.Spaceship;

namespace TARpe22ShopVaitmaa.Controllers
{
    public class SpaceshipsController : Controller
    {
        private readonly TARpe22ShopVaitmaaContext _context;
        public SpaceshipsController(TARpe22ShopVaitmaaContext context) { _context = context; }
        public IActionResult Index()
        {
            var result = _context.Spaceships
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new SpaceshipIndexViewModel { 
                    Id = x.Id, 
                    Name = x.Name, 
                    Type = x.Type, 
                    PassengerCount = x.PassengerCount, 
                    EnginePower = x.EnginePower });
            return View(result);
        }
        public IActionResult Add()
        {
            return View("Edit");
        }
    }
}
