using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARpe21ShopRisto.Core.Domain.Spaceship
{
    public class Spaceship
    {
        [Key]
       public Guid? Id { get; set; } //globally unique identifier
        public string Name { get; set; } // ship name   
        public string Description { get; set; } // ship description
        public int[] Dimensions { get; set; } //contains an array of int, with x y z values
        public int PassengerCount { get; set; } //how many passengers does the ship carry
        public int CrewCount { get; set; } // how many crewmembers is needed to operate the ship
        public int CargoWeight { get; set; } // how much cargo can the ship  to carry
        public int MaxSpeedInVaccum { get; set; } // maximum speed after exiting atmosphere
        public DateTime BuiltAtDate { get; set; }// the date this hip was built at
        public DateTime MaidenLaunch { get; set; }// the date that this ship did its first voyage
        public string Manufacturer { get; set; } // company who manufactured the spaceship
        public bool IsSpaceshipPreviouslyOwned { get; set; } // denotes if the ship has been previously owned or not,tldr; second hand identifier
        public int FullTripsCount { get; set; } // How many round trips has the ship taken
        public string Type { get; set; } //bodytype, build type
        public int EnginePower { get; set; } // how much (kw) does the engine have
        public int FuelConsumptionPerDay { get; set; } // fuel consumed in a days worth of space travel
        public int MaintenanceCount { get; set; } // how many maintenance sessions have been conducted on this ship
        public DateTime LastMaintenance { get; set; } // when was the last maintenance performed




        //only in database

        public DateTime CreatedAt { get; set; } // when the entry was create
        public DateTime ModifiedAt { get; set;} // when the entry was last modified


    }
}
