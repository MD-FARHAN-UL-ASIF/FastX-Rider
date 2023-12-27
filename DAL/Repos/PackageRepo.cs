using DAL.EF.Models;
using DAL.iINTERFACES;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class PackageRepo : Repo, IRepo<Package, int, bool>
    {
        public bool Create(Package obj)
        {
            db.Packages.Add(obj);
            return db.SaveChanges()>0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Packages.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<Package> Get()
        {
            return db.Packages.ToList();
        }

        public Package Get(int id)
        {
            return db.Packages.Find(id);
        }

        public bool Update(Package obj)
        {
            var exObj = Get(obj.Id);
            if (exObj == null)
            {
                return false;
            }
            exObj.SenderId = obj.SenderId;
            exObj.RecipientId = obj.RecipientId;
            exObj.Description = obj.Description;
            exObj.Weight = obj.Weight;
            exObj.DestinationAddress = obj.DestinationAddress;
            exObj.ShippingMehtod = obj.ShippingMehtod;
            exObj.Insurance = obj.Insurance;
            exObj.EntitmatedDelivery = obj.EntitmatedDelivery;
            exObj.DiliveryManId = obj.DiliveryManId;
            exObj.PaymentStatus = obj.PaymentStatus;
            exObj.PymentMethod = obj.PymentMethod;
            exObj.Retuned = obj.Retuned;

            db.Packages.AddOrUpdate(exObj);
            return db.SaveChanges() > 0;
        }
    }
}
