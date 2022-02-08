using FluentAssertions;
using Payment.API.Pet;
using System.Linq;
using TechTalk.SpecFlow;

namespace Payment.Steps
{
    [Binding]
    public class FindPetByStatusStepDefinitions
    {
        private API_FindByStatus findPetsByStatus;

        [Given(@"FindByStatus value is ""([^""]*)""")]
        public void GivenFindByStatusValueIs(string value)
        {
            findPetsByStatus = new API_FindByStatus();
            findPetsByStatus.SetStatusParameter(value);
        }

        [When(@"performing a GET call to FindByStatus endpoint")]
        public void WhenPerformingAGETCallToFindByStatusEndpoint()
        {
            findPetsByStatus.Execute();
        }

        [Then(@"FindByStatus response status code should be (.*)")]
        public void ThenFindByStatusResponseStatusCodeShouldBe(int statusCode)
        {
            findPetsByStatus.GetResponseStatusCode().Should().Be(statusCode);
        }

        [Then(@"pets status should be ""([^""]*)""")]
        public void ThenPetsStatusShouldBe(string value)
        {
            findPetsByStatus.responseBody.Select(property => property.status).Should().AllBe(value);
        }

        [Then(@"array response should be empty")]
        public void ThenArrayResponseShouldBeEmpty()
        {
            findPetsByStatus.responseBody.Should().BeEmpty();
        }
    }
}
