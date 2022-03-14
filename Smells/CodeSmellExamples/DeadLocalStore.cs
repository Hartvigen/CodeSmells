using System;

namespace Smells.CodeSmellExamples
{
    public class DeadLocalStore
    {
        public double DeadLocalStoreGood(double radius)
        {
            double pi = 3.14;
            
            return (pi * Math.Pow(2, radius));
        }
        
        public double DeadLocalStoreSmell(double radius)
        {
            double pi = 3.14;
            double notPi = 4.13;
            int cousinsAgeInMonths = 146;
            string niceGreeting = "Hellow World";
            
            return (pi * Math.Pow(2, radius));
        }
    }
}