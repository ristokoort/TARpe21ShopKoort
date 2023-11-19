using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARpe21ShopRisto.Core.Dto
{
    public class CarDto
    {
        public Guid? Id { get; set; }
        public string Brand { get; set; } // Bmw,Audi
        public string Transmission { get; set; } // Manual/automatic
        public string EngineType { get; set; } // gasoline, diesel, or electric motor
        public int Hp { get; set; } //horsepower
        public int FuelTankCapacity { get; set; }
        public int TireSize { get; set; }
        public string Previous_Ownership { get; set; }
        public List<IFormFile> Files { get; set; }
        public IEnumerable<FileToApiDto> FilesToApiDtos { get; set; } = new List<FileToApiDto>();
        
        //Db only
        public DateTime CreatedAt { get; set; } // when the entry was created
        public DateTime ModifiedAt { get; set; } // when the entry has been modified last
    }
}
