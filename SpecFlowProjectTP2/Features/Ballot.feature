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
Scenario: No candidate win the second turn (tie)
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

