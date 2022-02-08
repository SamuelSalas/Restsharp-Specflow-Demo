Feature: FindPetByStatus

Scenario Outline: Filter Pets By Valid Status
	Given FindByStatus value is "<value>"
	When performing a GET call to FindByStatus endpoint
	Then FindByStatus response status code should be 200
	And pets status should be "<value>"

Examples:
	| value     |
	| available |
	| pending   |
	| sold      |

Scenario: Invalid Pets Filter value Pets
	Given FindByStatus value is "invalid"
	When performing a GET call to FindByStatus endpoint
	Then FindByStatus response status code should be 200
	And array response should be empty