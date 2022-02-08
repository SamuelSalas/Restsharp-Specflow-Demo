Feature: AddPet

Scenario: Create new pet
	Given the expected response body is attach to the request
	When performing a Post call to AddPet endpoint
	Then AddPet response status code should be 200
	And the response should return the pet info
