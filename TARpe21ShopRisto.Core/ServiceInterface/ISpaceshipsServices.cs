using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe21ShopRisto.Core.Domain.Spaceship;
using TARpe21ShopRisto.Core.Dto;

namespace TARpe21ShopRisto.Core.ServiceInterface
{
    public interface ISpaceshipsServices
    {
        Task<Spaceship> Add(SpaceshipDto dto);
    }
}
