using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal: EfEntityRepositoryBase<Rental, CarRentalSystemContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {

            using (CarRentalSystemContext context = new CarRentalSystemContext())
            {
                var result = from r in context.tRentals
                             join ca in context.tCars
                             on r.CarId equals ca.CarId
                             select new RentalDetailDto
                             {
                                 Id = r.RentalId,
                                 CarName = ca.CarName,
                                 CarId = ca.CarId,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                             };

                return result.ToList();
            }
        }
    }
}
