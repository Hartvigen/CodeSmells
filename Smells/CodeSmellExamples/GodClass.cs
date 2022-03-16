using System;
using System.Collections.Generic;

namespace Smells.CodeSmellExamples
{

    public abstract class GodClassBase
    {
        public abstract string GetCandidateInfo();
    }

    public class GodClassBad : GodClassBase
    {
        int id { get; set; }
        string firstName { get; set; }
        string lastName { get; set; }
        string address { get; set; }
        string degree { get; set; }
        double gpa { get; set; }
        List<string> previousWorkPlaces { get; set; }
        DateTime interviewDate { get; set; }
        int recruiterId { get; set; }
        string recruiterName { get; set; }
        int interviewerId { get; set; }
        string interviewerName { get; set; }
        string interviewerRemarks { get; set; }
        decimal currentSalary { get; set; }
        decimal expectedSalary { get; set; }
        GodClassBad()
            {
                id = 1;
                firstName = "Mike";
                lastName = "Oxlong";
                address = "SpoonerStreet 14";
                degree = "Bachelor in Software Engineering";
                gpa = 4.9;
                previousWorkPlaces = new List<string>{"McDonalds", "Ford Motors", "Google", "Amazon", "AVK"};
                interviewDate = DateTime.Parse("03/16/2022 07:22:16");
                recruiterId = 262;
                recruiterName = "John Doe";
                interviewerId = 3;
                interviewerName = "Ray Pinas";
                interviewerRemarks = "Mike displays a lot of potential and enthusiasm, a training period of about 3 months will be required to get him into our system, but after that he should be a great asset to the company";
                currentSalary = 8000;
                expectedSalary = 950000;
            }

        public override string GetCandidateInfo()
            {
                return firstName + " " + lastName;
            }
            
        }

    public class GodClassGood : GodClassBase
    {
        private class Candidate
        {
            int id { get; set; }
            string firstName { get; set; }
            string lastName { get; set; }
            string address { get; set; }
            string degree { get; set; }
            double gpa { get; set; }
            List<string> previousWorkPlaces { get; set; }
            decimal currentSalary { get; set; }
            decimal expectedSalary { get; set; }

            Candidate(int id, string firstName, string lastName, string address, string degree, double gpa, List<string> previousWorkPlaces, decimal currentSalary, decimal expectedSalary)
            {
                id = 1;
                firstName = "Mike";
                lastName = "Oxlong";
                address = "SpoonerStreet 14";
                degree = "Bachelor in Software Engineering";
                gpa = 4.9;
                previousWorkPlaces = new List<string>{"McDonalds", "Ford Motors", "Google", "Amazon", "AVK"};
                currentSalary = 8000;
                expectedSalary = 950000;
            }
        }

        private class Interviewer
        {
            int interviewerId { get; set; }
            string interviewerName { get; set; }

            Interviewer()
            {
                interviewerId = 3;
                interviewerName = "Ray Pinas";
            }
        }
        
        Interviewer
        private class Recruiter
        {
            int recruiterId { get; set; }
            string recruiterName { get; set; }

            Recruiter()
            {
                recruiterId = 262;
                recruiterName = "John Doe";
            }
        }

        private class Interview
        {
            int interviewerId { get; set; }
            int recruiterId { get; set; }
            int candidateId { get; set; }
            string interviewerRemarks { get; set; }
            private DateTime interviewDate { get; set; }
            
        }
        
        public override string GetCandidateInfo()
        {
            return "Hello World";
        }
    }
    
}
    