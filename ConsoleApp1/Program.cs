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
            CarTest();
            //AddingCarTest();
            //GetCarsByBrandIdTest();
            //GetCarByIdTest();
            //GetCarDetailsTest();
            //AddingBrandTest();
            //DeletingBrandTest();
            //UpdatingBrandTest();
            //GetBrandById();
            //GetBrandsTest();
            //UpdatingColorTest();
            //DeletingColorTest();
            //AddingColorTest();
        }



        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            var result = carManager.GetAll();

            if (result.Success == true)
            {

                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + "----" + car.BrandId);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void AddingCarTest()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            var result = carManager.Add(new Car { BrandId = 8, CarName = "Astra", ColorId = 8, DailyPrice = 380, ModelYear = 2014, Description = "Manuel" });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void DeletingColorTest()
        {
            ColourManager colorManager = new ColourManager(new EFColourDal());
            var result = colorManager.Delete(new Colour { ColourName = "Purple" });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void UpdatingColorTest()
        {
            ColourManager colourManager = new ColourManager(new EFColourDal());
            var result = colourManager.Update(new Colour { ColourId = 8, ColourName = "Pink" });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetBrandsTest()
        {
            BrandManager brandManager = new BrandManager(new EFBrandDal());
            var result = brandManager.GetAll();
            if (result.Success == true)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandId + "----" + brand.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetBrandById()
        {
            BrandManager brandManager = new BrandManager(new EFBrandDal());
            var result = brandManager.GetById(8);
            if (result.Success == true)
            {
                Console.WriteLine(result.Data.BrandId + "/" + result.Data.BrandName);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetCarsByBrandIdTest()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            var result = carManager.GetCarsByBrandId(2);
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName);
                Console.WriteLine(result.Message);
            }
        }

        private static void GetCarByIdTest()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            var result = carManager.GetById(10);
            if (result.Success == true)
            {
                Console.WriteLine(result.Data.CarName);
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void AddingColorTest()
        {
            ColourManager colourManager = new ColourManager(new EFColourDal());
            var result = colourManager.Add(new Colour { ColourName = "Purple" });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void DeletingBrandTest()
        {
            BrandManager brandManager = new BrandManager(new EFBrandDal());
            var result = brandManager.Delete(new Brand { BrandId = 9 });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void UpdatingBrandTest()
        {
            BrandManager brandManager = new BrandManager(new EFBrandDal());
            var result = brandManager.Update(new Brand { BrandId = 8, BrandName = "Opel" });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void AddingBrandTest()
        {
            BrandManager brandManager = new BrandManager(new EFBrandDal());
            var result = brandManager.Add(new Brand { BrandName = "Opel" });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }


        }
        private static void GetCarDetailsTest()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("{0}/{1}/{2}/{3}", car.BrandName, car.CarName, car.ColourName, car.DailyPrice);
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

    }
}
