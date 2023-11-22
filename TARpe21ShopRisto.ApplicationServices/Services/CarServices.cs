using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using TARpe21ShopRisto.ApplicationServices.Services;
using TARpe21ShopRisto.Core.Domain;
using TARpe21ShopRisto.Core.Dto;
using TARpe21ShopRisto.Core.ServiceInterface;
using TARpe21ShopRisto.Data;

namespace TARpe21ShopRisto.ApplicationServices.Services
{
    public class CarServices : ICarServices
    {
        private readonly TARpe21ShopRistoContext _context;
        private readonly IFilesServices _filesServices;
        public CarServices
            (
            TARpe21ShopRistoContext context,
            IFilesServices filesServices
            )
        {
            _context = context;
            _filesServices = filesServices;
        }
        public async Task<Car> Create(CarDto dto)
        {
            Car car = new();

            car.Id = Guid.NewGuid();
            car.Brand = dto.Brand;
            car.Transmission = dto.Transmission;
            car.EngineType = dto.EngineType;
            car.Hp = dto.Hp;
            car.Previous_Ownership = dto.Previous_Ownership;
            car.FuelTankCapacity = dto.FuelTankCapacity;
            car.TireSize = dto.TireSize;
            car.CreatedAt = DateTime.Now;
            car.ModifiedAt = DateTime.Now;
            _filesServices.FilesToApi(dto, car);


            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
            return car;
        }
        public async Task<Car> Delete(Guid id)
        {
            var carId = await _context.Cars
                .Include(x => x.FilesToApi)
                .FirstOrDefaultAsync(x => x.Id == id);
            var images = await _context.FilesToApi
                .Where(x => x.CarId == id)
                .Select(y => new FileToApiDto
                {
                    Id = y.Id,
                    CarId = y.CarId,
                    ExistingFilePath = y.ExistingFilePath
                }).ToArrayAsync();
            await _filesServices.RemoveImagesFromApi(images);
            _context.Cars.Remove(carId);
            await _context.SaveChangesAsync();
            return carId;
        }
        public async Task<Car> Update(CarDto dto)
        {
            Car car = new Car();

            car.Id = dto.Id;
            car.Brand = dto.Brand;
            car.Transmission = dto.Transmission;
            car.EngineType = dto.EngineType;
            car.Hp = dto.Hp;
            car.Previous_Ownership = dto.Previous_Ownership;
            car.FuelTankCapacity = dto.FuelTankCapacity;
            car.TireSize = dto.TireSize;
            car.CreatedAt = DateTime.Now;
            car.ModifiedAt = DateTime.Now;
            _filesServices.FilesToApi(dto, car);

            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
            return car;
        }
        public async Task<Car> GetAsync(Guid id)
        {
            var result = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
    }
}