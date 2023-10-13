using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe21ShopRisto.Core.Domain.Spaceship;
using TARpe21ShopRisto.Data;

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
            var domain = new Spaceships()
            {
                Name = dto.Name,
                Description=dto.Description,
                Dimensions = dto.Dimensions,
                PassengerCount = dto.PassengerCount,
                CrewCount=dto.CrewCount,
                CargoWeight=dto.CargoWeight,
                MaxSpeedInVaccum=dto.MaxSpeedInVaccum,
                BuiltAtDate=dto.BuiltAtDate,
                MaidenLaunch=dto.MaidenLaunch,
                ManuFacturer=dto.ManuFacturer,  
                IsSpaceshipPreviouslyOwned=dto.IsSpaceshipPreviouslyOwned,
                FullTripsCount=dto.FullTripsCount,
                Type=dto.Type,


            }
        }
    }
}
