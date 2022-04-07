namespace Smells.CodeSmellExamples
{
    public abstract class ParameterByValueBase
    {
        public abstract void ParameterByValue();
        public void Compute(int a, int b)
        {
            int c = a * b;

            if (a > b) c = c + b;

            b = b * 2;
        }
    }

    public class ParameterByValueGood : ParameterByValueBase
    {
        public override void ParameterByValue()
        {
            int a = 100;
            int b = 50;

            Compute(ref a, ref b);
        }

        public void Compute(ref int a, ref int b)
        {
            int c = a * b;

            if (a > b) c = c + b;

            b = b * 2;
        }
    }

    public class ParameterByValueBad : ParameterByValueBase
    {
        public override void ParameterByValue()
        {
            Compute(100, 50);
        }
    }
}