Feature: DeletePet

A short summary of the feature

@tag1
Scenario: DeleteValidPet
	Given a valid petId is passed in the DeletePet url
	When performing a DELETE call to DeletePet endpoint
	Then DeletePet response status code should be 200
	And message value should be valid petId sent

Scenario: DeleteInValidPet
	Given an invalid petId is passed in the DeletePet url
	When performing a DELETE call to DeletePet endpoint
	Then DeletePet response status code should be 404