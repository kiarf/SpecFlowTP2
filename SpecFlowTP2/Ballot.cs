using System.Collections.Generic;
using System.Linq;

namespace SpecFlowBallot
{
    public class Ballot
    {
        public Ballot()
        {
            Votes = new List<Vote>();
        }

        public List<Vote> Votes { get; set; }

        private Dictionary<Choice, int> GetResults()
        {
            var results = new Dictionary<Choice, int>();
            foreach (var vote in Votes)
            {
                if (results.ContainsKey(vote.Choice))
                {
                    results[vote.Choice] += 1;
                }
                else
                {
                    results.Add(vote.Choice, 1);
                }
            }

            return results;
        }

        public Choice GetWinner()
        {
            var results = GetResults();
            return results.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
        }
    }
}