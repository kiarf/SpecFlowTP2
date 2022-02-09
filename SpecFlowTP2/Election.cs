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
            var results = Ballot.ProcessTurn(secondTurn).ToList();

            switch (secondTurn)
            {
                case true when results.Count() == 2:
                {
                    var candidat1 = Candidates.Find(c => c.CandidateCode == results.First());
                    var candidat2 = Candidates.Find(c => c.CandidateCode == results.Last());

                    Candidates.Remove(candidat1.BirthDate < candidat2.BirthDate ? candidat2 : candidat1);
                    return;
                }
                case false when results.Count() == 3:
                {
                    var candidat1 = Candidates.Find(c => c.CandidateCode == results.ElementAtOrDefault(1));
                    var candidat2 = Candidates.Find(c => c.CandidateCode == results.ElementAtOrDefault(2));

                    Candidates.Remove(candidat1.BirthDate < candidat2.BirthDate ? candidat2 : candidat1);
                    return;
                }
            }

            Candidates.RemoveAll(c => !Ballot.ProcessTurn(secondTurn).Contains(c.CandidateCode));
        }
    }
}