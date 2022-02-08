using FluentAssertions;
using Payment.API.Pet;
using TechTalk.SpecFlow;

namespace Payment.Steps
{
    [Binding]
    public class AddPetStepDefinitions
    {
        private API_AddPet addPet;

        [Given(@"the expected response body is attach to the request")]
        public void GivenTheExpectedResponseBodyIsAttachToTheRequest()
        {
            addPet = new API_AddPet();
        }

        [When(@"performing a Post call to AddPet endpoint")]
        public void WhenPerformingAPostCallToAddPetEndpoint()
        {
            addPet.Execute();
        }

        [Then(@"AddPet response status code should be (.*)")]
        public void ThenAddPetResponseStatusCodeShouldBe(int statusCode)
        {
            addPet.GetResponseStatusCode().Should().Be(statusCode);
        }

        [Then(@"the response should return the pet info")]
        public void ThenTheResponseShouldReturnThePetInfo()
        {
            addPet.requestBody.category.name.Should().Be(addPet.responseBody.category.name);
            addPet.requestBody.category.id.Should().Be(addPet.responseBody.category.id);
            addPet.requestBody.name.Should().Be(addPet.responseBody.name);
            addPet.requestBody.photoUrls[0].Should().Be(addPet.responseBody.photoUrls[0]);
            addPet.requestBody.tags[0].id.Should().Be(addPet.responseBody.tags[0].id);
            addPet.requestBody.tags[0].name.Should().Be(addPet.responseBody.tags[0].name);
            addPet.requestBody.status.Should().Be(addPet.responseBody.status);
        }
    }
}
