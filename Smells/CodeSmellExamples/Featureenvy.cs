namespace Smells.CodeSmellExamples
{

    class ContactInfo
    {
        public string StreetName = "Frederik Bajers Vej";
        public string City = "Aalborg";
        public string State = "Jylland";
        public string Zip = "9000";
        public string Country = "Danmark";
    }

    class User
    {
        private ContactInfo _contactInfo;

        User(ContactInfo contactInfo)
        {
            _contactInfo = contactInfo;
        }
        public string GetFullAddress(ContactInfo info)
        {
            return info.StreetName + ";" + info.City + "," + info.Zip + ";" + info.State + ";" + info.Country;
        }
    }

    class FullUser
    {
        private string city = "Aalborg";
        private string state = "Jylland";
        private string streetName = "Frederik Bajers Vej";

        public string GetFullAddress()
        {
            return streetName + ";" + city + ";" + state;
        }
        
    }
}