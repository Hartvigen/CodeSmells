using System;

namespace Smells.CodeSmellExamples
{
    public abstract class DeadCodeBase
    {
        public abstract void Run();
    }

    public class DeadCodeGood : DeadCodeBase
    {
        public override void Run()
        {
            int a = 5;
            int b = 10;

            double c = Math.Sqrt(Math.Pow(2, a) + Math.Pow(2, b));

            // make sure eval is done in good version as well for fairness
            if (a > b) c = c * 2;
        }
    }

    public class DeadCodeBad : DeadCodeBase
    {
        public override void Run()
        {
            int a = 5;
            int b = 10;

            double c = Math.Sqrt(Math.Pow(2, a) + Math.Pow(2, b));

            // try force loading these methods into memory without executing
            if (a > b)
            {
                int fib = Fibonacci(10);
                int fac = Factorial(5);
                bool prime = isPrime(400);
                double sqArea = SquareArea(40);
                double cArea = CircleArea(10);
                double cylVol = VolumeCylinder(10, 40);
            }
        }

        public int Fibonacci(int n)
        {
            if (n == 0 || n == 1) return n;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        public int Factorial(int n)
        {
            if (n == 1) return n;
            return Factorial(n - 1) * n;
        }

        public bool isPrime(int n)
        {
            if (n <= 1) return false;

            for (int i = 2; i <= n; i++) 
                if (n % i == 0) return false;
            
            return true;
        }

        public double SquareArea(int side)
        {
            return Math.Pow(2, side);
        }

        public double CircleArea(int r)
        {
            return Math.PI * Math.Pow(2, r);
        }

        public double VolumeCylinder(int r, int h)
        {
            return Math.PI * Math.Pow(2, r) * h;
        }
    }
}