namespace SpecFlowBallot
{
    public class Vote
    {
        public Vote(Choice choice)
        {
            Choice = choice;
        }

        public Choice Choice { get; set; }
    }
}