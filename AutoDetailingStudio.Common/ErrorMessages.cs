namespace AutoDetailingStudio.Common;

public static class ErrorMessages
{
    public static class  Appointment
    {
        public const string CreateFailed =
            "Unable to create appointment.";
        public const string CarRequired =
                        "Please select a car.";
                
                    public const string AppointmentDateRequired =
                        "Please select a date and time.";
                
                    public const string AppointmentDateInPast =
                        "Appointment date and time must be in the future.";
                    
    }
    public static class AdminAppointment
    {
        public const string InvalidStatus =
            "Invalid appointment status.";

        public const string ChangeStatusFailed =
            "Unable to change appointment status.";

        public const string DeleteFailed =
            "Unable to delete appointment.";
    }
    public static class Car
    {
            public const string BrandRequired =
                "Please enter the car brand.";
        
            public const string BrandLength =
                "Car brand must be between {2} and {1} characters.";
        
            public const string RegistrationNumberRequired =
                "Please enter the registration number.";
        
            public const string RegistrationNumberLength =
                "Registration number must be between {2} and {1} characters.";
        
            public const string VehicleTypeInvalid =
                "Please select a valid vehicle type.";
    }
    
    
    public static class  Service
    {
        public const string NameRequired =
                    "Please enter a service name.";
        
                public const string NameLength =
                    "Service name must be between {2} and {1} characters.";
        
                public const string DescriptionRequired =
                    "Please enter a service description.";
        
                public const string DescriptionLength =
                    "Service description must be between {2} and {1} characters.";
        
                public const string PriceRange =
                    "Service price must be between {1} and {2}.";
        
                public const string DurationRange =
                    "Service duration must be between {1} and {2} minutes.";
        
                public const string ImageUrlLength =
                    "Image URL cannot exceed {1} characters.";
    }
    
    public static class Subscription
    {
        public const string NameRequired =
            "Please enter a subscription name.";

        public const string NameLength =
            "Subscription name must be between {2} and {1} characters.";

        public const string DescriptionLength =
            "Subscription description cannot exceed {1} characters.";

        public const string PriceRange =
            "Subscription price must be between {1} and {2}.";

        public const string DiscountRange =
            "Subscription discount must be between {1} and {2}.";
    }
   
        
    
}