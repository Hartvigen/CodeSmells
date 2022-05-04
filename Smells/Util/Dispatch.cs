using System;
using allSmells;
using Smells.CodeSmellExamples;
using Smells.CodeSmellConstants;
using TypeCheckingBase = Smells.CodeSmellExamples.TypeCheckingBase;
using TypeCheckingGood = Smells.CodeSmellExamples.TypeCheckingGood;

namespace Smells.CodeSmellDispatch
{
    public class Dispatcher
    {
        public void DispatchSuperSmell(string[] args)
        {
            int iterations = 500; //500
            
            bool typeChecking = false,
                    inLine = false,
                    repeatCond = false,
                    deadLocalStore = false,
                    duplicateCode = false,
                    shortCircuit = false,
                    featureEnvy = false,
                    paramByValue = false,
                    selfAssignment = false,
                    redundantStorage = false,
                    deadCode = false;

            //Set given args to true so they are ran in the super smell
            foreach (var arg in args)
            {
                switch (arg)
                {
                    case "dead-local-store":
                        deadLocalStore = true;
                        break;
                    case "duplicate-code":
                        deadLocalStore = true;
                        break;
                    case "feature-envy":
                        featureEnvy = true;
                        break;
                    case "parameter-by-value":
                        paramByValue = true;
                        break;
                    case "repeated-conditionals":
                        repeatCond = true;
                        break;
                    case "self-assignment":
                        selfAssignment = true;
                        break;
                    case "short-circuit":
                        shortCircuit = true;
                        break;
                    case "type-checking":
                        typeChecking = true;
                        break;
                    case "dead-code":
                        deadCode = true;
                        break;
                    case "redundant-data-storage":
                        redundantStorage = true;
                        break;
                    case "in-line":
                        inLine = true;
                        break;
                }
            }

            Console.WriteLine("Starting super smell");
            for (int i = 0; i < iterations; i++) SuperSmell.run(typeChecking, inLine, repeatCond, deadLocalStore, duplicateCode, shortCircuit, featureEnvy, paramByValue, selfAssignment, redundantStorage, deadCode);
            Console.WriteLine("Done");
        }
        public void DispatchCodeSmell(string smell, string variant)
        {
            switch (smell)
            {
                case "dead-local-store":
                    RunDeadLocalStore(variant);
                    break;
                case "duplicate-code":
                    RunDuplicateCode(variant);
                    break;
                case "feature-envy":
                    RunFeatureEnvy(variant);
                    break;
                case "god-class":
                    RunGodClass(variant);
                    break;
                case "long-method":
                    RunLongMethod(variant);
                    break;
                case "parameter-by-value":
                    RunParameterByValue(variant);
                    break;
                case "repeated-conditionals":
                    RunRepeatedConditionals(variant);
                    break;
                case "self-assignment":
                    RunSelfAssignment(variant);
                    break;
                case "short-circuit":
                    RunShortCircuit(variant);
                    break;
                case "type-checking-type-field":
                    RunTypeCheckingTypeField(variant);
                    break;
                case "type-checking-rtti":
                    RunTypeCheckingRTTI(variant);
                    break;
                case "dead-code":
                    RunDeadCode(variant);
                    break;
                case "redundant-data-storage":
                    RunRedundantDataStorage(variant);
                    break;
                case "in-line":
                    RunInLineMethod(variant);
                    break;
                default:
                    Console.WriteLine("Error: argument \"" + smell + "\" not recognized, please try again.");
                    Console.WriteLine("Available arguments are:");
                    Console.WriteLine("{ " + String.Join(", ", CodeSmellConstants.Constants.CODE_SMELL_CHOICES) + " }");
                    break;
            }
        }

        private void RunDeadLocalStore(string variant)
        {
            int iterations = 200000000; // 200M

            DeadLocalStoreBase LocalStore;
            if (variant == "bad") LocalStore = new DeadLocalStoreBad();
            else LocalStore = new DeadLocalStoreGood();
            
            Console.WriteLine("Running code smell Dead Local Store, variant " + variant);
            for (int i = 0; i < iterations; i++) LocalStore.DeadLocalStore(100);
            Console.WriteLine("Done");
        }

        private void RunDuplicateCode(string variant)
        {
            int iterations = 100000000; // 100M

            DuplicateCodeBase Duplicate;
            if (variant == "bad") Duplicate = new DuplicateCodeBad();
            else Duplicate = new DuplicateCodeGood();

            Console.WriteLine("Running code smell Duplicate Code, variant " + variant);
            for (int i = 0; i < iterations; i++) Duplicate.SumElements();
            Console.WriteLine("Done");
        }

        private void RunFeatureEnvy(string variant)
        {
            int iterations = 50000000; // 50M

            FeatureEnvyBase Envy;
            if (variant == "bad")
            {
                ContactInfo Info = new ContactInfo();
                Envy = new FeatureEnvyBad(Info);
            }
            else Envy = new FeatureEnvyGood();

            Console.WriteLine("Running code smell Feature Envy, variant " + variant);
            for (int i = 0; i < iterations; i++) Envy.GetFullAddress();
            Console.WriteLine("Done");
        }

        private void RunGodClass(string variant)
        {
            int iterations = 5000000; // 5M

            GodClassBase GodClass;
            if (variant == "bad") GodClass = new GodClassBad();
            else GodClass = new GodClassGood();
            
            Console.WriteLine("Running code smell God Class, variant " + variant);
            for (int i = 0; i < iterations; i++) GodClass.GetCandidateInfo();
            Console.WriteLine("Done");
        }

        private void RunLongMethod(string variant)
        {
            int iterations = 5000000; // 5M

            LongMethodBase LongMethod;
            if (variant == "bad") LongMethod = new LongMethodBad();
            else LongMethod = new LongMethodGood();

            Console.WriteLine("Running code smell Long Method, variant " + variant);
            for (int i = 0; i < iterations; i++) LongMethod.Compute();
            Console.WriteLine("Done");
        }

        private void RunParameterByValue(string variant)
        {
            int iterations = 300000000; // 300M

            ParameterByValueBase ParamByVal;
            if (variant == "bad") ParamByVal = new ParameterByValueBad();
            else ParamByVal = new ParameterByValueGood();

            Console.WriteLine("Running code smell Parameter By Value, variant " + variant);
            for (int i = 0; i < iterations; i++) ParamByVal.ParameterByValue();
            Console.WriteLine("Done");
        }

        private void RunRepeatedConditionals(string variant)
        {
            int iterations = 500000000; // 500M

            RepeatedConditionalsBase RepeatedCond;
            if (variant == "bad") RepeatedCond = new RepeatedConditionalsBad();
            else RepeatedCond = new RepeatedConditionalsGood();

            Console.WriteLine("Running code smell Repeated Conditionals, variant " + variant);
            for (int i = 0; i < iterations; i++) RepeatedCond.RepeatedConditionals();
            Console.WriteLine("Done");
        }

        private void RunSelfAssignment(string variant)
        {
            int iterations = 50000000; // 50M

            SelfAssignmentBase SelfAssignment;
            if (variant == "bad") SelfAssignment = new SelfAssignmentBad();
            else SelfAssignment = new SelfAssignmentGood();

            Console.WriteLine("Running code smell Self Assignment, variant " + variant);
            for (int i = 0; i < iterations; i++) SelfAssignment.SelfAssignment();
            Console.WriteLine("Done");
        }

        private void RunShortCircuit(string variant)
        {
            int iterations = 200000000; // 200M

            ShortCircuitBase ShortCircuit;
            if (variant == "bad") ShortCircuit = new ShortCircuitBad();
            else ShortCircuit = new ShortCircuitGood();

            Console.WriteLine("Running code smell Non-Short Circuit, variant " + variant);
            for (int i = 0; i < iterations; i++) ShortCircuit.ShortCircuit();
            Console.WriteLine("Done");
        }

        private void RunTypeCheckingTypeField(string variant)
        {
            int iterations = 500000000; // 500M
            Employee[] employeeTypes =
            {
                new Engineer(),
                new Salesman(),
                new Director()
            };

            TypeCheckingBase TypeChecking;
            if (variant == "bad") TypeChecking = new TypeCheckingTypeFieldBad();
            else TypeChecking = new TypeCheckingGood();

            Console.WriteLine("Running code smell Type Checking, variant " + variant);
            for (int i = 0; i < iterations; i++)
            {
                TypeChecking.SetObj(employeeTypes[i % 3]);
                TypeChecking.getType();
            }
            Console.WriteLine("Done");
        }

        private void RunTypeCheckingRTTI(string variant)
        {
            int iterations = 500000000; // 500M
            Employee[] employeeTypes =
            {
                new Engineer(),
                new Salesman(),
                new Director()
            };
            
            TypeCheckingBase TypeChecking;
            if (variant == "bad") TypeChecking = new TypeCheckingRTTIBad();
            else TypeChecking = new TypeCheckingGood();

            Console.WriteLine("Running code smell Type Checking, variant " + variant);
            for (int i = 0; i < iterations; i++) 
            {
                TypeChecking.SetObj(employeeTypes[i % 3]);
                TypeChecking.getType();
            }
            Console.WriteLine("Done");
        }

        private void RunDeadCode(string variant)
        {
            int iterations = 200000000; // 200M

            DeadCodeBase DeadCode;
            if (variant == "bad") DeadCode = new DeadCodeBad();
            else DeadCode = new DeadCodeGood();

            Console.WriteLine("Running code smell Dead Code, variant " + variant);
            for (int i = 0; i < iterations; i++) DeadCode.Run();
            Console.WriteLine("Done");
        }
        
        private void RunRedundantDataStorage(string variant)
        {
            int iterations = 2000000; // 2M

            RedundantDataStorageBase RedundantData;
            if (variant == "bad") RedundantData = new RedundantDataStorageBad();
            else RedundantData = new RedundantDataStorageGood();

            Console.WriteLine("Running code smell Redundant Data Storage, variant " + variant);
            for (int i = 0; i < iterations; i++) RedundantData.Run();
            Console.WriteLine("Done");
        }

        private void RunInLineMethod(string variant)
        {
            int iterations = 200000000; // 200M

            InLineBase inLine;
            if (variant == "bad") inLine = new InLineBad();
            else inLine = new InLineGood();
            
            Console.WriteLine("Running code smell In Line Method, variant " + variant);
            for (int i = 0; i < iterations; i++) inLine.InLine();
            Console.Write("Done");
        }
    }
}