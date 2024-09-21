namespace PartyfyApp.Common
{
    public static class EntityValidationConstants
    {
        public static class Category
        {
            public const int NameMaxLength = 30;
        }

        public static class TicketType
        {
            public const int TypeMaxLength = 10;
        }

        public static class Ticket
        {
            public const string PriceMaxValue = "250";
            public const string PriceMinValue = "15";

            public const int QuantityMaxValue = 2000;
            public const int QuantityMinValue = 0;

        }

        public static class Event
        {
            public const int TitleMaxLength = 50;
            public const int TitleMinLength = 10;

            public const int DescriptionMaxLength = 500;
            public const int DescriptionMinLength = 50;

            public const int LocationMaxLength = 150;
            public const int LocationMinLength = 30;

            public const int DJMaxLength = 20;
            public const int DJMinLength = 2;
        }      

        public static class Hoster
        {
            public const int PhoneNumberMaxLength = 15;
            public const int PhoneNumberMinLength = 7; 
        }
    }
}
