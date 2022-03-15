namespace Smells.CodeSmellExamples
{
    public abstract class FeatureEnvyBase
    {
        public abstract string GetFullAddress();
    }

    class ContactInfo
    {
        public string StreetName = "Frederik Bajers Vej";
        public string City = "Aalborg";
        public string State = "Jylland";
        public string Zip = "9000";
        public string Country = "Danmark";
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
        public string Zip = "9000";
        public string Country = "Danmark";

        public override string GetFullAddress()
        {
            return streetName + ";" + city + ";" + Zip + ";" + state + ";" + Country;
        }
        
    }
}