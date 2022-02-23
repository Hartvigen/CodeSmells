using System;
using Smells.CodeSmellExamples;

namespace Smells
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DuplicateCode dup = new DuplicateCode();
            
            dup.sumElements();
        }
    }
}