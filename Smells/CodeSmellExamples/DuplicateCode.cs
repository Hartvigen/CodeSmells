using System;
using System.Collections;
using System.Collections.Generic;

namespace Smells.CodeSmellExamples
{
    public abstract class DuplicateCodeBase
    {
        public abstract void SumElements();
    }

    public class DuplicateCodeBad : DuplicateCodeBase
    {
        private List<int> list_a = new List<int>() {1, 3, 5, 7, 9};
        private List<int> list_b = new List<int>() {2, 4, 6, 8, 10};
        public override void SumElements()
        {
            int sum_a = 0;
            int sum_b = 0;

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
            
            //Console.WriteLine("average a: " + average_a + "\naverage b: " + average_b);
        }
    }

    public class DuplicateCodeGood : DuplicateCodeBase
    {
        private List<int> list_a = new List<int>() {1, 3, 5, 7, 9};
        private List<int> list_b = new List<int>() {2, 4, 6, 8, 10};
        public override void SumElements()
        {
            int sum_a = 0;
            int sum_b = 0;
            
            for (int x = 0; x < 4; x++)
            {
                sum_a += list_a[x];
                sum_b += list_b[x];
            }

            int average_a = sum_a / 4;
            int average_b = sum_b / 4;
            
            //Console.WriteLine("average a: " + average_a + "\naverage b: " + average_b);
        }
    }
}