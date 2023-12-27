using DAL.EF.Models;
using DAL.iINTERFACES;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Rider, int, bool> RiderData()
        {
            return new RiderRepo();
        }

        public static IRepo<Package, int, bool> PackageData()
        {
            return new PackageRepo();
        }

        public static IRepo<DeliveryStatus, int, bool> DeliveryStatusData()
        {
            return new DeliveryStatusRepo();
        }
    }
}
