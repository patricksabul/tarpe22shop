using Microsoft.AspNetCore.Mvc;
using TARpe22ShopVaitmaa.Core.ServiceInterface;

namespace TARpe22ShopVaitmaa.Controllers
{
    public class RealEstatesController : Controller
    {
        private readonly IRealEstatesServices _realEstatesServices;
        public RealEstatesController(IRealEstatesServices realEstatesServices)
        {
            _realEstatesServices = realEstatesServices;
        }
        public IActionResult Index()
        {
            var vm = new RealEstateIndexViewModel();
            return View(vm);
        }
    }
}
