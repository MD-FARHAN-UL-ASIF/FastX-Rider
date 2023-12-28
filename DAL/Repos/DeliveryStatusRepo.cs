using DAL.EF.Models;
using DAL.iINTERFACES;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class DeliveryStatusRepo : Repo, IRepo<DeliveryStatus, int, bool>
    {
        public bool Create(DeliveryStatus obj)
        {
            db.DeliveryStatuses.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.DeliveryStatuses.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<DeliveryStatus> Get()
        {
            return db.DeliveryStatuses
                .Include(p => p.Package)
                .ToList();
        }

        public DeliveryStatus Get(int id)
        {
            return db.DeliveryStatuses
                .Include (p => p.Package)
                .FirstOrDefault(p => p.Id == id);
        }

        public bool Update(DeliveryStatus obj)
        {
            var exObj = Get(obj.Id);
            if (exObj == null)
            {
                return false;
            }
            exObj.Status = obj.Status;
            exObj.Timestamp = obj.Timestamp;
            exObj.PackageId = obj.PackageId;
            exObj.LastUpdatedBy = obj.LastUpdatedBy;
            
            db.DeliveryStatuses.AddOrUpdate(exObj);
            return db.SaveChanges() > 0;
        }
    }
}
