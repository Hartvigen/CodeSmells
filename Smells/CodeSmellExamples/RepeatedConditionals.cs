
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

            if (a * c > b) {
                b = b + a;
                b = b * c;
            }

            a = a * c + b;
        }
    }

    public class RepeatedConditionalsBad : RepeatedConditionalsBase
    {
        public override void RepeatedConditionals()
        {
            int a = 100;
            int b = 200;
            int c = 20;

            if (a * c > b) {
                b = b + a;
            }

            a = a * c + b;

            if (a * c > b) {
                b = b * c;
            }
        }
    }
}