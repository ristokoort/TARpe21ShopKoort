using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe21ShopRisto.Core.Domain;

namespace TARpe21ShopRisto.Data
{
    public class TARpe21ShopRistoContext : DbContext
    {
        public TARpe21ShopRistoContext(DbContextOptions<TARpe21ShopRistoContext>options) : base(options) { }

        public DbSet<Spaceship> spaceships { get; set; }
    }
}
