using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe22ShopVaitmaa.Core.Domain;
using TARpe22ShopVaitmaa.Core.Dto;
using TARpe22ShopVaitmaa.Core.ServiceInterface;
using Xunit;

namespace TARpe22ShopVaitmaa.SpaceshipTest
{
    public class SpaceshipTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptySpaceship_WhenReturnResult()
        {
            string guid = Guid.NewGuid().ToString();

            SpaceshipDto spaceship = new SpaceshipDto();

            spaceship.Id = Guid.Parse(guid);
            spaceship.Price = 100;
            spaceship.Type = "rocket";
            spaceship.Name = "X ae A 12";
            spaceship.Description = "Description";
            spaceship.FuelType = "Cowfarts";
            spaceship.FuelCapacity = 100;
            spaceship.FuelConsumption = 100;
            spaceship.PassengerCount = 100;
            spaceship.EnginePower = 100;
            spaceship.DoesHaveAutopilot = true;
            spaceship.CrewCount = 100;
            spaceship.CargoWeight = 100;
            spaceship.DoesHaveLifeSupportSystems = true;
            spaceship.BuiltDate = DateTime.Now;
            spaceship.LastMaintenance = DateTime.Now;
            spaceship.MaintenanceCount = 1;
            spaceship.FullTripsCount = 1;
            spaceship.MaidenLaunch = DateTime.Now;
            spaceship.Manufacturer = "Space Z";
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;
            spaceship.Files = new List<IFormFile>();

            var result = await Svc<ISpaceshipsServices>().Create(spaceship);

            Assert.NotNull(result);
        }
    }
}
