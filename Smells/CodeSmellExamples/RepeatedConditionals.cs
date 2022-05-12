
namespace Smells.CodeSmellExamples
{
    public abstract class RepeatedConditionalsBase
    {
        public abstract void RepeatedConditionals();
    }

    public class RepeatedConditionalsGood : RepeatedConditionalsBase
    {
        public override void RepeatedConditionals()
        {
            int a = 100;
            int b = 200;
            int c = 20;
            int d = 0;

            if (a * c > b) {
                d = b + a;
                b = d * c;
            }

            d = a * c + b;
        }
    }

    public class RepeatedConditionalsBad : RepeatedConditionalsBase
    {
        public override void RepeatedConditionals()
        {
            int a = 100;
            int b = 200;
            int c = 20;
            int d = 0;

            if (a * c > b) {
                d = b + a;
            }

            if (a * c > b) {
                b = d * c;
            }
            
            d = a * c + b;
        }
    }
}