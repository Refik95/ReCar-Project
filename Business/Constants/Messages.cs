﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Car added successfully";
        public static string CarDeleted = "Car deleted successfully";
        public static string CarUpdated = "Car updated sucessfully";
        public static string FailedCar = "Please enter the daily price part higher than 0.";

        public static string MainintenanceTime = "System is in maintenance";
        public static string ProductsListed = "Products are listed successfully";
        
        public static string BrandUptaded = "Brand updated sucessfully";
        public static string BrandDeleted = "Brand deleted successfully";
        public static string BrandAdded = "Brand added successfully";
        public static string FailedBrand = "Please enter a brand name that is longer than 2 chracters";

        public static string ColorDeleted = "Color deleted successfully";
        public static string ColorUpdated = "Color updated successfully";
        public static string ColorAdded = "Color added successfully";

        public static string AddedCustomer = "Customer added successfully";
        public static string DeletedCustomer = "Customer deleted successfully";
        public static string UpdatedCustomer = "Customer updated successfully";


        public static string AddedUser = "User added successfully";
        public static string DeletedUser = "User deleted successfully";
        public static string UpdatedUser = "User updated successfully";


        public static string AddedRental = "Car rental process was completed successfully";
        public static string DeletedRental = "Car rental process canceled";
        public static string UpdatedRental = "Car rental process updated";
        public static string FailedRentalAddOrUpdate = "You cannot rent this car as it has not yet been delivered.";
        public static string ReturnedRental = "The car you rented has been delivered.";

        public static string CarMaxImageNumber = "A car can have 5 maximum photos";
        public static string CarImageAdded = "Car Image added successfully";
        public static string CarImageDeleted = "Car Image deleted successfully";
        public static string CarImageUpdated = "Car Image updated successfully";
        public static string CarImagesListed = "Car Images listed successfully";
        public static string CarImageAlreadyExists = "Car image already exists";

        public static string AuthorizationDenied = "You don't have authorization.";
        public static string UserRegistered = "User registered.";

        public static string UserNotFound = "User not found.";
        public static string SuccessfulLogin = "Logged in successfully.";
        public static string PasswordError = "Wrong password!";
        public static string UserAlreadyExists = "User already exists!";
        public static string AccessTokenCreated = "Token created.";
    }
}
