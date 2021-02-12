using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
namespace ConsoleUI
{
   public class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();
            //ColorTest();
            CarDetailsTest();
        }
        /*private static void CarTest()
      {
          CarManager carManager = new CarManager(new EfCarDal());
          Console.WriteLine("--------List of Cars---------");
          foreach (var car in carManager.GetAll())
          {
              Console.WriteLine("Car ID: " + car.CarId + " Brand: " + car.BrandId + " Color: " + car.ColorId + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice + " Description: " + car.Description);
          }
          Console.WriteLine("-----------------------------");
          Console.WriteLine("--------List of Cars where BrandId=1---------");
          foreach (var car in carManager.GetCarsByBrandId(1))
          {
              Console.WriteLine("Car ID: " + car.CarId + " Description: " + car.Description);
          }
          Console.WriteLine("--------List of Cars where ColordId=3---------");
          foreach (var car in carManager.GetCarsByColorId(3))
          {
              Console.WriteLine("Car ID: " + car.CarId + " Brand: " + car.BrandId + " Description: " + car.Description);
          }
          Console.WriteLine("--------Add a car to DB---------");
          Car car1 = new Car { CarId = 6, BrandId = 4, ColorId = 3, ModelYear = 2020, DailyPrice = 700, Description = "Luxury Class" };
          //Car car2 = new Car { CarId = 7, BrandId = 3, ColorId = 1, ModelYear = 2015, DailyPrice = 300, Description = "E" };
          //Car car3 = new Car { CarId = 8, BrandId = 2, ColorId = 2, ModelYear = 2016, DailyPrice = 0, Description = "Economy Class" };
          carManager.Add(car1);
          //carManager.Add(car2);
          //carManager.Add(car3);
          foreach (var car in carManager.GetById(6))
          {
              Console.WriteLine("Car ID: " + car.CarId + " Brand: " + car.BrandId + " Color: " + car.ColorId + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice + " Description: " + car.Description);
          }
          /*foreach (var car in carManager.GetById(7))
          {
              Console.WriteLine("Car ID: " + car.CarId + " Brand: " + car.BrandId + " Color: " + car.ColorId + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice + " Description: " + car.Description);
          }
          foreach (var car in carManager.GetById(8))
          {
              Console.WriteLine("Car ID: " + car.CarId + " Brand: " + car.BrandId + " Color: " + car.ColorId + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice + " Description: " + car.Description);
          }
          Console.WriteLine("--------Update a car in DB---------");
          car1.BrandId =3; car1.ColorId = 2; car1.ModelYear = 2019; car1.DailyPrice = 400; car1.Description = "Economy Class";
          carManager.Update(car1);
          foreach (var car in carManager.GetById(6))
          {
              Console.WriteLine("Car ID: " + car.CarId + " Brand: " + car.BrandId + " Color: " + car.ColorId + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice + " Description: " + car.Description);
          }
          Console.WriteLine("--------Delete a car from DB---------");
          carManager.Delete(car1);
          foreach (var car in carManager.GetAll())
          {
              Console.WriteLine("Car ID: " + car.CarId + " Brand: " + car.BrandId + " Color: " + car.ColorId + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice + " Description: " + car.Description);
          }
      }*/

        /*private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine("--------List of Brands---------");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("Brand ID: " + brand.BrandId + " Brand Name: " + brand.BrandName);
            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine("--------List of Brand where BrandId=2---------");
            foreach (var brand in brandManager.GetById(2))
            {
                Console.WriteLine("Brand Name of Brand Id:2 is : " + brand.BrandName);
            }
            Console.WriteLine("--------Add a brand to DB---------");
            Brand brand1 = new Brand { BrandId = 5, BrandName = "Toyota"};
            brandManager.Add(brand1);
            foreach (var brand in brandManager.GetById(5))
            {
                Console.WriteLine("Brand ID: " + brand.BrandId + " Brand Name: " + brand.BrandName);
            }
            Console.WriteLine("--------Update a brand in DB---------");
            brand1.BrandName = "Volvo";
            brandManager.Update(brand1);
            foreach (var brand in brandManager.GetById(5))
            {
                Console.WriteLine("Brand ID: " + brand.BrandId + " Brand Name: " + brand.BrandName);
            }
            Console.WriteLine("--------Delete a brand from DB---------");
            brandManager.Delete(brand1);
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("Brand ID: " + brand.BrandId + " Brand Name: " + brand.BrandName);
            }
        }*/

        /*private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("--------List of Colors---------");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("Color ID: " + color.ColorId + " Color Name: " + color.ColorName);
            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine("--------List of Color where ColorId=3---------");
            foreach (var color in colorManager.GetById(3))
            {
                Console.WriteLine("Color Name of Color Id:3 is : " + color.ColorName);
            }
            Console.WriteLine("--------Add a color to DB---------");
            Color color1 = new Color { ColorId = 6, ColorName = "Magenta" };
            colorManager.Add(color1);
            foreach (var color in colorManager.GetById(6))
            {
                Console.WriteLine("Color ID: " + color.ColorId + " Color Name: " + color.ColorName);
            }
            Console.WriteLine("--------Update a color in DB---------");
            color1.ColorName = "Pink";
            colorManager.Update(color1);
            foreach (var color in colorManager.GetById(6))
            {
                Console.WriteLine("Color ID: " + color.ColorId + " Color Name: " + color.ColorName);
            }
            Console.WriteLine("--------Delete a color from DB---------");
            colorManager.Delete(color1);
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("Color ID: " + color.ColorId + " Color Name: " + color.ColorName);
            }
        }*/
        //CarManager carManager = new CarManager(new EfCarDal());
        //BrandManager brandManager = new BrandManager(new EfBrandDal());
        //ColorManager colorManager = new ColorManager(new EfColorDal());

        //Console.WriteLine("Brand of the cars with Id 1: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
        //foreach (var car in carManager.GetAllByBrandId(1))
        //{
        //    Console.WriteLine($"{car.CarId}\t{colorManager.GetById(car.ColorId).ColorName}\t\t{brandManager.GetById(car.BrandId).BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Descriptions}");
        //}

        //Console.WriteLine("\n\nColor of the cars with Id 2: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
        //foreach (var car in carManager.GetAllByColorId(2))
        //{
        //    Console.WriteLine($"{car.CarId}\t{colorManager.GetById(car.ColorId).ColorName}\t\t{brandManager.GetById(car.BrandId).BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Descriptions}");
        //}

        //Console.WriteLine("\n\nThe cars with Id 2 : \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
        //Car carById = carManager.GetById(2);
        //Console.WriteLine($"{carById.CarId}\t{colorManager.GetById(carById.ColorId).ColorName}\t\t{brandManager.GetById(carById.BrandId).BrandName}\t\t{carById.ModelYear}\t\t{carById.DailyPrice}\t\t{carById.Descriptions}");


        //Console.WriteLine("\n\nCars with a daily price range of 100 to 180: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
        //foreach (var car in carManager.GetByDailyPrice(100, 180))
        //{
        //    Console.WriteLine($"{car.CarId}\t{colorManager.GetById(car.ColorId).ColorName}\t\t{brandManager.GetById(car.BrandId).BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Descriptions}");
        //}

        //Console.WriteLine("\n");

        //carManager.Add(new Car { BrandId = 1, ColorId = 2, DailyPrice = -300, ModelYear = "2021", Descriptions = "Auto Diesel" });
        //brandManager.Add(new Brand { BrandName = "a" });
        private static void CarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();

            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Car Details: \n Brand Name: " + car.BrandName + "\n Color Name: " + car.ColorName + "\n Daily Price: " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            

        }

    }
}
