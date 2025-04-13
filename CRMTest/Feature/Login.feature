Feature: Login page
Login to the CRM website


    Scenario Outline: Navigate to the login page and login
        Given I am on the CRM homepage
        And I see the login button
        And I click on login button
        And I be navigated to the login page
        And I see The login form
        And I fill out the login form with <email> and <password>
        When I click the login form submit button
        Then I should be logged in


        Examples:
          | email          | password |
          | m@email.com    | abc123   |
          | no@email.com   | abc123   |
          | test@email.com | abc123   |