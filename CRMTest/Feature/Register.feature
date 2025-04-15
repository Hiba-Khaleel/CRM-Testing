Feature: Register page
Register in the CRM website


    Scenario Outline: Navigate to the Register page and register a user
        Given I am on the CRM home Page
        And I see the register button
        And I click on register button
        And I be navigated to the register page
        And I see The register form
        And I fill out the register form with "<email>", "<password>", "<userName>" and "<company>"
        When I click the register form submit button
        Then I should be registered and navigated to the login page


        Examples:
          | email                  | password | userName | company |
          | hiba.khaleel@fusyd.net | abc123   |   Jakob  | Demo AB |
         