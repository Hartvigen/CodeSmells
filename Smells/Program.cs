using System;
using Smells.CodeSmellExamples;

namespace Smells
{
    class Program
    {
        static void Main(string[] args)
        {
            DuplicateCode dup = new DuplicateCode();
            
            for (int x = 0; x < 100; x++)
             dup.sumElements();
        }
    }
}