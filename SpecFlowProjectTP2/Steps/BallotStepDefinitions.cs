using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using SpecFlowBallot;
using TechTalk.SpecFlow;

namespace SpecFlowProjectTP2.Steps
{
    [Binding]
    public sealed class BallotStepDefinitions
    {
        private readonly Election _election = new Election();

        private readonly ScenarioContext _scenarioContext;

        private readonly List<Candidate> Candidates = new List<Candidate>();

        public BallotStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("the votes are")]
        public void GivenTheSecondNumberIs(Table dataTable)
        {
            foreach (var row in dataTable.Rows)
            {
                _election.Ballot.AddVotes(new Vote(int.Parse(row[0])));
            }
        }

        [Given("the candidates are")]
        public void GivenTheCandidatesAre(Table dataTable)
        {
            foreach (var row in dataTable.Rows)
            {
                _election.AddCandidate(new Candidate(
                                                     row[0],
                                                     row[1],
                                                     DateTime.ParseExact(row[2], "dd/MM/yyyy", null),
                                                     Convert.ToInt32(row[3]))
                                      );
            }
        }

        [Given(@"the ballot is closed")]
        public void GivenTheBallotIsClosed()
        {
            _election.Ballot.CloseBallot();
        }

        [When(@"first turn")]
        public void WhenFirstTurn()
        {
            _election.ProcessTurn();
        }

        [When(@"second turn")]
        public void WhenSecondTurn()
        {
            _election.ProcessTurn(true);
        }

        [When(@"display")]
        public void WhenDisplay()
        {
            _election.UpdateForDisplay();
        }

        [Then("the winner of the ballot should be")]
        public void ThenTheResultShouldBe(Table dataTable)
        {
            var osef = dataTable.Rows.Select(row => new Candidate(row[0], row[1], DateTime.ParseExact(row[2], "dd/MM/yyyy", null), Convert.ToInt32(row[3]))).ToList();
            _election.GetCandidates().Should().BeEquivalentTo(osef);
        }

        [Then(@"the result of the ballot should be")]
        public void ThenTheResultOfTheBallotShouldBe(Table dataTable)
        {
            var osef = dataTable.Rows.Select(row => new Candidate(row[0], row[1], Convert.ToInt32(row[2]), Convert.ToInt32(row[3]))).ToList();
        }
    }
}