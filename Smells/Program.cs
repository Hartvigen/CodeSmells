using System;
using Smells.CodeSmellExamples;

namespace Smells
{
    class Program
    {
        static void Main(string[] args)
        {
            ContactInfo info = new ContactInfo();

            for (int x = 0; x < 100000000; x++)
            {
                FullUser envy = new FullUser();
                string y  = envy.GetFullAddress();
            }
        }
    }
}