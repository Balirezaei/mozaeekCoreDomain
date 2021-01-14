using System;
using TechTalk.SpecFlow;

namespace MozaeekCore.Specs
{
    [Binding]
    public class UnProcessedRequestCreationSteps
    {
        [Given(@"'(.*)' is a WorkWriter in system")]
        public void GivenIsAWorkWriterInSystem(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"he has entered the following information")]
        public void GivenHeHasEnteredTheFollowingInformation(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"he submits the data")]
        public void WhenHeSubmitsTheData()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the result should be an UnProcessedRequest with isProcessed False value")]
        public void ThenTheResultShouldBeAnUnProcessedRequestWithIsProcessedFalseValue()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
