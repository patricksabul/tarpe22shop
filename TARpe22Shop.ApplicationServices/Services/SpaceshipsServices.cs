using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe22ShopVaitmaa.Core.Domain.Spaceship;
using TARpe22ShopVaitmaa.Core.Dto;
using TARpe22ShopVaitmaa.Core.ServiceInterface;
using TARpe22ShopVaitmaa.Data;

namespace TARpe22ShopVaitmaa.ApplicationServices.Services
{
    public class SpaceshipsServices : ISpaceshipsServices
    {
        private readonly TARpe22ShopVaitmaaContext _context;

        public SpaceshipsServices( TARpe22ShopVaitmaaContext context)
        {
            _context = context;
        }

        public async Task<Spaceship> Create(SpaceshipDto dto)
        {
            var domain = new Spaceship()
            {
                Id = dto.Id,
                Price = dto.Price,
                Type = dto.Type,
                Name = dto.Name,
                Description = dto.Description,
                FuelType = dto.FuelType,
                FuelCapacity = dto.FuelCapacity,
                FuelConsumption = dto.FuelConsumption,
                PassengerCount = dto.PassengerCount,
                EnginePower = dto.EnginePower,
                DoesHaveAutopilot = dto.DoesHaveAutopilot,
                CrewCount = dto.CrewCount,
                CargoWeight = dto.CargoWeight,
                DoesHaveLifeSupportSystems = dto.DoesHaveLifeSupportSystems,
                BuiltDate = dto.BuiltDate,
                LastMaintenance = dto.LastMaintenance,
                MaintenanceCount = dto.MaintenanceCount,
                FullTripsCount = dto.FullTripsCount,
                MaidenLaunch = dto.MaidenLaunch,
                Manufacturer = dto.Manufacturer,
                CreatedAt = dto.CreatedAt,
                ModifiedAt = dto.ModifiedAt,
            };

            await _context.Spaceships.AddAsync(domain);
            await _context.SaveChangesAsync();

            return domain; 
        }
        public async Task<Spaceship> Update(SpaceshipDto dto)
        {
            var domain = new Spaceship()
            {
                Id = dto.Id,
                Price = dto.Price,
                Type = dto.Type,
                Name = dto.Name,
                Description = dto.Description,
                FuelType = dto.FuelType,
                FuelCapacity = dto.FuelCapacity,
                FuelConsumption = dto.FuelConsumption,
                PassengerCount = dto.PassengerCount,
                EnginePower = dto.EnginePower,
                DoesHaveAutopilot = dto.DoesHaveAutopilot,
                CrewCount = dto.CrewCount,
                CargoWeight = dto.CargoWeight,
                DoesHaveLifeSupportSystems = dto.DoesHaveLifeSupportSystems,
                BuiltDate = dto.BuiltDate,
                LastMaintenance = dto.LastMaintenance,
                MaintenanceCount = dto.MaintenanceCount,
                FullTripsCount = dto.FullTripsCount,
                MaidenLaunch = dto.MaidenLaunch,
                Manufacturer = dto.Manufacturer,
                CreatedAt = dto.CreatedAt,
                ModifiedAt = dto.ModifiedAt,
            };

            _context.Spaceships.Update(domain);
            await _context.SaveChangesAsync();

            return domain;
        }
        public async Task<Spaceship> Delete(Guid id)
        {
            var spaceshipId = await _context.Spaceships
                .FirstOrDefaultAsync(x => x.Id == id);
            _context.Spaceships.Remove(spaceshipId);
            await _context.SaveChangesAsync();
            return spaceshipId;
        }
        public async Task<Spaceship> GetAsync(Guid id)
        {
            var result = await _context.Spaceships
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
    }
}
