using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalSystemContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalSystemContext context = new CarRentalSystemContext())
            {
                var result = from car in context.tCars
                             join brand in context.tBrands
                             on car.BrandId equals brand.BrandId
                             join color in context.tColors
                             on car.ColorId equals color.ColorId
                             select new CarDetailDto 
                             {
                                 Id = car.Id,
                                 BrandName = brand.BrandName,
                                 CarName = car.CarName,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                             };

                return result.ToList();
            }
        }
    }
}
