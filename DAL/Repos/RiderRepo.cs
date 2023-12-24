using DAL.EF.Models;
using DAL.iINTERFACES;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Design;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class RiderRepo : Repo, IRepo<Rider, int, bool>
    {
        public bool Create(Rider obj)
        {
            db.Riders.Add(obj);
            return db.SaveChanges()>0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Riders.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<Rider> Get()
        {
            return db.Riders.ToList();
        }

        public Rider Get(int id)
        {
            return db.Riders.Find(id);
        }

        public bool Update(Rider obj)
        {
            var exObj = Get(obj.Id);
            if (exObj == null)
            { 
                return false;
            }
            exObj.Name = obj.Name;
            exObj.UserName = obj.UserName;
            exObj.PhoneNumber = obj.PhoneNumber;
            exObj.Email = obj.Email;
            exObj.NID = obj.NID;
            exObj.DOB = obj.DOB;
            exObj.Gender = obj.Gender;
            exObj.Address = obj.Address;
            exObj.City = obj.City;
            exObj.Station = obj.Station;
            exObj.VehicaleType = obj.VehicaleType;
            exObj.Salary = obj.Salary;
            exObj.Status = obj.Status;
            exObj.Created_at = obj.Created_at;

            db.Riders.AddOrUpdate(exObj);
            return db.SaveChanges()>0;
        }
    }
}
