using FluentAssertions;
using Payment.API.Pet;
using TechTalk.SpecFlow;

namespace Payment.Steps
{
    [Binding]
    public class DeletePetStepDefinitions
    {
        private API_FindByStatus petStatus;
        private API_DeletePet deletePet;
        private string firstPetId;

        [Given(@"a valid petId is passed in the DeletePet url")]
        public void GivenAValidPetIdIsPassedInTheDeletePetUrl()
        {
            petStatus = new API_FindByStatus();
            deletePet = new API_DeletePet();
            firstPetId = petStatus.GetFirstPetId();
            deletePet.SetPetId(firstPetId);
        }

        [Given(@"an invalid petId is passed in the DeletePet url")]
        public void GivenAnInvalidPetIdIsPassedInTheDeletePetUrl()
        {
            petStatus = new API_FindByStatus();
            deletePet = new API_DeletePet();
            firstPetId = petStatus.GenerateInvalidPetId();
            deletePet.SetPetId(firstPetId);
        }

        [When(@"performing a DELETE call to DeletePet endpoint")]
        public void WhenPerformingADELETECallToDeletePetEndpoint()
        {
            deletePet.Execute();
        }

        [Then(@"DeletePet response status code should be (.*)")]
        public void ThenDeletePetResponseStatusCodeShouldBe(int statusCode)
        {
            deletePet.GetResponseStatusCode().Should().Be(statusCode);
        }

        [Then(@"message value should be valid petId sent")]
        public void ThenMessageValueShouldBeValidPetIdSent()
        {
            deletePet.responseBody.message.Should().Be(firstPetId);
        }
    }
}
