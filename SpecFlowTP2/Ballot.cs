using System.Collections.Generic;
using System.Linq;

namespace SpecFlowBallot
{
    public class Ballot
    {
        public Ballot()
        {
            IsOpen = true;
            Votes = new List<Vote>();
        }

        public bool IsOpen { get; set; }

        public List<Vote> Votes { get; }

        public IOrderedEnumerable<KeyValuePair<int, int>> SortedResults { get; set; }

        // Range les votes par candidats et renvoie un dictionaire Candidat/Nombre de voix

        private void SortResults()
        {
            var results = new Dictionary<int, int>();

            foreach (var vote in Votes)
            {
                if (results.ContainsKey(vote.CandidateCode))
                {
                    results[vote.CandidateCode] += 1;
                }
                else
                {
                    results.Add(vote.CandidateCode, 1);
                }
            }

            SortedResults = results.OrderByDescending(r => r.Value);
        }

        public int VoteCount()
        {
            return Votes.Count;
        }

        public IEnumerable<int> ProcessTurn(bool secondTurn)
        {
            SortResults();
            if (IsOpen)
            {
                return new List<int>();
            }

            if (SortedResults.First().Value == SortedResults.ElementAtOrDefault(1).Value && secondTurn)
            {
                return new List<int>
                {
                    SortedResults.First().Key,
                    SortedResults.ElementAtOrDefault(1).Key
                };
            }

            if (SortedResults.First().Value > VoteCount() / 2 || secondTurn)
            {
                return new List<int>
                {
                    SortedResults.First().Key
                };
            }
            
            if (SortedResults.ElementAtOrDefault(1).Value == SortedResults.ElementAtOrDefault(2).Value && !secondTurn)
            {
                return new List<int>
                {
                    SortedResults.First().Key,
                    SortedResults.ElementAtOrDefault(1).Key,
                    SortedResults.ElementAtOrDefault(2).Key
                };
            }

            return new List<int>
            {
                SortedResults.First().Key,
                SortedResults.ElementAtOrDefault(1).Key
            };
        }

        public void CloseBallot()
        {
            IsOpen = false;
        }

        public void AddVotes(IEnumerable<Vote> votes)
        {
            if (IsOpen)
            {
                Votes.AddRange(votes);
            }
        }

        public void AddVotes(Vote vote)
        {
            if (IsOpen)
            {
                Votes.Add(vote);
            }
        }
    }
}