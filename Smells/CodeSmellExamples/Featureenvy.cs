namespace Smells.CodeSmellExamples
{
    public abstract class FeatureEnvyBase
    {
        public abstract string GetFullAddress();
    }

    class ContactInfo
    {
        public string streetName = "Frederik Bajers Vej";
        public string city = "Aalborg";
        public string state = "Jylland";
        public string zip = "9000";
        public string country = "Danmark";
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
            return _contactInfo.streetName + ";" + _contactInfo.city + "," + _contactInfo.zip + ";" + _contactInfo.state + ";" + _contactInfo.country;
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