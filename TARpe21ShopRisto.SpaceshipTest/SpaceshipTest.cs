using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TARpe21ShopRisto.Core.Domain;
using TARpe21ShopRisto.Core.Dto;
using TARpe21ShopRisto.Core.ServiceInterface;
using Xunit;

namespace TARpe21ShopRisto.SpaceshipTest
{
    public class SpaceshipTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptySpaceship_WhenReturnResult()
        {
            string guid = Guid.NewGuid().ToString();

            SpaceshipDto spaceship = new SpaceshipDto();

            spaceship.Id = Guid.Parse(guid);
            spaceship.Name = "Test name";
            spaceship.Description = "Test description";
            spaceship.PassengerCount = 4;
            spaceship.CrewCount = 4;
            spaceship.CargoWeight = 3000;
            spaceship.MaxSpeedInVaccuum = 200;
            spaceship.BuiltAtDate = DateTime.Now;
            spaceship.MaidenLaunch = DateTime.Now;
            spaceship.Manufacturer = "Test manufacturer";
            spaceship.IsSpaceshipPreviouslyOwned = true;
            spaceship.FullTripsCount = 1;
            spaceship.Type = "Test Type";
            spaceship.EnginePower = 9001;
            spaceship.FuelConsumptionPerDay = 4000;
            spaceship.MaintenanceCount = 0;
            spaceship.LastMaintenance = DateTime.Now;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;

            var result = await Svc<ISpaceshipsServices>().Create(spaceship);

            Assert.NotNull(result);
        }
        [Fact]
        public async Task Should_UpdateSpaceship_WhenUpdateData()
        {
            var guid = new Guid("c2d73cf6-671d-414b-948d-ee4664fb5d4d");

            Spaceship spaceship = new Spaceship();
            SpaceshipDto dto = MockSpaceshipData();

            spaceship.Id = Guid.Parse("c2d73cf6-671d-414b-948d-ee4664fb5d4d");
            spaceship.Name = "Edit Test name";
            spaceship.Description = "Test description";
            spaceship.PassengerCount = 400;
            spaceship.CrewCount = 4;
            spaceship.CargoWeight = 3000;
            spaceship.MaxSpeedInVaccuum = 200;
            spaceship.BuiltAtDate = DateTime.Now;
            spaceship.MaidenLaunch = DateTime.Now;
            spaceship.Manufacturer = "Test manufacturer";
            spaceship.IsSpaceshipPreviouslyOwned = true;
            spaceship.FullTripsCount = 1;
            spaceship.Type = "Test Type";
            spaceship.EnginePower = 9001;
            spaceship.FuelConsumptionPerDay = 4000;
            spaceship.MaintenanceCount = 0;
            spaceship.LastMaintenance = DateTime.Now;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;

            await Svc<ISpaceshipsServices>().Update(dto);

            Assert.Equal(spaceship.Id, guid);
            Assert.DoesNotMatch(spaceship.Name, dto.Name);
            Assert.NotEqual(spaceship.PassengerCount, dto.PassengerCount);
        }

        private SpaceshipDto MockSpaceshipData()
        {
            SpaceshipDto spaceship = new()
            {
                Name = "Test name",
                Description = "Test description",
                PassengerCount = 4,
                CrewCount = 4,
                CargoWeight = 3000,
                MaxSpeedInVaccuum = 200,
                BuiltAtDate = DateTime.Now,
                MaidenLaunch = DateTime.Now,
                Manufacturer = "Test manufacturer",
                IsSpaceshipPreviouslyOwned = true,
                FullTripsCount = 1,
                Type = "Test Type",
                EnginePower = 9001,
                FuelConsumptionPerDay = 4000,
                MaintenanceCount = 0,
                LastMaintenance = DateTime.Now,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };
            return spaceship;
        }


        [Fact]
        public async Task Should_DeleteByIdSpaceship_WhenDeleteSpaceship()
        {
            var guid = new Guid("c2d73cf6-671d-414b-948d-ee4664fb5d4d");

            
            SpaceshipDto spaceship = MockSpaceshipData();
            var createResult = await Svc<ISpaceshipsServices>().Create(spaceship);

            spaceship.Id = Guid.Parse("c2d73cf6-671d-414b-948d-ee4664fb5d4d");
            spaceship.Name = "Edit Test name";
            spaceship.Description = "Test description";
            spaceship.PassengerCount = 1500;
            spaceship.CrewCount = 15;
            spaceship.CargoWeight = 6000;
            spaceship.MaxSpeedInVaccuum = 450;
            spaceship.BuiltAtDate = DateTime.Now;
            spaceship.MaidenLaunch = DateTime.Now;
            spaceship.Manufacturer = "Test manufacturer";
            spaceship.IsSpaceshipPreviouslyOwned = true;
            spaceship.FullTripsCount = 3;
            spaceship.Type = "Test Type";
            spaceship.EnginePower = 6001;
            spaceship.FuelConsumptionPerDay = 3000;
            spaceship.MaintenanceCount = 1;
            spaceship.LastMaintenance = DateTime.Now;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;

            Assert.NotNull(createResult);
            var deleteResult = await Svc<ISpaceshipsServices>().DeleteById(guid);
            Assert.True(deleteResult);
        }

        


        [Fact]
        public async Task ShouldNot_DeleteByIdSpaceship_WhenDidNotDeleteSpaceship()
        {
            var guid = new Guid("c2d73cf6-671d-414b-948d-ee4664fb5d4d");

            SpaceshipDto spaceship = MockSpaceshipData();
            var createResult = await Svc<ISpaceshipsServices>().Create(spaceship);

            
            var deleteResult = await Svc<ISpaceshipsServices>().DeleteById(Guid.NewGuid());

            
            Assert.False(deleteResult);
        }

        [Fact]
        public async Task ShouldNot_UpdateSpaceship_WhenNotUpdateData()
        {
            
            var guid = new Guid("c2d73cf6-671d-414b-948d-ee4664fb5d4d");

            SpaceshipDto originalSpaceship = MockSpaceshipData();
            var createResult = await Svc<ISpaceshipsServices>().Create(originalSpaceship);

            
            SpaceshipDto updatedSpaceshipDto = MockSpaceshipData();
            updatedSpaceshipDto.Id = guid; 

            await Svc<ISpaceshipsServices>().Update(updatedSpaceshipDto);

            
            SpaceshipDto fetchedSpaceship = await Svc<ISpaceshipsServices>().GetById(guid);

            
            Assert.NotNull(fetchedSpaceship);
            Assert.NotEqual(originalSpaceship.Name, fetchedSpaceship.Name);
            Assert.NotEqual(originalSpaceship.Description, fetchedSpaceship.Description);
            Assert.NotEqual(originalSpaceship.PassengerCount, fetchedSpaceship.PassengerCount);
            Assert.NotEqual(originalSpaceship.CrewCount, fetchedSpaceship.CrewCount);
            Assert.NotEqual(originalSpaceship.CargoWeight, fetchedSpaceship.CargoWeight);
            Assert.NotEqual(originalSpaceship.MaxSpeedInVaccuum, fetchedSpaceship.MaxSpeedInVaccuum);
            Assert.NotEqual(originalSpaceship.BuiltAtDate, fetchedSpaceship.BuiltAtDate);
            Assert.NotEqual(originalSpaceship.MaidenLaunch, fetchedSpaceship.MaidenLaunch);
            Assert.NotEqual(originalSpaceship.Manufacturer, fetchedSpaceship.Manufacturer);
            Assert.NotEqual(originalSpaceship.IsSpaceshipPreviouslyOwned, fetchedSpaceship.IsSpaceshipPreviouslyOwned);
            Assert.NotEqual(originalSpaceship.FullTripsCount, fetchedSpaceship.FullTripsCount);
            Assert.NotEqual(originalSpaceship.Type, fetchedSpaceship.Type);
            Assert.NotEqual(originalSpaceship.EnginePower, fetchedSpaceship.EnginePower);
            Assert.NotEqual(originalSpaceship.FuelConsumptionPerDay, fetchedSpaceship.FuelConsumptionPerDay);
            Assert.NotEqual(originalSpaceship.MaintenanceCount, fetchedSpaceship.MaintenanceCount);
            Assert.NotEqual(originalSpaceship.LastMaintenance, fetchedSpaceship.LastMaintenance);
            Assert.NotEqual(originalSpaceship.CreatedAt, fetchedSpaceship.CreatedAt);
            Assert.NotEqual(originalSpaceship.ModifiedAt, fetchedSpaceship.ModifiedAt);

        }
        //[Fact]
        //public async Task Should_DeleteByIdSpaceship_WhenDeleteSpaceship()
        //{
        //    var guid = new Guid("c2d73cf6-671d-414b-948d-ee4664fb5d4d");

        //    SpaceshipDto spaceship = MockSpaceshipData();
        //    var createResult = await Svc<ISpaceshipsServices>().Create(spaceship);

        //    // Attempt to delete the spaceship with the same ID
        //    var deleteResult = await Svc<ISpaceshipsServices>().DeleteById(guid);

        //    // Assert that the deletion should be successful
        //    Assert.True(deleteResult);

        //    // Try to fetch the spaceship after the deletion
        //    SpaceshipDto fetchedSpaceship = await Svc<ISpaceshipsServices>().GetById(guid);

        //    // Assert that the spaceship is not found (deleted)
        //    Assert.Null(fetchedSpaceship);
        //}
    }
}
