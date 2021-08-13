using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //GetCarsByBrandIdTest();
            //GetCarByIdTest();
            //AddingAndListingBrandTest();
            //UpdatingAndListingBrandTest();
            //DeletingBrandTest();
            //RUDOperationsOnColorTest();
            //GetCarDetailsTest();
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
        private static void GetCarsByBrandIdTest()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(car.CarName);
            }
        }

        private static void GetCarByIdTest()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            Console.WriteLine(carManager.GetById(2).CarName);
        }

        private static void RUDOperationsOnColorTest()
        {
            ColourManager colourManager = new ColourManager(new EFColourDal());
            colourManager.Add(new Colour { ColourName = "Purple" });
            foreach (var colour in colourManager.GetAll())
            {
                Console.WriteLine(colour.ColourName);
            }
            colourManager.Update(new Colour { ColourId = 6, ColourName = "Pink" });
            foreach (var colour in colourManager.GetAll())
            {
                Console.WriteLine(colour.ColourName);
            }
            colourManager.Delete(new Colour { ColourId = 6 });
            foreach (var colour in colourManager.GetAll())
            {
                Console.WriteLine(colour.ColourName);
            }
        }

        private static void DeletingBrandTest()
        {
            BrandManager brandManager = new BrandManager(new EFBrandDal());
            brandManager.Delete(new Brand { BrandId = 7 });
        }

        private static void UpdatingAndListingBrandTest()
        {
            BrandManager brandManager = new BrandManager(new EFBrandDal());
            brandManager.Update(new Brand { BrandId = 7, BrandName = "Opell" });
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void AddingAndListingBrandTest()
        {
            BrandManager brandManager = new BrandManager(new EFBrandDal());
            brandManager.Add(new Brand { BrandName = "Opel" });
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }

        }
        private static void GetCarDetailsTest()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("{0}/{1}/{2}/{3}", car.BrandName, car.CarName, car.ColourName, car.DailyPrice);
            }
        }

    }
}
