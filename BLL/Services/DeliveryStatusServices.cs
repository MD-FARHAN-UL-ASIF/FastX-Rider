using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DeliveryStatusServices
    {
        public static List<DeliveryStatusDTO> Get()
        {
            var data = DataAccessFactory.DeliveryStatusData().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DeliveryStatus, DeliveryStatusDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrted = mapper.Map<List<DeliveryStatusDTO>>(data);
            return cnvrted;
        }

        public static DeliveryStatusDTO Get(int id)
        {
            var data = DataAccessFactory.DeliveryStatusData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DeliveryStatus, DeliveryStatusDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrted = mapper.Map<DeliveryStatusDTO>(data);
            return cnvrted;
        }

        public static DeliveryStatusDTO Create(DeliveryStatusDTO deliveryStatusDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DeliveryStatusDTO, DeliveryStatus>();
                cfg.CreateMap<DeliveryStatus, DeliveryStatusDTO>();
            });
            var mapper = new Mapper(config);
            var deliveryStatus = mapper.Map<DeliveryStatus>(deliveryStatusDTO);
            var isSuccess = DataAccessFactory.DeliveryStatusData().Create(deliveryStatus);

            if (isSuccess)
            {
                var createdStatus = DataAccessFactory.DeliveryStatusData().Get(deliveryStatus.Id);
                var createdStatusDTO = mapper.Map<DeliveryStatusDTO>(createdStatus);
                return createdStatusDTO;
            }
            else
            {
                return null;
            }
        }

        public static bool Delete(int id)
        {
            var isSuccess = DataAccessFactory.DeliveryStatusData().Delete(id);
            return isSuccess;
        }

        public static DeliveryStatusDTO Update(DeliveryStatusDTO deliveryStatusDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DeliveryStatusDTO, DeliveryStatus>();
                cfg.CreateMap<DeliveryStatus, DeliveryStatusDTO>();
            });
            var mapper = new Mapper(config);
            var deliveryStatus = mapper.Map<DeliveryStatus>(deliveryStatusDTO);

            var isSuccess = DataAccessFactory.DeliveryStatusData().Update(deliveryStatus);
            
            if (isSuccess)
            {
                var createdStatus = DataAccessFactory.DeliveryStatusData().Get(deliveryStatus.Id);
                var createdStatusDTO = mapper.Map<DeliveryStatusDTO>(createdStatus);
                return createdStatusDTO;
            }
            else
            {
                return null;
            }
        }
    }
}
