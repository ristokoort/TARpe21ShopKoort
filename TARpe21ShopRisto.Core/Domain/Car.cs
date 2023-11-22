using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARpe21ShopRisto.Core.Domain
{
    public class Car
    {
        public Guid? Id { get; set; }
        public string Brand { get; set; } // Bmw,Audi
        public string Transmission { get; set; } // Manual/automatic
        public string EngineType { get; set; } // gasoline, diesel, or electric motor
        public int Hp { get; set; } //horsepower
        public int FuelTankCapacity { get; set; }
        public int TireSize { get; set; }
        public bool Previous_Ownership { get; set; }
        public List<FileToApi> FilesToApi { get; set; } = new List<FileToApi>();
       

        //Db only
        public DateTime CreatedAt { get; set; } // when the entry was created
        public DateTime ModifiedAt { get; set; } // when the entry has been modified last

    }
}
