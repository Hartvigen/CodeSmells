
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
            throw new System.NotImplementedException();
        }
    }

    public class RepeatedConditionalsBad : RepeatedConditionalsBase
    {
        public override void RepeatedConditionals()
        {
            throw new System.NotImplementedException();
        }
    }
}