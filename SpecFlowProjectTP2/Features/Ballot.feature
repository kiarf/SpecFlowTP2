Feature: Scrutin

@Winner
Scenario: GetWinner
	Given the votes are
	| choice |
	|1|
	|2|
	|2|
	|3|
	|1|
	|2|
	When winner
	Then the result should be JohanCampion