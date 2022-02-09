Feature: Scrutin

@MajorityFirstTurn
Scenario: Majority in the first turn
	Given the candidates are
	| FirstName    | LastName | BirthDate  | CandidateCode |
	| Johan        | Campion  | 13/07/1997 | 1             |
	| Francois     | Roullaud | 16/10/1999 | 2             |
	| Jean-Charles | Durand   | 05/05/1989 | 3             |
	And the votes are
	| CandidateCode |
	| 2             |
	| 1             |
	| 1             |
	| 1             |

	And the ballot is closed
	When first turn
	Then the winner of the ballot should be 
	| FirstName    | LastName | BirthDate  | CandidateCode |
	| Johan        | Campion  | 13/07/1997 | 1             |

@NoMajorityFirstTurn
Scenario: No Majority in the first turn : two candidates selected for second turn
	Given the candidates are
	| FirstName    | LastName | BirthDate  | CandidateCode |
	| Francois     | Roullaud | 16/10/1999 | 2             |
	| Jean-Charles | Durand   | 05/05/1989 | 3             |
	| Johan        | Campion  | 13/07/1997 | 1             |
	And the votes are
	| CandidateCode |
	| 1             |
	| 2             |
	And the ballot is closed
	When first turn
	Then the winner of the ballot should be 
	| FirstName    | LastName | BirthDate  | CandidateCode |
	| Johan        | Campion  | 13/07/1997 | 1             |
	| Francois     | Roullaud | 16/10/1999 | 2             |

@TieForSecond
Scenario: No Majority in the first turn & tie for the second candidate : the oldest candidate wins
	Given the candidates are
	| FirstName    | LastName | BirthDate  | CandidateCode |
	| Francois     | Roullaud | 16/10/1999 | 2             |
	| Jean-Charles | Durand   | 05/05/1989 | 3             |
	| Johan        | Campion  | 13/07/1997 | 1             |
	And the votes are
	| CandidateCode |
	| 1             |
	| 2             |
	| 2             |
	| 3             |
	And the ballot is closed
	When first turn
	Then the winner of the ballot should be 
	| FirstName    | LastName | BirthDate  | CandidateCode |
	| Francois     | Roullaud | 16/10/1999 | 2             |
	| Jean-Charles | Durand   | 05/05/1989 | 3             |


@MajoritySecondTurn
Scenario: A candidate wins the second turn (more votes)
	Given the candidates are
	| FirstName    | LastName | BirthDate  | CandidateCode |
	| Johan        | Campion  | 13/07/1997 | 1             |
	| Francois     | Roullaud | 16/10/1999 | 2             |
	| Jean-Charles | Durand   | 05/05/1989 | 3             |
	And the votes are
	| CandidateCode |
	| 1             |
	| 3             |
	| 3             |
	And the ballot is closed
	When second turn
	Then the winner of the ballot should be 
	| FirstName    | LastName | BirthDate  | CandidateCode |
	| Jean-Charles | Durand   | 05/05/1989 | 3             |

@TieSecondTurn
Scenario: The oldest candidate wins the second turn (tie)
	Given the candidates are
	| FirstName    | LastName | BirthDate  | CandidateCode |
	| Johan        | Campion  | 13/07/1997 | 1             |
	| Francois     | Roullaud | 16/10/1999 | 2             |
	| Jean-Charles | Durand   | 05/05/1989 | 3             |
	And the votes are
	| CandidateCode |
	| 1             |
	| 3             |
	And the ballot is closed
	When second turn
	Then the winner of the ballot should be 
	| FirstName    | LastName | BirthDate  | CandidateCode |
	| Jean-Charles | Durand   | 05/05/1989 | 3             |


