﻿using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string BrandAdded = "Brand added.";
        public static string ShortName = "Given name is too short, provide a longer name.";
        public static string MaintenanceTime = "System under maintenance, try again later";
        public static string ProductsListed = "Products Listed";
        public static string BrandsListed = "Brands Listed";
        public static string BrandDeleted = "Brand Deleted";
        public static string BrandUpdated = "Brand Updated";
        public static string CarDeleted = "Car Deleted";
        public static string CarAdded = "Car Added";
        public static string NoFreeCarRent = "Daily price must be greater than 0";
        public static string InvalidBodyName = "Body name invalid";
        public static string CarUpdated = "Car Updated";
        public static string ColorAdded = "Color Added";
        public static string ColorRemoved = "Color Removed";
        public static string ColorUpdated = "Color Updated";
        public static string RentAdded = "Rent Added";
        public static string RentDeleted = "Rent Deleted.";
        public static string RentUpdated = "Rent Updated";
        public static string UserAdded = "User Added to database";
        public static string UserUpdated = "User Updated";
        public static string UserDeleted = "User Deleted";
        public static string NoSuchBrand = "No such brand in the database";
        public static string NoSuchRent = "No such rent in the database";
        public static string NoSuchUser = "No such user in the database";
        public static string NoSuchCustomer = "No such customer in the database";
        public static string NoSuchColor = "No such color in the database";
        public static string InvalidCarPlate = "Invalid car plate";
        public static string ImageAdded = "Image added";
        public static string ImageDeleted = "Image deleted";
        public static string ImageUpdated = "Image updated";
        public static string ImageSavedAndAdded = "New image added";
        public static string MaxImageForACar = "Maximum imges for a car reached.";
        public static string ImageEntryNotDeletedFromDatabase = "Database Error: Couldn't delete database image entry";
        public static string NotValidImageFileType = " file type is not supported, supported types: .jpg, .jpeg and .png";
        public static string MultipleErrors = "Multiple errors occured.";
        public static string AuthorizationDenied = "Authorization Denied";
        internal static string AccesstokenCreated;
        internal static string UserAlreadyExists;
        internal static User UserNotFound;
        internal static User PasswordError;
        internal static string SuccessfulLogin;
        internal static string UserRegistered;
    }
}
