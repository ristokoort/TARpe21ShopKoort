using TARpe21ShopRisto.Models.Shared;

namespace TARpe21ShopRisto.Models.Car
{
    public class CarDeleteDetailsViewModel
    {
        public Guid? Id { get; set; }
        public string Brand { get; set; } // Bmw,Audi
        public string Transmission { get; set; } // Manual/automatic
        public string EngineType { get; set; } // gasoline, diesel, or electric motor
        public int Hp { get; set; } //horsepower
        public int FuelTankCapacity { get; set; }
        public int TireSize { get; set; }
        public bool Previous_Ownership { get; set; }

        public List<IFormFile> Files { get; set; }
        public List<FileToApiViewModel> FileToApiViewModels { get; set; } = new List<FileToApiViewModel>();


        public bool isDeleting { get; set; }
        //Db only
        public DateTime CreatedAt { get; set; } // when the entry was created
        public DateTime ModifiedAt { get; set; } // when the entry has been modified last
    }
}
