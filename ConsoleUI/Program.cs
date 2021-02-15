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
                    "\n\n1.Add Car\n" +
                    "2.Delete Car\n" +
                    "3.Update Car\n" +
                    "4.List of Cars\n" +
                    "5.Detailed Listing of Cars\n" +
                    "6.Listing of Cars by Brand Id\n" +
                    "7.Listing of Cars by Color Id\n" +
                    "8.Listing by Car Id\n" +
                    "9.Listing of cars by price range\n" +
                    "10.Listing of cars by model year\n" +
                    "11.Add Customer\n" +
                    "12.List of Customers\n" +
                    "13.Add User\n" +
                    "14.List of Users\n" +
                    "15.Rent a Car\n" +
                    "16.Car Delivery\n" +
                    "17.Car Rental List\n" +
                    "18.Exit\n" +
                    "Which of the above do you want to do? ?"
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
                        Console.WriteLine("Logged Out");
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
            Console.WriteLine("What is the Id of the car that you have rented?");
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
            string userPasswordForAdd = Console.ReadLine();


            User userForAdd = new User
            {
                FirstName = userNameForAdd,
                LastName = userSurnameForAdd,
                Email = userEmailForAdd,
                Password = userPasswordForAdd

            };
            userManager.Add(userForAdd);
        }

        private static void GetAllCustomerList(CustomerManager customerManager)
        {
            Console.WriteLine("List of Customers: \nId\tUser Id\tCustomer Name");
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine($"{customer.CustomerId}\t{customer.UserId}\t{customer.CustomerName}");
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
            Console.WriteLine("List of Users: \nId\tFirst Name\tLast Name\tEmail\tPassword");
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine($"{user.UserId}\t{user.FirstName}\t{user.LastName}\t{user.Password}");
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

            Console.WriteLine($"\n\nCars with daily price range {min} of {max}: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
            foreach (var car in carManager.GetCarDetails(I => I.DailyPrice >= min & I.DailyPrice <= max).Data)
            {
                Console.WriteLine($"{car.CarId}\t{car.ColorName}\t\t{car.BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Descriptions}");
            }
        }

        private static void CarById(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("Which car do you want to see? Please write an ID number.");
            int carId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"\n\nId'si {carId} olan araba: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
            Car carById = carManager.GetById(carId).Data;
            Console.WriteLine($"{carById.CarId}\t{colorManager.GetById(carById.ColorId).Data.ColorName}\t\t{brandManager.GetById(carById.BrandId).Data.BrandName}\t\t{carById.ModelYear}\t\t{carById.DailyPrice}\t\t{carById.Descriptions}");
        }

        private static void CarListByColor(CarManager carManager)
        {
            Console.WriteLine("Which color do you want to see the car? Please write an Id number.");
            int colorIdForCarList = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"\n\nCars with {colorIdForCarList} color ID : \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
            foreach (var car in carManager.GetCarDetails(I => I.ColorId == colorIdForCarList).Data)
            {
                Console.WriteLine($"{car.CarId}\t{car.ColorName}\t\t{car.BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Descriptions}");
            }
        }

        private static void CarListByBrand(CarManager carManager)
        {
            Console.WriteLine("Which brand do you want to see the car? Please write an ID number.");
            int brandIdForCarList = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"\n\nCars with {brandIdForCarList} brand Id: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
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

            Car carForUpdate = new Car { CarId = carIdForUpdate, BrandId = brandIdForUpdate, ColorId = colorIdForUpdate, DailyPrice = dailyPriceForUpdate, Descriptions = descriptionForUpdate, ModelYear = modelYearForUpdate };
            carManager.Update(carForUpdate);
        }

        private static void CarDeletion(CarManager carManager)
        {
            Console.WriteLine("Which id do you want to delete the car? ");
            int carIdForDelete = Convert.ToInt32(Console.ReadLine());
            carManager.Delete(carManager.GetById(carIdForDelete).Data);
        }

        private static void CarAddition(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("Color Listesi");
            GetAllColor(colorManager);

            Console.WriteLine("Brand Listesi");
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
            Console.WriteLine("Detailed list of cars:  \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine($"{car.CarId}\t{car.ColorName}\t\t{car.BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Descriptions}");
            }
        }

        private static void GetAllCar(CarManager carManager)
        {
            Console.WriteLine("List of cars:  \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine($"{car.CarId}\t{car.ColorId}\t\t{car.BrandId}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Descriptions}");
            }
        }

        private static void GetAllBrand(BrandManager brandManager)
        {
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine($"{brand.BrandId}\t{brand.BrandName}");
            }
        }

        private static void GetAllColor(ColorManager colorManager)
        {
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine($"{color.ColorId}\t{color.ColorName}");
            }
        }
    }
}
