using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BLL.Services
{
    public class RiderServices
    {
        public static List<RiderDTO> Get()
        {
            var data = DataAccessFactory.RiderData().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Rider, RiderDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrted = mapper.Map<List<RiderDTO>>(data);
            return cnvrted;
        }

        public static RiderDTO Get (int id)
        {
            var data = DataAccessFactory.RiderData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Rider, RiderDTO>();
            });
            var mapper = new Mapper (config);
            var cnvrted = mapper.Map<RiderDTO>(data);
            return cnvrted;
        }

        public static RiderDTO Create(RiderDTO riderDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RiderDTO, Rider>();
                cfg.CreateMap<Rider, RiderDTO>();
            });
            var mapper = new Mapper(config);
            var rider = mapper.Map<Rider>(riderDTO);
            var isSuccess = DataAccessFactory.RiderData().Create(rider);

            if (isSuccess)
            {
                var createdRider = DataAccessFactory.RiderData().Get(rider.Id);
                var createdRiderDTO = mapper.Map<RiderDTO>(createdRider);
                return createdRiderDTO;
            }
            else
            {
                return null;
            }
        }

        public static bool Delete(int id)
        {
            var isSuccess = DataAccessFactory.RiderData().Delete(id);
            return isSuccess;
        }

        public static bool Update(RiderDTO riderDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RiderDTO, Rider>();
                cfg.CreateMap<Rider, RiderDTO>();
            });
            var mapper = new Mapper(config);
            var rider = mapper.Map<Rider>(riderDTO);

            var isSuccess = DataAccessFactory.RiderData().Update(rider);
            return isSuccess;
        }
    }
}
