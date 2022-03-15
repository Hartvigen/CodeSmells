namespace Smells.CodeSmellExamples
{
    public abstract class ParameterByValueBase
    {
        public abstract void ParameterByValue();
    }

    public class ParameterByValueGood : ParameterByValueBase
    {
        public override void ParameterByValue()
        {
            throw new System.NotImplementedException();
        }
    }

    public class ParameterByValueBad : ParameterByValueBase
    {
        public override void ParameterByValue()
        {
            throw new System.NotImplementedException();
        }
    }
}