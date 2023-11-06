using Microsoft.AspNetCore.Mvc;
using TARpe22ShopVaitmaa.Core.Dto;
using TARpe22ShopVaitmaa.Core.ServiceInterface;
using TARpe22ShopVaitmaa.Data;
using TARpe22ShopVaitmaa.Models.RealEstate;

namespace TARpe22ShopVaitmaa.Controllers
{
    public class RealEstatesController : Controller
    {
        private readonly IRealEstatesServices _realEstatesServices;
        private readonly TARpe22ShopVaitmaaContext _context;
        public RealEstatesController(IRealEstatesServices realEstatesServices, TARpe22ShopVaitmaaContext context)
        {
            _realEstatesServices = realEstatesServices;
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.RealEstates
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new RealEstateIndexViewModel
                {
                    //{ return (Country + ", " + County + ", " + City + ", " + Address); }
                    Id = x.Id,
                    Location = x.Country + ", " + x.County + ", " + x.City + ", " + x.Address,
                    SquareMeters = x.SquareMeters,
                    RoomCount = x.RoomCount,
                    Price = x.Price,
                    IsPropertySold = x.IsPropertySold,

                });
            return View(result);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            RealEstateCreateUpdateViewModel vm = new();
            return View("CreateUpdate", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(RealEstateCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto()
            {
                Id = Guid.NewGuid(),
                Type = vm.Type,
                ListingDescription = vm.ListingDescription,
                Address = vm.Address,
                County = vm.County,
                Country = vm.Country,
                City = vm.City,
                PostalCode = vm.PostalCode,
                ContactPhone = vm.ContactPhone,
                ContactFax = vm.ContactFax,
                SquareMeters = vm.SquareMeters,
                Floor = vm.Floor,   
                FloorCount = vm.FloorCount,
                Price = vm.Price,
                RoomCount = vm.RoomCount,
                BedroomCount = vm.BedroomCount,
                BathroomCount = vm.BathroomCount,
                WhenEstateListedAt = vm.WhenEstateListedAt,
                IsPropertySold = vm.IsPropertySold,
                DoesHaveSwimmingPool = vm.DoesHaveSwimmingPool,
                BuiltAt = vm.BuiltAt,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };
            var result = await _realEstatesServices.Create(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", vm);

        }
    }
}
