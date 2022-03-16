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
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Degree { get; set; }
        public double GPA { get; set; }
        public List<string> PreviousWorkPlaces { get; set; }
        public DateTime InterviewDate { get; set; }
        public int RecruiterId { get; set; }
        public string Recruiter { get; set; }
        public int InterviewerId { get; set; }
        public string Interviewer { get; set; }
        public string InterviewerRemarks { get; set; }
        public decimal CurrentSalary { get; set; }
        public decimal ExpectedSalary { get; set; }
        public GodClassBad()
            {
                Id = 1;
                FirstName = "Mike";
                LastName = "Oxlong";
                Address = "SpoonerStreet 14";
                Degree = "Bachelor in Software Engineering";
                GPA = 4.9;
                PreviousWorkPlaces = new List<string>{"McDonalds", "Ford Motors", "Google", "Amazon", "AVK"};
                InterviewDate = DateTime.Parse("03/16/2022 07:22:16");
                RecruiterId = 262;
                Recruiter = "John Doe";
                InterviewerId = 3;
                Interviewer = "Ray Pinas";
                InterviewerRemarks = "Mike displays a lot of potential and enthusiasm, a training period of about 3 months will be required to get him into our system, but after that he should be a great asset to the company";
                CurrentSalary = 8000;
                ExpectedSalary = 950000;
            }

        public override string GetCandidateInfo()
            {
                return FirstName + " " + LastName;
            }
            
        }

    public class GodClassGood : GodClassBase
    {
        private class Candidate
        {
            
        }

        private class Interviewer
        {
            
        }
        private class Recruiter
        {
            
        }

        private class Interview
        {
            
        }
        
        public override string GetCandidateInfo()
        {
            return "Hello World";
        }
    }
    
}
    