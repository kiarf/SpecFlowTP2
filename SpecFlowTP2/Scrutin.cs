using System.Collections.Generic;
using System.Linq;

namespace SpecFlowTP2
{
    public class Scrutin
    {
        public Scrutin()
        {
            Votes = new List<Vote>();
        }

        public List<Vote> Votes { get; set; }

        public Dictionary<Choix, int> GetResultat()
        {
            // Retourne le choix pour lequel il y a le plus de candidats
            var resultats = Votes.GroupBy(t => t.choix).ToDictionary(t => t.Key, x => x.Count());
            return resultats;
        }

        public Choix GetVainqueur()
        {
            return Votes.GroupBy(t => t.choix).OrderBy(t => t.Count()).First().Key;
        }
    }
}