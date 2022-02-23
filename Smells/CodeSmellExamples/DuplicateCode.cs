using System;
using System.Collections;
using System.Collections.Generic;

namespace Smells.CodeSmellExamples
{
    public class DuplicateCode
    {
        private List<int> list_a = new List<int>() {1, 3, 5, 7, 9};
        private List<int> list_b = new List<int>() {2, 4, 6, 8, 10};
        private int sum_a = 0;
        private int sum_b = 0;

        //sums the first 4 elements of both list_a and list_b, finds the average of these values after
        public void sumElements()
        {

            for (int x = 0; x < 4; x++)
            {
                sum_a += list_a[x];
            }

            int average_a = sum_a / 4;
            
            for (int x = 0; x < 4; x++)
            {
                sum_b += list_b[x];
            }

            int average_b = sum_b / 4;
            
            Console.WriteLine("average a: " + average_a + "\naverage b: " + average_b);
        }
    }
}