using System;
using FluentAssertions;
using SpecFlowBallot;
using TechTalk.SpecFlow;

namespace SpecFlowProjectTP2.Steps
{
    [Binding]
    public sealed class BallotStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly Ballot _ballot = new Ballot();
        private string? _choice;

        public BallotStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("the votes are")]
        public void GivenTheSecondNumberIs(Table dataTable)
        {
            foreach (var row in dataTable.Rows)
            {
                _ballot.VotesFirstTurn.Add(new Vote((Choice) Enum.Parse(typeof(Choice), row[0])));
            }
        }

        [When(@"winner")]
        public void WhenWinner()
        {
            //_choice = _ballot.GetWinner(_ballot.VotesFirstTurn).ToString();
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBeVoteBlanc(string result)
        {
            _choice.Should().Be(result);
        }
    }
}