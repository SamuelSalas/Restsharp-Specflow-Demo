using FluentAssertions;
using Payment.API.Pet;
using TechTalk.SpecFlow;

namespace Payment.Steps
{
    [Binding]
    public class FindPetByIDStepDefinitions
    {
        private API_FindPetByID petByID;
        private API_FindByStatus petStatus;
        private string petId;

        [Given(@"a valid petId is passed in the url")]
        public void GivenAValidPetIdIsPassedInTheUrl()
        {
            petByID = new API_FindPetByID();
            petStatus = new API_FindByStatus();
            petId = petStatus.GetFirstPetId();
            petByID.SetPetIdUrlSegment(petId);
        }

        [Given(@"an invalid petid is passed in the url")]
        public void GivenAnInvalidPetidIsPassedInTheUrl()
        {
            petByID = new API_FindPetByID();
            petStatus = new API_FindByStatus();
            petId = petStatus.GenerateInvalidPetId();
            petByID.SetPetIdUrlSegment(petId);
        }

        [When(@"performing a GET call to FindPetByID endpoint")]
        public void WhenPerformingAGETCallToFindPetByIDEndpoint()
        {
            petByID.Execute();
        }

        [Then(@"FindPetByID response status code should be (.*)")]
        public void ThenFindPetByIDResponseStatusCodeShouldBe(int statusCode)
        {
            petByID.GetResponseStatusCode().Should().Be(statusCode);
        }

        [Then(@"the expected pet id should be returned")]
        public void ThenTheExpectedPetIdShouldBeReturned()
        {
            petByID.GetResponsePetId().Should().Be(petId);
        }

        [Then(@"error message should be returned")]
        public void ThenErrorMessageShouldBeReturned()
        {
            petByID.GetErrorCode().Should().Be(1);
            petByID.GetErrorType().Should().Be("error");
            petByID.GetErrorMessage().Should().Be("Pet not found");
        }
    }
}
