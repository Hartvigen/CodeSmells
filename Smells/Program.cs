﻿using System;
using System.Collections.Generic;
using allSmells;
using Smells.CodeSmellExamples;
using Smells.CodeSmellDispatch;
using Smells.CodeSmellConstants;

namespace Smells
{
    class Program
    {
        static void Main(string[] args1)
        {
            Args args = new Args(args1);
            Dispatcher Dispatch = new Dispatcher();
            

            //Smells run if the corresponding boolean parameter is true, otherwise a non-smelly version runs
            if (args.getSmell() == "super-smell")
            {
                Dispatch.DispatchSuperSmell(args1);
            }
            else
                Dispatch.DispatchCodeSmell(args.getSmell(), args.getVariant());
        }
    }

    class Args
    {
        private string Smell;
        private string Variant;

        public string getSmell() { return Smell; }
        public string getVariant() { return Variant; }

        public Args(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Error: no arguments detected, exiting");
                HelpText();
                System.Environment.Exit(1);
            }
            else if (args[0] == "help") 
                {
                    HelpText();
                    System.Environment.Exit(0);
                }
            else if (args[0] == "super-smell")
            {
                Smell = "super-smell";
                Variant = "good";
            }
            
            else 
            {
                if (args.Length == 2)
                {
                    Smell = args[0];
                    Variant = args[1];

                    if (Variant != "bad" && Variant != "good")
                    {
                        Console.WriteLine("Variant \"" + Variant + "\" unrecognized, defaulting to good");
                        Variant = "good";
                    }
                }
                
                else 
                {
                    Console.WriteLine("Error: insufficient amount of arguments detected, exiting");
                    HelpText();
                    System.Environment.Exit(1);
                }
            }
        }

        public void HelpText()
        {
            Console.WriteLine("### CodeSmellExamples help text ###");
            Console.WriteLine("");
            Console.WriteLine("Usage: Smells <code-smell> <variant>");
            Console.WriteLine("");
            Console.WriteLine("\t\thelp\t\tdisplay this help text");
            Console.WriteLine("\t\tcode-smell\tthe code smell to run (see list of available smells below)");
            Console.WriteLine("\t\tvariant\t\tthe variant of the code smell; 'good' or 'bad' [default: good]");
            Console.WriteLine("");
            Console.WriteLine("Available smells: " + "{ " + String.Join(", ", CodeSmellConstants.Constants.CODE_SMELL_CHOICES) + " }");
        }
    }
}