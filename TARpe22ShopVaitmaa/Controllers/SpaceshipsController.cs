using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TARpe22ShopVaitmaa.Core.Dto;
using TARpe22ShopVaitmaa.Core.ServiceInterface;
using TARpe22ShopVaitmaa.Data;
using TARpe22ShopVaitmaa.Models.Spaceship;

namespace TARpe22ShopVaitmaa.Controllers
{
    public class SpaceshipsController : Controller
    {
        private readonly TARpe22ShopVaitmaaContext _context;
        private readonly ISpaceshipsServices _spaceshipsServices;
        public SpaceshipsController
            (
                TARpe22ShopVaitmaaContext context,
                ISpaceshipsServices spaceshipsServices
            ) 
        { 
            _context = context; 
            _spaceshipsServices = spaceshipsServices;
        }
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
        [HttpGet]
        public IActionResult Create()
        {
            SpaceshipCreateUpdateViewModel spaceship = new SpaceshipCreateUpdateViewModel();
            return View("CreateUpdate", spaceship);
        }
        [HttpPost]
        public async Task<IActionResult> Create(SpaceshipCreateUpdateViewModel vm)
        {
            var dto = new SpaceshipDto()
            {
                Id = vm.Id,
                Price = vm.Price,
                Type = vm.Type,
                Name = vm.Name,
                Description = vm.Description,
                FuelType = vm.FuelType,
                FuelCapacity = vm.FuelCapacity,
                FuelConsumption = vm.FuelConsumption,
                PassengerCount = vm.PassengerCount,
                EnginePower = vm.EnginePower,
                DoesHaveAutopilot = vm.DoesHaveAutopilot,
                CrewCount = vm.CrewCount,
                CargoWeight = vm.CargoWeight,
                DoesHaveLifeSupportSystems = vm.DoesHaveLifeSupportSystems,
                BuiltDate = vm.BuiltDate,
                LastMaintenance = vm.LastMaintenance,
                MaintenanceCount = vm.MaintenanceCount,
                FullTripsCount = vm.FullTripsCount,
                MaidenLaunch = vm.MaidenLaunch,
                Manufacturer = vm.Manufacturer,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
                Files = vm.Files,
                Image = vm.Image.Select(x => new FileToDatabaseDto
                {
                    Id = x.ImageId,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    SpaceshipId = x.SpaceshipId,
                }).ToArray() 
            };
            var result = await _spaceshipsServices.Create(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var spaceship = await _spaceshipsServices.GetAsync(id);
            if (spaceship == null)
            {
                return NotFound();
            }
            var photos = await _context.FilesToDatabase
                .Where(x => x.SpaceshipId == id)
                .Select(y => new ImageViewModel
                {
                    SpaceshipId = y.Id,
                    ImageId = y.Id,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image.gif;base64,{0}", Convert.ToBase64String(y.ImageData))

                }). ToArrayAsync();
            var vm = new SpaceshipCreateUpdateViewModel();

            vm.Id = spaceship.Id;
            vm.Price = spaceship.Price;
            vm.Type = spaceship.Type;
            vm.Name = spaceship.Name;
            vm.Description = spaceship.Description;
            vm.FuelType = spaceship.FuelType;
            vm.FuelCapacity = spaceship.FuelCapacity;
            vm.FuelConsumption = spaceship.FuelConsumption;
            vm.PassengerCount = spaceship.PassengerCount;
            vm.EnginePower = spaceship.EnginePower;
            vm.DoesHaveAutopilot = spaceship.DoesHaveAutopilot;
            vm.CrewCount = spaceship.CrewCount;
            vm.CargoWeight = spaceship.CargoWeight;
            vm.DoesHaveLifeSupportSystems = spaceship.DoesHaveLifeSupportSystems;
            vm.BuiltDate = spaceship.BuiltDate;
            vm.LastMaintenance = spaceship.LastMaintenance;
            vm.MaintenanceCount = spaceship.MaintenanceCount;
            vm.FullTripsCount = spaceship.FullTripsCount;
            vm.MaidenLaunch = spaceship.MaidenLaunch;
            vm.Manufacturer = spaceship.Manufacturer;
            vm.CreatedAt = spaceship.CreatedAt;
            vm.ModifiedAt = spaceship.ModifiedAt;
            vm.Image.AddRange(photos);

            return View("CreateUpdate",vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(SpaceshipCreateUpdateViewModel vm)
        {
            var dto = new SpaceshipDto()
            {
                Id = vm.Id,
                Price = vm.Price,
                Type = vm.Type,
                Name = vm.Name,
                Description = vm.Description,
                FuelType = vm.FuelType,
                FuelCapacity = vm.FuelCapacity,
                FuelConsumption = vm.FuelConsumption,
                PassengerCount = vm.PassengerCount,
                EnginePower = vm.EnginePower,
                DoesHaveAutopilot = vm.DoesHaveAutopilot,
                CrewCount = vm.CrewCount,
                CargoWeight = vm.CargoWeight,
                DoesHaveLifeSupportSystems = vm.DoesHaveLifeSupportSystems,
                BuiltDate = vm.BuiltDate,
                LastMaintenance = vm.LastMaintenance,
                MaintenanceCount = vm.MaintenanceCount,
                FullTripsCount = vm.FullTripsCount,
                MaidenLaunch = vm.MaidenLaunch,
                Manufacturer = vm.Manufacturer,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
            };
            var result = await _spaceshipsServices.Update(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), vm);
        }
        
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {

            var spaceship = await _spaceshipsServices.GetAsync(id);
            if (spaceship == null)
            {
                return NotFound();
            }
            var photos = await _context.FilesToDatabase
                .Where(x => x.SpaceshipId == id)
                .Select(y => new ImageViewModel
                {
                    SpaceshipId = y.Id,
                    ImageId = y.Id,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();
            var vm = new SpaceshipDetailsViewModel();

            vm.Id = spaceship.Id;
            vm.Price = spaceship.Price;
            vm.Type = spaceship.Type;
            vm.Name = spaceship.Name;
            vm.Description = spaceship.Description;
            vm.FuelType = spaceship.FuelType;
            vm.FuelCapacity = spaceship.FuelCapacity;
            vm.FuelConsumption = spaceship.FuelConsumption;
            vm.PassengerCount = spaceship.PassengerCount;
            vm.EnginePower = spaceship.EnginePower;
            vm.DoesHaveAutopilot = spaceship.DoesHaveAutopilot;
            vm.CrewCount = spaceship.CrewCount;
            vm.CargoWeight = spaceship.CargoWeight;
            vm.DoesHaveLifeSupportSystems = spaceship.DoesHaveLifeSupportSystems;
            vm.BuiltDate = spaceship.BuiltDate;
            vm.LastMaintenance = spaceship.LastMaintenance;
            vm.MaintenanceCount = spaceship.MaintenanceCount;
            vm.FullTripsCount = spaceship.FullTripsCount;
            vm.MaidenLaunch = spaceship.MaidenLaunch;
            vm.Manufacturer = spaceship.Manufacturer;
            vm.CreatedAt = spaceship.CreatedAt;
            vm.ModifiedAt = spaceship.ModifiedAt;

            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {

            var spaceship = await _spaceshipsServices.GetAsync(id);
            if (spaceship == null)
            {
                return NotFound();
            }

            var vm = new SpaceshipDeleteViewModel()
            {

                Id = spaceship.Id,
                Price = spaceship.Price,
                Type = spaceship.Type,
                Name = spaceship.Name,
                Description = spaceship.Description,
                FuelType = spaceship.FuelType,
                FuelCapacity = spaceship.FuelCapacity,
                FuelConsumption = spaceship.FuelConsumption,
                PassengerCount = spaceship.PassengerCount,
                EnginePower = spaceship.EnginePower,
                DoesHaveAutopilot = spaceship.DoesHaveAutopilot,
                CrewCount = spaceship.CrewCount,
                CargoWeight = spaceship.CargoWeight,
                DoesHaveLifeSupportSystems = spaceship.DoesHaveLifeSupportSystems,
                BuiltDate = spaceship.BuiltDate,
                LastMaintenance = spaceship.LastMaintenance,
                MaintenanceCount = spaceship.MaintenanceCount,
                FullTripsCount = spaceship.FullTripsCount,
                MaidenLaunch = spaceship.MaidenLaunch,
                Manufacturer = spaceship.Manufacturer,
                CreatedAt = spaceship.CreatedAt,
                ModifiedAt = spaceship.ModifiedAt,
            };

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var spaceshipId = await _spaceshipsServices.Delete(id);
            if (spaceshipId == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
