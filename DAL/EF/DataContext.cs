using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class DataContext : DbContext
    {
        public DbSet<Rider> Riders { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<DeliveryStatus> DeliveryStatuses { get; set; }
    }
}
