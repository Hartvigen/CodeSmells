namespace Smells.CodeSmellExamples
{

    class ContactInfo
    {
        public string GetStreetName()
        {
            return "Frederik Bajers Vej";
        }
        public string GetCity()
        {
            return "Aalborg";
        }
        public string GetState()
        {
            return "Jylland";
        }
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
            string city = info.GetCity();//1
            string state = info.GetState();//2
            string streetName = info.GetStreetName();//3
            return streetName + ";" + city + ";" + state;
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