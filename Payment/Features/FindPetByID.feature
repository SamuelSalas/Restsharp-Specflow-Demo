Feature: FindPetByID

Returns a single pet

Scenario: Send valid Pet id
	Given a valid petId is passed in the url
	When performing a GET call to FindPetByID endpoint
	Then FindPetByID response status code should be 200
	And the expected pet id should be returned

Scenario: Send invalid Pet id
	Given an invalid petid is passed in the url
	When performing a GET call to FindPetByID endpoint
	Then FindPetByID response status code should be 404
	And error message should be returned