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
        private bool salesman;
        private bool engineer;
        private int salary;

        public override string getType()
        {
            if (salesman == engineer)
                throw new Exception("Error, can't be both or neither");
            if (salesman)
                return "Salesman";
            if (engineer)
                return "Engineer";
            else
                return "Error";
        }

        public TypeCheckingBad(bool salesman, bool engineer)
        {
            this.salesman = salesman;
            this.engineer = engineer;
            salary = engineer ? 40000 : salesman ? 100000 : 2000;
        }
    }

    public abstract class Employee
    {
        private int salary;

        public abstract string getType();
    }

    public class Engineer : Employee
    {
        private int salary = 40000;

        public override string getType()
        {
            return "engineer";
        }
    }

    public class Salesman : Employee
    {
        private int salary = 100000;

        public override string getType()
        {
            return "salesman";
        }
    }

    public class TypeCheckingGood : TypeCheckingBase
    {
        private Employee obj;
        public override string getType()
        {
            return obj.getType();
        }

        public TypeCheckingGood(Employee type)
        {
            obj = type;
        }
    }
}