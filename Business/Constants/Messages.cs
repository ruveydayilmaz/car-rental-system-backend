using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Car successfully added";
        public static string CarNameInvalid = "Car name must be min 2 characters";
        public static string CarDeleted = "Car successfully deleted";
        public static string CarUpdated = "Car successfully updated";
        public static string MaintenanceTime = "in maintenance";
        public static string CarsListed = "all cars are listed";
        public static string BrandAdded = "Brand successfully added";
        public static string BrandUpdated = "Brand successfully updated";
        public static string BrandDeleted = "Brand successfully deleted";
        public static string BrandNameInvalid = "Brand name must be min 2 characters";
        public static string ColorAdded = "Color successfully added";
        public static string ColorDeleted = "Color successfully deleted";
        public static string ColorUpdated = "Color successfully updated";
        public static string UserAdded = "User successfully added";
        public static string UserDeleted = "User successfully deleted";
        public static string UserUpdated = "User successfully updated";
        public static string CustomerAdded = "Customer successfully added";
        public static string CustomerDeleted = "Customer successfully deleted";
        public static string CustomerUpdated = "Customer successfully updated";
        public static string RentalAdded = "Rental succesfully added";
        public static string RentalDeleted = "Rental successfully deleted";
        public static string RentalUpdated = "Rental successfully updated";
        public static string CarNotAvailable = "Car is not available";
        public static string ImageAboveMax = "Image number is above 5 ";
        public static string ImagesNotFound = "Images not found";
        public static string CarImageAdded = "Car image succesfully added";
        public static string CarImageUpdated = "Car image succesfully updated";
        public static string CarImageDeleted = "Car image succesfully deleted";
        public static string CarImageAddingError = "error";
        public static string AuthorizationDenied = "Authorization denied";
        public static string UserRegistered = "User successfully registered";
        public static string UserNotFound = "User not found";
        public static string PasswordError = "Password error";
        public static string SuccessfulLogin = "Successful login";
        public static string UserAlreadyExists = "User already exists";
        public static string AccessTokenCreated = "Access token created";
        public static string TransactionAborted = "Transaction was aborted";
        public static string Added = "added";
    }
}
