using TARpe21ShopRisto.Core.Domain;
using TARpe21ShopRisto.Core.Dto;

namespace TARpe21ShopRisto.ApplicationServices.Services
{
    public interface IFilesServices
    {
        void UploadFilesToDatabase(SpaceshipDto dto, Spaceship domain);
    }
}