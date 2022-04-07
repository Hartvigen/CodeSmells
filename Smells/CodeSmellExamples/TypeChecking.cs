using System;
using System.Runtime.CompilerServices;

namespace Smells.CodeSmellExamples
{
    public abstract class TypeCheckingBase
    {
        public abstract string getType();
    }

    class TypeCheckingTypeFieldBad : TypeCheckingBase
    {
        private Employee obj;
        private int SALESMAN = 0;
        private int ENGINEER = 1;
        private int DIRECTOR = 2;

        public override string getType()
        {
            // user defined getType method
            if (this.obj.getTypeField() == ENGINEER) return "Engineer";
            else if (this.obj.getTypeField() == SALESMAN) return "Salesman";
            else if (this.obj.getTypeField() == DIRECTOR) return "Director";
            else return "Error";
        }

        public TypeCheckingTypeFieldBad(Employee type)
        {
            this.obj = type;
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

    public class TypeCheckingRTTIBad : TypeCheckingBase
    {
        private Employee obj;
        public override string getType()
        {
            // built-in GetType method
            if (this.obj.GetType() == typeof(Engineer)) return "Engineer";
            else if (this.obj.GetType() == typeof(Salesman)) return "Salesman";
            else if (this.obj.GetType() == typeof(Director)) return "Director";
            else return "Error";
        }

        public TypeCheckingRTTIBad(Employee type)
        {
            obj = type;
        }
    }

    public class TypeCheckingGood : TypeCheckingBase
    {
        Employee state;
        public override string getType()
        {
            return state.getTypeString();
        }

        public TypeCheckingGood(Employee state)
        {
            this.state = state;
        }
    }
}