using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{CarId = 10, BrandId = 1, ColorId = 101, DailyPrice = 230, ModelYear = "2016", Description = "Otomatik, Volkswagen Passat"},
                new Car{CarId = 11, BrandId = 2, ColorId = 102, DailyPrice = 200, ModelYear = "2015", Description = "Otomatik, Mercedes CLA"},
                new Car{CarId = 12, BrandId = 3, ColorId = 103, DailyPrice = 350, ModelYear = "2019", Description = "Otomatik, Audi A3 Sedan"},
                new Car{CarId = 13, BrandId = 4, ColorId = 102, DailyPrice = 400, ModelYear = "2020", Description = "Manuel, Renault Symbol"},
                new Car{CarId = 14, BrandId = 1, ColorId = 101, DailyPrice = 330, ModelYear = "2018", Description = "Yarı Otomatik, Volkswagen Polo"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=> c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }
}
