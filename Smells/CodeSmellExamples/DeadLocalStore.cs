using System;

namespace Smells.CodeSmellExamples
{
    public abstract class DeadLocalStoreBase
    {
        public abstract double DeadLocalStore(double radius);
    }
    
    public class DeadLocalStoreGood : DeadLocalStoreBase
    {
        public override double DeadLocalStore(double radius)
        {
            double pi = 3.14;
            
            return (pi * Math.Pow(2, radius));
        }
    }

    public class DeadLocalStoreBad : DeadLocalStoreBase
    {
        public override double DeadLocalStore(double radius)
        {
            double pi = 3.14;
            double notPi = 4.13;
            int cousinsAgeInMonths = 146;
            string niceGreeting = "Hellow World";
            
            return (pi * Math.Pow(2, radius));
        }
    }
}