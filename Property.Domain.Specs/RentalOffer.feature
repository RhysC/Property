Feature: Tenant Rental Offer Submission
	In order to efficiently place rental offers
	As a prospective tenant
	I want to quickly make offers that have all the information required for a landlord to accept

Scenario: User is not logged on (or session has timed out)
	Given I have not logged on
	When I make an offer
	Then an authorisation error will be raised

Scenario: Tenant make an offer
	Given my user is logged in
	 When I make an offer
	 Then the offer is persisted in the RentalOfferPending queue

Scenario: An invalid offer has been made
	Given an invalid offer has been submitted to the RentalOfferPending queue
	 When the offer is processed
	 Then an InvalidOfferNotification is raised with the offer and the user

Scenario: User has invalid offers
	Given my user is logged in
	  And has pending invalid offer notifications
	 When I request user notifications
	 Then I get an InvalidOfferNotification

Scenario: User resubmits invalid offer
	Given my user is logged in
	  And has pending invalid offer notifications
	 When I open previous invalid offer
	  And I resubmit the offer
	 Then the InvalidOfferNotification should be marked actioned

	Scenario: User removes invalid offer
	Given my user is logged in
	  And has pending invalid offer notifications
	 When I open previous invalid offer
	  And I remove the offer
	 Then the InvalidOfferNotification should be marked actioned