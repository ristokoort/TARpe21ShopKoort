﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TARpe21ShopRisto.Models;
using TARpe21ShopRisto.Data;
using TARpe21ShopRisto.Core.ServiceInterface;
using TARpe21ShopRisto.Core.Dto;
using System.Runtime.Intrinsics.X86;
using TARpe21ShopRisto.Models.Spaceship;

namespace TARpe21ShopRisto.Controllers
{
    public class SpaceshipsController : Controller
    {
        private readonly TARpe21ShopRistoContext _context;
        private readonly ISpaceshipsServices _spaceshipsServices;

        public SpaceshipsController
            (
            TARpe21ShopRistoContext context,
            ISpaceshipsServices spaceshipsServices
            )
        {
            _context = context;
            _spaceshipsServices = spaceshipsServices;
        }
        public IActionResult Index()
        {
            var result = _context.spaceships
                .OrderBy(x => x.CreatedAt)
                .Select(x => new SpaceshipIndexViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    
                    EnginePower = x.EnginePower,
                });
            return View(result);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View("Edit");
        }
        [HttpPost]
        public async Task<IActionResult> Add(SpaceshipEditViewModel vm)
        {
            var dto = new SpaceshipDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                Description = vm.Description,
                PassengerCount = vm.PassengerCount,
                CrewCount = vm.CrewCount,
                CargoWeight = vm.CargoWeight,
                MaxSpeedInVaccuum = vm.MaxSpeedInVaccuum,
                BuiltAtDate = vm.BuiltAtDate,
                MaidenLaunch = vm.MaidenLaunch,
                Manufacturer = vm.Manufacturer,
                IsSpaceshipPreviouslyOwned = vm.IsSpaceshipPreviouslyOwned,
                FullTripsCount = vm.FullTripsCount,
                Type = vm.Type,
                EnginePower = vm.EnginePower,
                FuelConsumptionPerDay = vm.FuelConsumptionPerDay,
                MaintenanceCount = vm.MaintenanceCount,
                LastMaintenance = vm.LastMaintenance,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt
            };
            var result = await _spaceshipsServices.Add(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), vm);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var spaceship = await _spaceshipsServices.GetUpdate(id);
            if (spaceship == null)
            {
                return NotFound();
            }
            var vm = new SpaceshipEditViewModel()
            {
                Id = spaceship.Id,
                Name = spaceship.Name,
                Description = spaceship.Description,
                PassengerCount = spaceship.PassengerCount,
                CrewCount = spaceship.CrewCount,
                CargoWeight = spaceship.CargoWeight,
                
                BuiltAtDate = spaceship.BuiltAtDate,
                MaidenLaunch = spaceship.MaidenLaunch,
                Manufacturer = spaceship.Manufacturer,
                IsSpaceshipPreviouslyOwned = spaceship.IsSpaceshipPreviouslyOwned,
                FullTripsCount = spaceship.FullTripsCount,
                Type = spaceship.Type,
                EnginePower = spaceship.EnginePower,
                FuelConsumptionPerDay = spaceship.FuelConsumptionPerDay,
                MaintenanceCount = spaceship.MaintenanceCount,
                LastMaintenance = spaceship.LastMaintenance,
                CreatedAt = spaceship.CreatedAt,
                ModifiedAt = spaceship.ModifiedAt
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(SpaceshipEditViewModel vm)
        {
            var dto = new SpaceshipDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                Description = vm.Description,
                PassengerCount = vm.PassengerCount,
                CrewCount = vm.CrewCount,
                CargoWeight = vm.CargoWeight,
                MaxSpeedInVaccuum = vm.MaxSpeedInVaccuum,
                BuiltAtDate = vm.BuiltAtDate,
                MaidenLaunch = vm.MaidenLaunch,
                Manufacturer = vm.Manufacturer,
                IsSpaceshipPreviouslyOwned = vm.IsSpaceshipPreviouslyOwned,
                FullTripsCount = vm.FullTripsCount,
                Type = vm.Type,
                EnginePower = vm.EnginePower,
                FuelConsumptionPerDay = vm.FuelConsumptionPerDay,
                MaintenanceCount = vm.MaintenanceCount,
                LastMaintenance = vm.LastMaintenance,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt
            };
            var result = await _spaceshipsServices.Update(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), vm);
        }
    }
}