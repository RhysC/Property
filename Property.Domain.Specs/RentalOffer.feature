Feature: User setting
	In order to efficiently screen unserviceable offers
	As a landlord
	I want to avoid recieving offers from user that do not have suitable backgorund information

#@NotloggedIn
#Scenario: User is not registered
#	Given I have not registered for the application
#	When I make an offer
#	Then an authorisation error will be raised

Scenario: User is missing contact details
	Given My user account does not have a valid phone number
	When I make an offer
	Then an validation error will be raised with "Phone Number Required"