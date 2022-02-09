using System;

namespace SpecFlowBallot
{
    public class Vote
    {
        public Vote(int candidateCode)
        {
            CandidateCode = candidateCode;
        }

        public int CandidateCode { get; set; }
    }
}