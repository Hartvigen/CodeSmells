namespace Smells.CodeSmellExamples
{
    public class SelfAssignment
    {
        public string SelfAssignmentGood()
        {
            string a = "";
            string x = "Played College Ball you know";
            string y = "Could have gone pro if I hadn't joined the navy";
            string z = "Nanomachines Son";

            a = z;
            x = x;
            y = y;
            z = z;

            return a + x + y + z;
        }

        public string SelfAssignmentSmell()
        {
            string a = "";
            string x = "Played College Ball you know ";
            string y = "Could have gone pro if I hadn't joined the navy ";
            string z = "Nanomachines Son ";


            a = z;
            
            return a + x + y + z;
        }
    }
}