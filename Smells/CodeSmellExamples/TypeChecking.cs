using System;
using System.Runtime.CompilerServices;

namespace Smells.CodeSmellExamples
{
    public class TypeChecking
    {
        
    }

    class EmployeeFull
    {
        private bool salesman;
        private bool engineer;
        private int salary;

        public string getType()
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

        EmployeeFull(bool salesman, bool engineer)
        {
            this.salesman = salesman;
            this.engineer = engineer;
            salary = engineer ? 40000 : salesman ? 100000 : 2000;
        }
    }

    abstract class Employee
    {
        private int salary;

        public abstract string GetType();
    }

    class Engineer : Employee
    {
        private int salary = 40000;

        public override string GetType()
        {
            return "engineer";
        }
    }

    class Salesman : Employee
    {
        private int salary = 100000;

        public override string GetType()
        {
            return "salesman";
        }
    }
}