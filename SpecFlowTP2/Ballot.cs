using System;
using System.Collections.Generic;
using System.Linq;

namespace SpecFlowBallot
{
    public class Ballot
    {
        public Ballot()
        {
            VotesSecondTurn = new List<Vote>();
            VotesFirstTurn = new List<Vote>();
        }

        public List<Vote> VotesFirstTurn { get; set; }
        private bool? SecondTurn { get; set; }
        public List<Vote> VotesSecondTurn { get; set; }
        private int VoteCount { get; set; }

        // Range les votes par candidats et renvoie un dictionaire Candidat/Nombre de voix
        private Dictionary<Choice, int> GetResults(List<Vote> votes)
        {
            VoteCount = 0;
            var results = new Dictionary<Choice, int>();

            foreach (var vote in votes)
            {
                if (results.ContainsKey(vote.Choice))
                {
                    results[vote.Choice] += 1;
                }
                else
                {
                    results.Add(vote.Choice, 1);
                }

                VoteCount += 1;
            }

            return results;
        }

        // Affiche les résultats pour un tour (candidat, nombre de voix, pourcentage)
        private void DisplayResults(List<Vote> votes, int voteCount)
        {
            var results = GetResults(votes).OrderBy(t => t.Value);
            foreach (var (key, value) in results)
            {
                Console.WriteLine(key + ": " + value + "votes (" + value / voteCount + "%)");
            }
        }

        /* Détermine s'il faut un deuxième tour
         * Renvoie le nom du candidat en cas de majorité
         * Sinon, renvoie "NoMajority"
         */
        public Choice ProcessFirstTurn()
        {
            var (key, value) = ProcessTurn(VotesFirstTurn);
            SecondTurn = value > VoteCount / 2;
            return SecondTurn.Value ? Choice.NoMajority : key;
        }

        // Renvoie le candidat avec le plus de votes, ou égalité.
        public Choice ProcessSecondTurn()
        {
            return ProcessTurn(VotesSecondTurn).Key;
        }

        // Renovie le candidat avec le plus de voix et son nombre de voix
        private KeyValuePair<Choice, int> ProcessTurn(List<Vote> votes)
        {
            var results = GetResults(votes);
            var winner = Choice.NoMajority;
            var maxVotes = 0;
            foreach (var votesByChoice in results)
            {
                if (votesByChoice.Value > maxVotes)
                {
                    winner = votesByChoice.Key;
                    maxVotes = votesByChoice.Value;
                }
                else if (votesByChoice.Value > maxVotes)
                {
                    winner = Choice.Tie;
                }
            }

            return new KeyValuePair<Choice, int>(winner, maxVotes);
        }
    }
}