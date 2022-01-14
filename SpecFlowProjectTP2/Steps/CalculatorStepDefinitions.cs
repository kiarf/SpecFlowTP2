using SpecFlowTP2;
using TechTalk.SpecFlow;

namespace SpecFlowProjectTP2.Steps
{
    [Binding]
    public sealed class ScrutinStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private Scrutin _scrutin = new Scrutin();

        public ScrutinStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("the votes are")]
        public void GivenTheSecondNumberIs(int number)
        {
            _scenarioContext.Pending();
        }
    }
}