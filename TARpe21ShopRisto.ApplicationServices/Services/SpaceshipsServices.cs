using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe21ShopRisto.Core.Domain.Spaceship;
using TARpe21ShopRisto.Core.ServiceInterface;
using TARpe21ShopRisto.Data;
using TARpe21ShopRisto.Core.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace TARpe21ShopRisto.ApplicationServices.Services
{
    public class SpaceshipsServices : ISpaceshipsServices
    {
        private readonly TARpe21ShopRistoContext _context;

    public SpaceshipsServices(TARpe21ShopRistoContext context)
        {
            _context = context;
        }   
        public async Task<Spaceship> Add(SpaceshipDto dto)
        {
            var domain = new Spaceship()
            {
                Name = dto.Name,
                Description = dto.Description,
                PassengerCount = dto.PassengerCount,
                CrewCount = dto.CrewCount,
                CargoWeight = dto.CargoWeight,
                
                BuiltAtDate = dto.BuiltAtDate,
                MaidenLaunch = dto.MaidenLaunch,
                Manufacturer = dto.Manufacturer,
                IsSpaceshipPreviouslyOwned = dto.IsSpaceshipPreviouslyOwned,
                FullTripsCount = dto.FullTripsCount,
                Type = dto.Type,
                EnginePower = dto.EnginePower,
                FuelConsumptionPerDay = dto.FuelConsumptionPerDay,
                MaintenanceCount = dto.MaintenanceCount,
                LastMaintenance = dto.LastMaintenance,
                CreatedAt = dto.CreatedAt,
                ModifiedAt = dto.ModifiedAt,
            };
            await _context.spaceships.AddAsync(domain);
            await _context.SaveChangesAsync();
            return domain;
        }
        public async Task<Spaceship> Update(SpaceshipDto dto)
        {
            var domain = new Spaceship()
            {
                Name = dto.Name,
                Description = dto.Description,
                PassengerCount = dto.PassengerCount,
                CrewCount = dto.CrewCount,
                CargoWeight = dto.CargoWeight,

                BuiltAtDate = dto.BuiltAtDate,
                MaidenLaunch = dto.MaidenLaunch,
                Manufacturer = dto.Manufacturer,
                IsSpaceshipPreviouslyOwned = dto.IsSpaceshipPreviouslyOwned,
                FullTripsCount = dto.FullTripsCount,
                Type = dto.Type,
                EnginePower = dto.EnginePower,
                FuelConsumptionPerDay = dto.FuelConsumptionPerDay,
                MaintenanceCount = dto.MaintenanceCount,
                LastMaintenance = dto.LastMaintenance,
                CreatedAt = dto.CreatedAt,
                ModifiedAt = DateTime.Now
            };
             _context.spaceships.Update(domain);
            await _context.SaveChangesAsync();
            return domain;
        }
        public async Task<Spaceship> GetUpdate(Guid id)
        {
            var result = await _context.spaceships
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        
    }
        public async Task<Spaceship> Delete(Guid Id)
        {
            var spaceshipId = await _context.spaceships
                .FirstOrDefaultAsync(x => x.Id == Id);

            _context.spaceships.Remove(spaceshipId);
            await _context.SaveChangesAsync();

            return spaceshipId;
        }
        public async Task<Spaceship> GetAsync(Guid Id)
        {
            var result = await _context.spaceships
                .FirstOrDefaultAsync (x => x.Id == Id);
            return result;
        }
    }
}