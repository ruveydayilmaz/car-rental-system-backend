using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            Console.WriteLine("ID\t\tBRAND ID\t\tCOLOR ID\t\tDAILY PRICE\t\tMODEL YEAR\t\tDESCRIPTION");

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + "\t\t  " + car.BrandId + "\t\t\t  " + car.ColorId + "\t\t\t   " + car.DailyPrice + "\t\t\t  " + car.ModelYear + "\t\t\t" + car.Description);
            }

        }
    }
}
