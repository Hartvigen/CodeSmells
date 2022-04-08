namespace Smells.CodeSmellExamples
{
    public abstract class InLineBase
        {
            public abstract void InLine();
        }

        public class InLineBad : InLineBase
        {

            private int WackyComputations(int age)
            {
                age += 2;
                age = age * 7;
                age -= 4;
                age = age / 7;
                age = age + 1;
                
                return age;
            }
            
            public override void InLine()
            {
                int thomasAge = 15;
                int sophieAge = 32;

                thomasAge = WackyComputations(thomasAge);
                sophieAge = WackyComputations(sophieAge);
            }
        }

        public class InLineGood : InLineBase
        {
            public override void InLine()
            {
                int thomasAge = 15;
                int sophieAge = 32;
                
                thomasAge += 2;
                thomasAge = thomasAge * 7;
                thomasAge -= 4;
                thomasAge = thomasAge / 7;
                thomasAge = thomasAge + 1;
                
                sophieAge += 2;
                sophieAge = sophieAge * 7;
                sophieAge -= 4;
                sophieAge = sophieAge / 7;
                sophieAge = sophieAge + 1;
            }
        }
}