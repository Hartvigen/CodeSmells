namespace Smells.CodeSmellExamples
{
    public abstract class FeatureEnvyBase
    {
        public abstract string GetFullAddress();
    }

    class ContactInfo
    {
        private string streetName = "Frederik Bajers Vej";
        private string city = "Aalborg";
        private string state = "Jylland";
        private string zip = "9000";
        private string country = "Danmark";

        public string Country
        {
            get => country;
            set => country = value;
        }

        public string Zip
        {
            get => zip;
            set => zip = value;
        }

        public string State
        {
            get => state;
            set => state = value;
        }

        public string City
        {
            get => city;
            set => city = value;
        }

        public string StreetName
        {
            get => streetName;
            set => streetName = value;
        }
    }

    class FeatureEnvyBad : FeatureEnvyBase
    {
        private ContactInfo _contactInfo;

        public FeatureEnvyBad(ContactInfo contactInfo)
        {
            _contactInfo = contactInfo;
        }
        public override string GetFullAddress()
        {
            return _contactInfo.StreetName + ";" + _contactInfo.City + "," + _contactInfo.Zip + ";" + _contactInfo.State + ";" + _contactInfo.Country;
        }
    }

    class FeatureEnvyGood : FeatureEnvyBase
    {
        private string city = "Aalborg";
        private string state = "Jylland";
        private string streetName = "Frederik Bajers Vej";
        public string zip = "9000";
        public string country = "Danmark";

        public override string GetFullAddress()
        {
            return streetName + ";" + city + ";" + zip + ";" + state + ";" + country;
        }
        
    }
}