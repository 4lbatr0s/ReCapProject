using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string AllCarListed = "All cars are listed";
        public static string CarDeleted = "Car is deleted";
        public static string CarNotAdded = "Car couldn't added";
        public static string CarAdded = "Car added";
        public static string CarDetails = "Car details are brought";
        public static string CarUpdated = "Car is updated";
        public static string CarDoesNotExist = "Car doesn't exist";

        public static string BrandDeleted = "Brand is deleted";
        public static string AllBrandsListed = "All brands are listed";
        public static string BrandUpdated = "Brand is updated";

        public static string ColorAdded = "Color added";
        public static string ColorDeleted = "Color deleted";
        public static string AllColorListed = "All colors are listed";
        public static string ColorUpdated = "Color is updated";

        public static string UserAdded = "User is added";
        public static string UserDeleted = "User is deleted";
        public static string AllUsersListed = "All users are listed";
        public static string UserUpdated = "User is updated";
        public static string CustomerAdded = "Customer is added";
        public static string CustomerDeleted = "Customer is deleted";
        public static string AllCustomersListed = "All customers are listed";
        public static string CustomerUpdated = "Customer is updated";

        public static string InvalidRental = "Return date cannot be null";
        public static string RentalAdded = "Rental is added";
        public static string RentalDeleted = "Rental is deleted";
        public static string AllRentalsListed = "All rentals are listed";
        public static string RentalUpdated = "Rental is updated";

        public static string CarImageIsAdded = "Car image is added";
        public static string CarImageCountIsExceeded = "Image count for the car is exceeded.";
        public static string AllCarImagesAreListed = "All car images are listed";
        public static string CarImageIsUpdated = "Car image is updated";
        public static string CarImageIsDeleted = "Car image is deleted";

        public static string CarImageDoesNotExist = "Car image does not exist.";
        public static string CarImageDoesExists = "Car image does exist";

        public static string AuthorizationDenied = "Authorization is denied";

        public static string AccessTokenCreated = "Access token is created";

        public static User PasswordError { get; internal set; }
        public static string SuccessfulLogin { get; internal set; }
        public static User UserNotFound { get; internal set; }
        public static string UserAlreadyExists { get; internal set; }
        public static string UserRegistered { get; internal set; }
    }
}
