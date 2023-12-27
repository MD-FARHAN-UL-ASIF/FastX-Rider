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
    public class PackageServices
    {
        public static List<PackageDTO> Get()
        {
            var data = DataAccessFactory.PackageData().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Package, PackageDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrted = mapper.Map<List<PackageDTO>>(data);
            return cnvrted;
        }

        public static PackageDTO Get(int id)
        {
            var data = DataAccessFactory.PackageData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Package, PackageDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrted = mapper.Map<PackageDTO>(data);
            return cnvrted;
        }

        public static PackageDTO Create(PackageDTO packageDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PackageDTO, Package>();
                cfg.CreateMap<Package, PackageDTO>();
            });
            var mapper = new Mapper(config);
            var package = mapper.Map<Package>(packageDTO);
            var isSuccess = DataAccessFactory.PackageData().Create(package);

            if (isSuccess)
            {
                var createdPackage = DataAccessFactory.PackageData().Get(package.Id);
                var createdPackageDTO = mapper.Map<PackageDTO>(createdPackage);
                return createdPackageDTO;
            }
            else
            {
                return null;
            }
        }

        public static bool Delete(int id)
        {
            var isSuccess = DataAccessFactory.PackageData().Delete(id);
            return isSuccess;
        }

        public static PackageDTO Update(PackageDTO packageDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PackageDTO, Package>();
                cfg.CreateMap<Package, PackageDTO>();
            });
            var mapper = new Mapper(config);
            var package = mapper.Map<Package>(packageDTO);

            var isSuccess = DataAccessFactory.PackageData().Update(package);
            
            if (isSuccess)
            {
                var createdPackage = DataAccessFactory.PackageData().Get(package.Id);
                var createdPackageDTO = mapper.Map<PackageDTO>(createdPackage);
                return createdPackageDTO;
            }
            else
            {
                return null;
            }
        }
    }
}
