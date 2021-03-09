using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            UserManager userManager = new UserManager(new EfUserDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            bool cikis = true;

            while (cikis)
            {
                Console.WriteLine(
                    "Rent A Car \n---------------------------------------------------------------" +
                    "\n\n1.Add car\n" +
                    "2.Delete car\n" +
                    "3.Update car\n" +
                    "4.List of cars\n" +
                    "5.Detailed list of cars\n" +
                    "6.List of cars by brand Id\n" +
                    "7.List of cars by color Id\n" +
                    "8.List of car by car Id\n" +
                    "9.List of cars by price range" +
                    "10.List of cars by model year\n" +
                    "11.Add customer\n" +
                    "12.List of customers\n" +
                    "13.Add user\n" +
                    "14.List of users\n" +
                    "15.Rent a car\n" +
                    "16.Car delivery\n" +
                    "17.Car rental list\n" +
                    "18.Exit\n" +
                    "Which of the above operations do you want to perform?"
                    );

                int number = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n---------------------------------------------------------------\n");
                switch (number)
                {
                    case 1:
                        CarAddition(carManager, brandManager, colorManager);
                        break;
                    case 2:
                        GetAllCarDetails(carManager);
                        CarDeletion(carManager);
                        break;
                    case 3:
                        GetAllCarDetails(carManager);
                        CarUpdate(carManager);
                        break;
                    case 4:
                        GetAllCar(carManager);
                        break;
                    case 5:
                        GetAllCarDetails(carManager);
                        break;
                    case 6:
                        GetAllBrand(brandManager);
                        CarListByBrand(carManager);
                        break;
                    case 7:
                        GetAllColor(colorManager);
                        CarListByColor(carManager);
                        break;
                    case 8:
                        GetAllCarDetails(carManager);
                        CarById(carManager, brandManager, colorManager);
                        break;
                    case 9:
                        CarByDailyPrice(carManager, brandManager, colorManager);
                        break;
                    case 10:
                        GetAllCarDetails(carManager);
                        CarByModelYear(carManager, brandManager, colorManager);
                        break;
                    case 11:
                        GetAllUserList(userManager);
                        CustomerAddition(customerManager);
                        break;
                    case 12:
                        GetAllCustomerList(customerManager);
                        break;
                    case 13:
                        UserAddition(userManager);
                        break;
                    case 14:
                        GetAllUserList(userManager);
                        break;
                    case 15:
                        GetAllCarDetails(carManager);
                        GetAllCustomerList(customerManager);
                        RentalAddition(rentalManager);
                        break;
                    case 16:
                        ReturnRental(rentalManager);
                        break;
                    case 17:
                        GetAllRentalDetailList(rentalManager);
                        break;
                    case 18:
                        cikis = false;
                        Console.WriteLine("Logged out.");
                        break;
                }
            }
        }

        private static void GetAllRentalDetailList(RentalManager rentalManager)
        {
            Console.WriteLine("List of rented cars: \nId\tCar Name\tCustomer Name\tRent Date\tReturn Date");
            foreach (var rental in rentalManager.GetRentalDetails().Data)
            {
                Console.WriteLine($"{rental.RentalId}\t{rental.CarName}\t{rental.CustomerName}\t{rental.RentDate}\t{rental.ReturnDate}");
            }
        }

        private static void ReturnRental(RentalManager rentalManager)
        {
            Console.WriteLine("What is the car Id of the car that you have rented?");
            int carId = Convert.ToInt32(Console.ReadLine());
            var returnedRental = rentalManager.GetRentalDetails(I => I.CarId == carId);
            foreach (var rental in returnedRental.Data)
            {
                rental.ReturnDate = DateTime.Now;
                Console.WriteLine(returnedRental.Message);
            }
        }

        private static void RentalAddition(RentalManager rentalManager)
        {
            Console.WriteLine("Car Id: ");
            int carIdForAdd = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Customer Id: ");
            int customerIdForAdd = Convert.ToInt32(Console.ReadLine());

            Rental rentalForAdd = new Rental
            {
                CarId = carIdForAdd,
                CustomerId = customerIdForAdd,
                RentDate = DateTime.Now,
                ReturnDate = null,
            };
            Console.WriteLine(rentalManager.Add(rentalForAdd).Message);

        }

        private static void UserAddition(UserManager userManager)
        {
            Console.WriteLine("First Name: ");
            string userNameForAdd = Console.ReadLine();
            Console.WriteLine("Last Name: ");
            string userSurnameForAdd = Console.ReadLine();
            Console.WriteLine("Email Name: ");
            string userEmailForAdd = Console.ReadLine();
            Console.WriteLine("Password Name: ");
            string userPasswordSaltForAdd = Console.ReadLine();


            User userForAdd = new User
            {
                FirstName = userNameForAdd,
                LastName = userSurnameForAdd,
                Email = userEmailForAdd,
                PasswordSalt = userPasswordSaltForAdd[],

            };
            userManager.Add(userForAdd);
        }

        private static void GetAllCustomerList(CustomerManager customerManager)
        {
            Console.WriteLine("List of customers: \nId\tKullanıcı Id\tCustomer Name");
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine($"{customer.Id}\t{customer.UserId}\t{customer.CustomerName}");
            }
        }

        private static void CustomerAddition(CustomerManager customerManager)
        {
            Console.WriteLine("User Id: ");
            int userIdForAdd = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Customer Name: ");
            string customerNameForAdd = Console.ReadLine();

            Customer customerForAdd = new Customer
            {
                UserId = userIdForAdd,
                CustomerName = customerNameForAdd
            };
            customerManager.Add(customerForAdd);
        }

        private static void GetAllUserList(UserManager userManager)
        {
            Console.WriteLine("List Of Users: \nId\tFirst Name\tLast Name\tEmail\tPassword");
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine($"{user.Id}\t{user.FirstName}\t{user.LastName}\t{user.PasswordSalt}");
            }
        }

        private static void CarByModelYear(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("Which model year do you want to see the car? Please enter a year.");
            string modelYearForCarList = Console.ReadLine();
            Console.WriteLine($"\n\nColor Id'si {modelYearForCarList} olan arabalar: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
            foreach (var car in carManager.GetCarDetails(I => I.ModelYear == modelYearForCarList).Data)
            {
                Console.WriteLine($"{car.CarId}\t{car.ColorName}\t\t{car.BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Descriptions}");
            }
        }

        private static void CarByDailyPrice(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            decimal min = Convert.ToDecimal(Console.ReadLine());
            decimal max = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine($"\n\nDaily price range {min} ile {max} olan arabalar: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
            foreach (var car in carManager.GetCarDetails(I => I.DailyPrice >= min & I.DailyPrice <= max).Data)
            {
                Console.WriteLine($"{car.CarId}\t{car.ColorName}\t\t{car.BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Descriptions}");
            }
        }

        private static void CarById(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("Which car do you want to see? Please enter a Id number.");
            int carId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"\n\nId'si {carId} olan araba: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
            Car carById = carManager.GetById(carId).Data;
            Console.WriteLine($"{carById.Id}\t{colorManager.GetById(carById.ColorId).Data.ColorName}\t\t{brandManager.GetById(carById.BrandId).Data.BrandName}\t\t{carById.ModelYear}\t\t{carById.DailyPrice}\t\t{carById.Descriptions}");
        }

        private static void CarListByColor(CarManager carManager)
        {
            Console.WriteLine("Which color do you want to see your car? Please enter a Id number.");
            int colorIdForCarList = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"\n\nColor Id'si {colorIdForCarList} olan arabalar: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
            foreach (var car in carManager.GetCarDetails(I => I.ColorId == colorIdForCarList).Data)
            {
                Console.WriteLine($"{car.CarId}\t{car.ColorName}\t\t{car.BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Descriptions}");
            }
        }

        private static void CarListByBrand(CarManager carManager)
        {
            Console.WriteLine("Which brand do you want to see your car? Please enter a Id number.");
            int brandIdForCarList = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"\n\nBrand Id'si {brandIdForCarList} olan arabalar: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
            foreach (var car in carManager.GetCarDetails(I => I.BrandId == brandIdForCarList).Data)
            {
                Console.WriteLine($"{car.CarId}\t{car.ColorName}\t\t{car.BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Descriptions}");
            }
        }

        private static void CarUpdate(CarManager carManager)
        {
            Console.WriteLine("Car Id: ");
            int carIdForUpdate = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Brand Id: ");
            int brandIdForUpdate = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Color Id: ");
            int colorIdForUpdate = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Daily Price: ");
            decimal dailyPriceForUpdate = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Description : ");
            string descriptionForUpdate = Console.ReadLine();

            Console.WriteLine("Model Year: ");
            string modelYearForUpdate = Console.ReadLine();

            Car carForUpdate = new Car { Id = carIdForUpdate, BrandId = brandIdForUpdate, ColorId = colorIdForUpdate, DailyPrice = dailyPriceForUpdate, Descriptions = descriptionForUpdate, ModelYear = modelYearForUpdate };
            carManager.Update(carForUpdate);
        }

        private static void CarDeletion(CarManager carManager)
        {
            Console.WriteLine("With which Id do you want to delete the car? ");
            int carIdForDelete = Convert.ToInt32(Console.ReadLine());
            carManager.Delete(carManager.GetById(carIdForDelete).Data);
        }

        private static void CarAddition(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("Color List");
            GetAllColor(colorManager);

            Console.WriteLine("Brand List");
            GetAllBrand(brandManager);

            Console.WriteLine("\nBrand Id: ");
            int brandIdForAdd = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Color Id: ");
            int colorIdForAdd = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Daily Price: ");
            decimal dailyPriceForAdd = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Description : ");
            string descriptionForAdd = Console.ReadLine();

            Console.WriteLine("Model Year: ");
            string modelYearForAdd = Console.ReadLine();

            Car carForAdd = new Car { BrandId = brandIdForAdd, ColorId = colorIdForAdd, DailyPrice = dailyPriceForAdd, Descriptions = descriptionForAdd, ModelYear = modelYearForAdd };
            carManager.Add(carForAdd);
        }

        private static void GetAllCarDetails(CarManager carManager)
        {
            Console.WriteLine("Detailed car list:  \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine($"{car.CarId}\t{car.ColorName}\t\t{car.BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Descriptions}");
            }
        }

        private static void GetAllCar(CarManager carManager)
        {
            Console.WriteLine("Car list:  \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine($"{car.Id}\t{car.ColorId}\t\t{car.BrandId}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Descriptions}");
            }
        }

        private static void GetAllBrand(BrandManager brandManager)
        {
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine($"{brand.Id}\t{brand.BrandName}");
            }
        }

        private static void GetAllColor(ColorManager colorManager)
        {
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine($"{color.Id}\t{color.ColorName}");
            }
        }
    }
}
