using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using System.Xml.Linq;
using TARpe21ShopRisto.ApplicationServices.Services;
using TARpe21ShopRisto.Core.Dto;
using TARpe21ShopRisto.Core.ServiceInterface;
using TARpe21ShopRisto.Data;
using TARpe21ShopRisto.Models.Car;
using TARpe21ShopRisto.Models.Shared;

namespace TARpe21ShopRisto.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarServices _cars;
        private readonly TARpe21ShopRistoContext _context;
        private readonly IFilesServices _filesServices;
        public CarsController
            (
            ICarServices cars,
            TARpe21ShopRistoContext context, IFilesServices files
            )
        {
            _cars = cars;
            _context = context;
            _filesServices = files;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.Cars
                .OrderByDescending(x => x.CreatedAt)
                .Select(x => new CarIndexViewModel
                {
                    Id = x.Id,
                    Brand = x.Brand,
                    EngineType = x.EngineType,
                    Transmission = x.Transmission,
                    Hp = x.Hp,
                    Previous_Ownership = x.Previous_Ownership,
                    FuelTankCapacity = x.FuelTankCapacity,
                    TireSize = x.TireSize,
                });
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveImage(FileToApiViewModel vm)
        {
            var dto = new FileToApiDto()
            {
                Id = vm.ImageId
            };
            var image = await _filesServices.RemoveImageFromApi(dto);
            if (image == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Create()
        {
            CarCreateUpdateViewModel vm = new();
            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarCreateUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = vm.Id,
                Brand = vm.Brand,
                EngineType = vm.EngineType,
                Transmission = vm.Transmission,
                Hp = vm.Hp,
                Previous_Ownership = vm.Previous_Ownership,
                FuelTankCapacity = vm.FuelTankCapacity,
                TireSize = vm.TireSize,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                Files = vm.Files,
                FilesToApiDtos = vm.FileToApiViewModels
                .Select(z => new FileToApiDto
                {
                    Id = z.ImageId,
                    ExistingFilePath = z.FilePath,
                    CarId = z.CarId,
                }).ToArray()
            };
            var result = await _cars.Create(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", vm);
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var car = await _cars.GetAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            var images = await _context.FilesToApi
                .Where(x => x.CarId == id)
                .Select(y => new FileToApiViewModel
                {
                    FilePath = y.ExistingFilePath,
                    ImageId = y.Id
                }).ToArrayAsync();
            var vm = new CarCreateUpdateViewModel();

            vm.Id = car.Id;
            vm.Brand = car.Brand;
            vm.EngineType = car.EngineType;
            vm.Transmission = car.Transmission;
            vm.Hp = car.Hp;
            vm.Previous_Ownership = car.Previous_Ownership;
            vm.FuelTankCapacity = car.FuelTankCapacity;
            vm.TireSize = car.TireSize;
            vm.CreatedAt = DateTime.Now;
            vm.ModifiedAt = DateTime.Now;
            vm.FileToApiViewModels.AddRange(images);

            return View("CreateUpdate", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CarCreateUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = vm.Id,
                Brand = vm.Brand,
                EngineType = vm.EngineType,
                Transmission = vm.Transmission,
                Hp = vm.Hp,
                Previous_Ownership = vm.Previous_Ownership,
                FuelTankCapacity = vm.FuelTankCapacity,
                TireSize = vm.TireSize,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                Files = vm.Files,
                FilesToApiDtos = vm.FileToApiViewModels
                .Select(z => new FileToApiDto
                {
                    Id = z.ImageId,
                    ExistingFilePath = z.FilePath,
                    CarId = z.CarId,
                }).ToArray()
            };
            var result = await _cars.Update(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), vm);
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var car = await _cars.GetAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            var images = await _context.FilesToApi
                .Where(x => x.CarId == id)
                .Select(y => new FileToApiViewModel
                {
                    FilePath = y.ExistingFilePath,
                    ImageId = y.Id
                }).ToArrayAsync();

            var vm = new CarDeleteDetailsViewModel();

            vm.Id = car.Id;
            vm.Brand = car.Brand;
            vm.EngineType = car.EngineType;
            vm.Transmission = car.Transmission;
            vm.Hp = car.Hp;
            vm.Previous_Ownership = car.Previous_Ownership;
            vm.FuelTankCapacity = car.FuelTankCapacity;
            vm.TireSize = car.TireSize;
            vm.CreatedAt = DateTime.Now;
            vm.ModifiedAt = DateTime.Now;
            vm.FileToApiViewModels.AddRange(images);

            return View("DeleteDetails", vm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var car = await _cars.GetAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            var images = await _context.FilesToApi
                .Where(x => x.CarId == id)
                .Select(y => new FileToApiViewModel
                {
                    FilePath = y.ExistingFilePath,
                    ImageId = y.Id
                }).ToArrayAsync();

            var vm = new CarDeleteDetailsViewModel();

            vm.Id = car.Id;
            vm.Brand = car.Brand;
            vm.EngineType = car.EngineType;
            vm.Transmission = car.Transmission;
            vm.Hp = car.Hp;
            vm.Previous_Ownership = car.Previous_Ownership;
            vm.FuelTankCapacity = car.FuelTankCapacity;
            vm.TireSize = car.TireSize;
            vm.CreatedAt = DateTime.Now;
            vm.ModifiedAt = DateTime.Now;
            vm.isDeleting = true;
            vm.FileToApiViewModels.AddRange(images);

            return View("DeleteDetails", vm);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var car = await _cars.Delete(id);
            if (car == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));

        }
    }
}
