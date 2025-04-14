Feature: Login page & Logout
Login to the CRM website and Logout 


    Scenario Outline: Navigate to the login page and login and then Logout
        Given I am on the CRM homepage
        And I see the login button
        And I click on login button
        And I be navigated to the login page
        And I see The login form
        And I fill out the login form with <email> and <password>
        When I click the login form submit button
        Then I should be logged and click Logout button to return to homePage


        Examples:
          | email          | password |
          | m@email.com    | abc123   |
          | no@email.com   | abc123   |
          | test@gmail.com | abc123   |