using System.Collections.Generic;
using System.Linq;

namespace SpecFlowBallot
{
    public class Election
    {
        public Election()
        {
            Ballot = new Ballot();
            Candidates = new List<Candidate>();
        }

        public Ballot Ballot { get; set; }
        private List<Candidate> Candidates { get; }

        public void AddCandidate(Candidate candidate)
        {
            Candidates.Add(candidate);
        }

        public List<Candidate> GetCandidates()
        {
            return Candidates;
        }

        public void ProcessTurn(bool secondTurn = false)
        {
            Candidates.RemoveAll(c => !Ballot.ProcessTurn(secondTurn).Contains(c.CandidateCode));
        }
    }
}