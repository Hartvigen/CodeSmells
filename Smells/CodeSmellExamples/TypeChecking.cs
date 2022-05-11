using System;
using System.Runtime.CompilerServices;

namespace Smells.CodeSmellExamples
{
    public abstract class TypeCheckingBase
    {
        private Employee obj;
        public abstract string getType();
        public abstract void SetObj(Employee newObj);
    }

    class TypeCheckingTypeFieldBadIfElse : TypeCheckingBase
    {
        private Employee obj { get; set; }
        private const int SALESMAN = 0;
        private const int ENGINEER = 1;
        private const int DIRECTOR = 2;

        public override string getType()
        {
            // user defined getType method
            if (this.obj.getTypeField() == ENGINEER) return "Engineer";
            else if (this.obj.getTypeField() == SALESMAN) return "Salesman";
            else if (this.obj.getTypeField() == DIRECTOR) return "Director";
            else return "Error";
        }
        
        public override void SetObj(Employee newObj)
        {
            obj = newObj;
        }
    }
    
    class TypeCheckingTypeFieldBadSwitch : TypeCheckingBase
    {
        private Employee obj { get; set; }
        private const int SALESMAN = 0;
        private const int ENGINEER = 1;
        private const int DIRECTOR = 2;

        public override string getType()
        {
            // user defined getType method
            switch (this.obj.getTypeField())
            {
                case ENGINEER:
                    return "Engineer";
                case SALESMAN:
                    return "Salesman";
                case DIRECTOR:
                    return "Director";
                default:
                    return "Error";
            }
        }
        
        public override void SetObj(Employee newObj)
        {
            obj = newObj;
        }
    }

    public abstract class Employee
    {
        public int SALESMAN = 0;
        public int ENGINEER = 1;
        public int DIRECTOR = 2;
        private int salary;

        public abstract int getTypeField();
        public abstract string getTypeString();
    }

    public class Engineer : Employee
    {
        public int _type;
        private int salary = 40000;

        public override int getTypeField()
        {
            return this.ENGINEER;
        }

        public override string getTypeString()
        {
            return "Engineer";
        }
    }

    public class Salesman : Employee
    {
        private int salary = 100000;

        public override int getTypeField()
        {
            return this.SALESMAN;
        }

        public override string getTypeString()
        {
            return "Salesman";
        }
    }

    public class Director : Employee
    {
        private int salary = 1000000000;

        public override int getTypeField()
        {
            return this.DIRECTOR;
        }

        public override string getTypeString()
        {
            return "Director";
        }
    }

    public class TypeCheckingRTTIBadInstanceOf : TypeCheckingBase
    {
        private Employee obj { get; set; }
        public override string getType()
        {
            // built-in GetType method
            if (obj is Engineer) return "Engineer";
            else if (obj is Salesman) return "Salesman";
            else if (obj is Director) return "Director";
            else return "Error";
        }
        
        public override void SetObj(Employee newObj)
        {
            obj = newObj;
        }
    }
    
    public class TypeCheckingRTTIBadGetClass : TypeCheckingBase
    {
        private Employee obj { get; set; }
        public override string getType()
        {
            // built-in GetType method
            if (obj.GetType() == typeof(Engineer)) return "Engineer";
            else if (obj.GetType() == typeof(Salesman)) return "Salesman";
            else if (obj.GetType() == typeof(Director)) return "Director";
            else return "Error";
        }
        
        public override void SetObj(Employee newObj)
        {
            obj = newObj;
        }
    }

    public class TypeCheckingGood : TypeCheckingBase
    {
        private Employee obj { get; set; }

        public override string getType()
        {
            return obj.getTypeString();
        }

        public override void SetObj(Employee newObj)
        {
            obj = newObj;
        }
    }
}