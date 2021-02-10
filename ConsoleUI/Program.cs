using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();
            BrandTest();
            ColorTest();

        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            /*colorManager.Add(new Entities.Concrete.Color { ColorName = "Blue" });
            colorManager.Update(new Entities.Concrete.Color { ColorId = 2, ColorName = "Silver" });
            colorManager.Delete(new Entities.Concrete.Color { ColorId = 4 });
            Console.WriteLine(colorManager.GetById(2).ColorName);*/
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            /*brandManager.Add(new Entities.Concrete.Brand { BrandName = "Kia" });
            brandManager.Update(new Entities.Concrete.Brand { BrandId = 4, BrandName = "BMW" });
            brandManager.Delete(new Entities.Concrete.Brand {BrandId = 3 });
            Console.WriteLine(brandManager.GetById(3).BrandName);*/
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            /*carManager.Add(new Entities.Concrete.Car { CarName = "BMW 320i", BrandId = 4, ColorId = 2, ModelYear = "2020", 
                                                       DailyPrice = 500, Description = "automatic" });
            carManager.Update(new Entities.Concrete.Car { Id = 4, CarName = "BMW 316i" });
            carManager.Delete(new Entities.Concrete.Car { Id = 1});
            Console.WriteLine(carManager.GetById(4));*/

            Car car = carManager.GetById(2);
            Console.WriteLine(car.Id + "/" + car.CarName + "/" + car.DailyPrice + "/" + car.Description +"\n");

            foreach (var c in carManager.GetByDailyPrice(150,340))
            {
                Console.WriteLine(c.CarName + "/"  + c.DailyPrice );
            }

            Console.WriteLine("\n");

            foreach (var c in carManager.GetCarDetails())
            {
                Console.WriteLine(c.CarName + "/" + c.BrandName + "/" + c.ColorName + "/" + c.DailyPrice );
            }

            Console.WriteLine("\n");

            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine(c.Id + "/" + c.BrandId + "/" + c.ColorId + "/" + c.DailyPrice + "/" + c.Description + "/" + c.ModelYear);
            }
        }
    }
}
