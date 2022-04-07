using System;
using System.Runtime.CompilerServices;

namespace Smells.CodeSmellExamples
{
    public abstract class TypeCheckingBase
    {
        public abstract string getType();
    }

    class TypeCheckingBad : TypeCheckingBase
    {
        private Employee obj;
        private int SALESMAN = 0;
        private int ENGINEER = 1;
        private int DIRECTOR = 2;

        public override string getType()
        {
            // user defined getType method
            if (this.obj.getType() == ENGINEER) return "Engineer";
            else if (this.obj.getType() == SALESMAN) return "Salesman";
            else if (this.obj.getType() == DIRECTOR) return "Director";
            else return "Error";
        }

        public TypeCheckingBad(Employee type)
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

        public abstract int getType();
    }

    public class Engineer : Employee
    {
        public int _type;
        private int salary = 40000;

        public override int getType()
        {
            return this.ENGINEER;
        }
    }

    public class Salesman : Employee
    {
        private int salary = 100000;

        public override int getType()
        {
            return this.SALESMAN;
        }
    }

    public class Director : Employee
    {
        private int salary = 1000000000;

        public override int getType()
        {
            return this.DIRECTOR;
        }
    }

    public class TypeCheckingGood : TypeCheckingBase
    {
        private int SALESMAN = 0;
        private int ENGINEER = 1;
        private int DIRECTOR = 2;
        private Employee obj;
        public override string getType()
        {
            // built-in GetType method
            if (this.obj.GetType() == typeof(Engineer)) return "Engineer";
            else if (this.obj.GetType() == typeof(Salesman)) return "Salesman";
            else if (this.obj.GetType() == typeof(Director)) return "Director";
            else return "Error";
        }

        public TypeCheckingGood(Employee type)
        {
            obj = type;
        }
    }
}