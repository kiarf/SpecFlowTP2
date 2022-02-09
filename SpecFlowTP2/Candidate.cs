using System;

namespace SpecFlowBallot
{
    public class Candidate
    {
        public Candidate(string firstName, string lastName, DateTime birthDate, int candidateCode)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            CandidateCode = candidateCode;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int CandidateCode { get; set; }
    }
}