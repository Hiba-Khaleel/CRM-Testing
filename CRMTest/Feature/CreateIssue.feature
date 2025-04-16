Feature: Create Issue
Create Issue after user is logged in

    Scenario Outline: Login and create an issue
        Given I am logged in as "<email>" with password "<password>"
        And I see the company name 
        And I click on the company name
        And I see the Issue form 
        And I fill it by "<senderEmail>", "<title>" and "<message>"
        When I click create issue button 

        Examples:
          | email       | password | senderEmail | title                  | message                 |
          | m@email.com | abc123   | hb.khaleel@gmail.com | issue with delivering  | this is my test message |