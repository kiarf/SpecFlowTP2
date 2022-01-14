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

        public Dictionary<Choice, int> GetResultat()
        {
            // Retourne le Choice pour lequel il y a le plus de candidats
            var resultats = Votes.GroupBy(t => t.Choice).ToDictionary(t => t.Key, x => x.Count());
            return resultats;
        }

        public Choice GetVainqueur()
        {
            return Votes.GroupBy(t => t.Choice).OrderBy(t => t.Count()).First().Key;
        }
    }
}