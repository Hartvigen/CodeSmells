namespace Smells.CodeSmellExamples
{
    public abstract class ParameterByValueBase
    {
        public abstract void ParameterByValue();
        public int Compute(int a, int b)
        {
            int c = a * b;

            if (a > b) c = c + b;

            b = b * 2;

            return c;
        }
    }

    public class ParameterByValueGood : ParameterByValueBase
    {
        public override void ParameterByValue()
        {
            int a = 100;
            int b = 50;

            int c = Compute(ref a, ref b);
        }

        public int Compute(ref int a, ref int b)
        {
            int c = a * b;

            if (a > b) c = c + b;

            b = b * 2;

            return c;
        }
    }

    public class ParameterByValueBad : ParameterByValueBase
    {
        public override void ParameterByValue()
        {
            int a = 100;
            int b = 50;
            
            int c = Compute(a, b);
        }
    }
}