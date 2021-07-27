using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        // Car Messages Begin
        public static string CarAdded = "Car added successfully";

        public static string CarUpdated = "Car updated successfully";

        public static string CarDeleted = "Car deleted successfully";

        public static string CarNameInvalid = "Invalid car name";

        public static string CarDailyPriceInvalid = "Invalid car daily price";

        // Car Messages End

        // Brand Messages Start 
        public static string BrandAdded = "Brand added successfully";

        public static string BrandNameInvalid = "Brand added successfully";

        public static string BrandUpdated = "Brand updated successfully";

        public static string BrandDeleted = "Brand deleted successfully";

        public static string BrandCannotBeFound = "Brand cannot be found";
        // Brand Messages End 

        // Color Messages Start 
        public static string ColorAdded = "Color added successfully";

        public static string ColorNameInvalid = "Invalid color name";

        public static string ColorUpdated = "Color updated successfully";

        public static string ColorDeleted = "Color deleted successfully";

        public static string ColorCannotBeFound = "Color cannot be found";

        public static string ColorsListed = "Colors are listed";
        // Color Messages End 

        // Customer Messages Start 
        public static string CustomerAdded = "Customer added successfully";

        public static string CustomerUpdated = "Customer updated successfully";

        public static string CustomerDeleted = "Customer deleted successfully";
        // Customer Messages End 

        // Rental Messages Start 
        public static string RentalAdded = "Rental added successfully";

        public static string RentalUpdated = "Rental updated successfully";

        public static string RentalDeleted = "Rental deleted successfully";
        // Rental Messages End 

        // User Messages Start 
        public static string UserAdded = "User added successfully";

        public static string UserUpdated = "User updated successfully";

        public static string UserDeleted = "User deleted successfully";

        public static string UserNotFound = "User Not Found";

        public static string UserAlreadyExists = "User Already Exists";

        public static string UserRegistered = "User Registered";

        // User Messages End 

        // Car Image Messages Start
        public static string CarImageAdded = "Car Image added successfully";

        public static string CarImageUpdated = "Car Image updated successfully";

        public static string CarImageDeleted = "Car Image deleted successfully";

        public static string CarImageCountLimitExceeded = "Car Image Count Limit Exceeded";
        
        public static string CarImageDoesNotExist = "Car Image Does Not Exist";
        // Car Image Messages End

        // Authorization and Authentication Messages Start
        public static string AccessTokenCreated = "Access Token Created";

        public static string PasswordError = "Incorrect Password";

        public static string SuccessfulLogin = "Successful Login";
        // Authorization and Authentication Messages End


    }
}
