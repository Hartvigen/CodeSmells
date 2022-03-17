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
        public GodClassBad(int id, string firstName, string lastName, string address, string degree, double gpa, List<string> previousWorkPlaces, DateTime interviewDate, int recruiterId, string recruiterName, int interviewerId, string interviewerName, string interviewerRemarks, decimal currentSalary, decimal expectedSalary)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.degree = degree;
            this.gpa = gpa;
            this.previousWorkPlaces = previousWorkPlaces;
            this.interviewDate = interviewDate;
            this.recruiterId = recruiterId;
            this.recruiterName = recruiterName;
            this.interviewerId = interviewerId;
            this.interviewerName = interviewerName;
            this.interviewerRemarks = interviewerRemarks;
            this.currentSalary = currentSalary;
            this.expectedSalary = expectedSalary;
        }

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
        public string interviewerRemarks { get; set; }
        decimal currentSalary { get; set; }
        decimal expectedSalary { get; set; }
        public override string GetCandidateInfo()
        {
            GodClassBad cand1 = new GodClassBad(1, "Mike", "Oxlong", "SpoonerStreet 14",
                "Bachelor in Software Engineering", 4.9,
                new List<string> {"McDonalds", "Ford Motors", "Google", "Amazon", "AVK"},
                DateTime.Parse("03/16/2022 07:30:00"), 5,
                "John Doe", 3, "Ray Pinas",
                "Mike displays a lot of potential and enthusiasm, a training period of about 3 months will be required to get him into our system, but after that he should be a great asset to the company",
                8000, 950000);

            GodClassBad cand2 = new GodClassBad(2, "Ben", "Dover", "McAlleyStreet 3",
                "Masters in Information Technology", 4.2,
                new List<string> {"Subway", "John's computer parts", "TopData"},
                DateTime.Parse("03/16/2022 09:15:00"), 5,
                "John Doe", 3, "Ray Pinas",
                "Ben is somewhat of a ditz, he came late to the meeting and refused to answer question in favor of throwing plant water in my face, very unproffesional",
                25000, 950000);
            
            GodClassBad cand3 = new GodClassBad(3, "Jenny", "Tallies", "Livingway 28",
                "Bachelors in Computer Sceince", 4.6,
                new List<string> {"Markus'", "Aalborg University", "Computer World", "Amazon"},
                DateTime.Parse("03/16/2022 14:00:00"), 5,
                "John Doe", 7, "Wayne Kerr",
                "Jeny sems to be vry niice and an good prson (Please note that Wayne is dyslexic)",
                150000, 950000);
            
                return cand1.interviewerRemarks + cand2.interviewerRemarks + cand3.interviewerRemarks;
            }
            
        }

    public class GodClassGood : GodClassBase
    {
        private class Candidate
        {
            public int id { get; set; }
            string firstName { get; set; }
            string lastName { get; set; }
            string address { get; set; }
            string degree { get; set; }
            double gpa { get; set; }
            List<string> previousWorkPlaces { get; set; }
            decimal currentSalary { get; set; }
            decimal expectedSalary { get; set; }
            
            public Candidate(int id, string firstName, string lastName, string address, string degree, double gpa, List<string> previousWorkPlaces, decimal currentSalary, decimal expectedSalary)
            {
                this.id = id;
                this.firstName = firstName;
                this.lastName = lastName;
                this.address = address;
                this.degree = degree;
                this.gpa = gpa;
                this.previousWorkPlaces = previousWorkPlaces;
                this.currentSalary = currentSalary;
                this.expectedSalary = expectedSalary;
            }
        }

        private class Interviewer
        {

            public int interviewerId { get; set; }
            public string interviewerName { get; set; }
            
            public Interviewer(int interviewerId, string interviewerName)
            {
                this.interviewerId = interviewerId;
                this.interviewerName = interviewerName;
            }
        }
        
        private class Recruiter
        {
            public int recruiterId { get; set; }
            public string recruiterName { get; set; }

            public Recruiter(int recruiterId, string recruiterName)
            {
                this.recruiterId = recruiterId;
                recruiterName = "John Doe";
            }
        }

        private class Interview
        {
            public Interview(int interviewerId, int recruiterId, int candidateId, string interviewerRemarks, DateTime interviewDate)
            {
                this.interviewerId = interviewerId;
                this.recruiterId = recruiterId;
                this.candidateId = candidateId;
                this.interviewerRemarks = interviewerRemarks;
                this.interviewDate = interviewDate;
            }

            int interviewerId { get; set; }
            int recruiterId { get; set; }
            int candidateId { get; set; }
            public string interviewerRemarks { get; set; }
            DateTime interviewDate { get; set; }
            
        }

        public override string GetCandidateInfo()
        {
            Candidate cand1 = new Candidate(1, "Mike", "Oxlong", "SpoonerStreet 14", "Bachelor in Software Engineering",
                4.9, new List<string> {"McDonalds", "Ford Motors", "Google", "Amazon", "AVK"},
                8000, 950000);
            Candidate cand2 = new Candidate(2, "Ben", "Dover", "McAlleyStreet 3",
                "Masters in Information Technology", 4.2,
                new List<string> {"Subway", "John's computer parts", "TopData"},
                25000, 950000);
            Candidate cand3 = new Candidate(3, "Jenny", "Tallies", "Livingway 28",
                "Bachelors in Computer Sceince", 4.6,
                new List<string> {"Markus'", "Aalborg University", "Computer World", "Amazon"}, 150000, 950000);
            
            Recruiter recruiter1 = new Recruiter(5, "John Doe");

            Interviewer interviewer1 = new Interviewer(3, "Ray Pinas");
            Interviewer interviewer2 = new Interviewer(7, "Wayner Kerr");


            Interview interview1 = new Interview(recruiter1.recruiterId, interviewer1.interviewerId, cand1.id,
                "Mike displays a lot of potential and enthusiasm, a training period of about 3 months will be required to get him into our system, but after that he should be a great asset to the company",
                DateTime.Parse("03/16/2022 07:30:00"));
            Interview interview2 = new Interview(recruiter1.recruiterId, interviewer1.interviewerId, cand2.id,
                "Ben is somewhat of a ditz, he came late to the meeting and refused to answer question in favor of throwing plant water in my face, very unproffesional",
                DateTime.Parse("03/16/2022 09:15:00"));
            Interview interview3 = new Interview(recruiter1.recruiterId, interviewer2.interviewerId, cand3.id,
                "Jeny sems to be vry niice and an good prson (Please note that Wayne is dyslexic)",
                DateTime.Parse("03/16/2022 14:00:00"));


            return interview1.interviewerRemarks + interview2.interviewerRemarks + interview3.interviewerRemarks;
        }
    }
    
}
    