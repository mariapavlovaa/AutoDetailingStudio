        using Microsoft.Data.SqlClient.DataClassification;
        using Microsoft.EntityFrameworkCore.Storage.Internal;

        namespace AutoDetailingStudio.Data.Models.Common;

        public static class EntityValidation
        {
                public static class User
                {
                        public const int FirstNameMaxLength = 50;
                        public const int FirstNameMinLength = 3;

                        public const int LastNameMaxLength = 50;
                        public const int LastNameMinLength = 3;
                }
               
                public static class Car
                {
                        public const int CarBrandMaxLength = 30;
                        public const int CarBrandMinLength = 2;
                        public const int RegistrationNumberMaxLength = 10;
                        public const int RegistrationNumberMinLength = 7;
                        

                }

                public static class Service
                {
                        public const int ServiceNameMaxLength = 100;
                        public const int ServiceNameMinlength = 3;
                        public const int ServiceDescriptionMaxLength = 1000;
                        public const int ServiceDescriptionMinLength = 20;
                        public const string ServicePriceMaxValue = "1000.00";
                        public const string ServicePriceMinValue = "0.01";
                        public const int DurationMinutesMinValue = 1;
                        public const int DurationMinutesMaxValue = 1440;
                        public const int ServicePricePrecision = 6;
                        public const int ServicePriceScale = 2;


                }
                
                public static class  Appointment
                {
                        public const int AppointmentNotesMaxLength = 1000;
                }
                
                public static class Subscription
                {
                        public const int SubscriptionNameMaxLength=100;
                        public const int SubscriptionNameMinLength = 10;
                        
                        public const int  SubscriptionDescriptionMaxLength=500;

                        public const string SubscriptionPriceMinValue = "0.01";
                        public const string SubscriptionPriceMaxValue = "3000.00";

                        public const string SubscriptionDiscountPercentMinValue = "0.1";
                        public const string SubscriptionDiscountPercentMaxValue = "0.99";

                        public const int SubscriptionPricePrecision = 6;
                        public const int SubscriptionPriceScale = 2;

                        public const int DiscountPercentPrecision = 5;
                        public const int DiscountPercentScale = 2;





                }
                public static class  UserSubscription
                {
                public const int SubscriptionDurationMonthMinValue = 3;
                public const int SubscriptionDurationMonthMaxValue = 12;
                public const string TotalPriceMinValue = "0.01";
                public const string TotalPriceMaxValue = "1000.00";
                public const int TotalPricePrecision = 18;
                public const int TotalPriceScale = 2;
                

                }
                
        }