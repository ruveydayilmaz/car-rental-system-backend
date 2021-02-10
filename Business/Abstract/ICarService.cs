using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
        Car GetById(int id);
        List<Car> GetByDailyPrice(decimal min, decimal max);
        List<Car> GetAll();
        List<CarDetailDto> GetCarDetails();
    }
}
