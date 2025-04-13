namespace CRMTest;
using server.Classes;
using server.Enums;
public class ClassesUnitTest
{
    
    //CompanyForm
    
    [Fact]
    public void CompanyFormTest()
    {
        // Arrange
        var companyName = "TestCompany";
        var subjects = new List<string> { "Support", "Billing", "Feedback" };

        // Act
        var form = new CompanyForm(companyName, subjects);

        // Assert
        Assert.Equal(companyName, form.CompanyName);
        Assert.Equal(subjects, form.Subjects);
        Assert.Contains("Billing", form.Subjects);
    }
    
    //Employee
    [Fact]
    public void EmployeeTest()
    {
        // Arrange
        var id = 1;
        var userName = "Hiba khlael";
        var firstName = "John";
        var lastName = "Smith";
        var email = "john.smith@gmail.com";
        Role adminRole = Role.ADMIN;
        Role userRole = Role.USER;
        Role guestRole = Role.GUEST;


        // Act
        var adminEmployee= new Employee(id, userName, firstName, lastName, email,adminRole);
        var userEmployee= new Employee(id, userName, firstName, lastName, email,userRole);
        var guestEmployee= new Employee(id, userName, firstName, lastName, email,guestRole);


        // Assert
        Assert.Equal(id, adminEmployee.Id);
        Assert.Equal(userName, adminEmployee.Username);

        Assert.Equal(firstName, adminEmployee.Firstname);
        Assert.Equal(lastName, adminEmployee.Lastname);
        Assert.Equal(email, adminEmployee.Email); 
        Assert.Equal(adminRole, adminEmployee.Role);

        
        //Assert Roles
        Assert.Equal(userRole, userEmployee.Role);
        Assert.Equal(guestRole, guestEmployee.Role);

    }
    //Issue

    [Fact]
    public void IssueTest()
    {
        //Arrange
        var issueId = Guid.NewGuid();
        var companyName = "TestCompany";
        var customerEmail = "john.smith@gmail.com";
        var subject = "issue with transport";
         IssueState newIssue =IssueState.NEW;
         IssueState openIssue =IssueState.OPEN;
         IssueState closedIssue =IssueState.CLOSED;

        var title = "issue with transport";
        var createdDate =DateTime.Now;
        var latestDate = new DateTime(2025, 05, 01, 10, 00, 00);
        
        //Act 
        var issue = new Issue(issueId, companyName, customerEmail, subject, openIssue, title, createdDate, latestDate);
       
        //Assert

        Assert.Equal(issueId, issue.Id);
        Assert.Equal(companyName, issue.CompanyName);
        Assert.Equal(customerEmail, issue.CustomerEmail);
        Assert.Equal(subject, issue.Subject);
        Assert.Equal(createdDate, issue.Created);
        Assert.Equal(latestDate, issue.Latest);
        
        Assert.Equal(IssueState.OPEN, issue.State);
         //Assert.Equal(IssueState.CLOSED, issue.State);
         //Assert.Equal(IssueState.NEW, issue.State);


    }
    //Messages
    [Fact]
    public void MessagesTest()
    {
        //Arrange
        var messageText = "hello this is my test message text";
        var messageSender="hiba khalael";
        var messageUserName="hiba";
        var messageDate=DateTime.Now;
        
        //Act
        var msg = new Message(messageText, messageSender, messageUserName, messageDate);
        
        //Assert
        Assert.Equal(messageText, msg.Text);
        Assert.Equal(messageSender, msg.Sender);
        Assert.Equal(messageUserName, msg.Username);
        Assert.Equal(messageDate, msg.Time);
        
        
        
    }
    //Users
    [Fact]
    public void UserTest()
    {
        //Arrange
        var userId = 1;
        var userName="hiba khalael";
        Role userRole=Role.USER;
        Role adminRole=Role.ADMIN;
        Role guestRole=Role.GUEST;

        var userCompany="company";
        var usercompanyId=1;
        
        //Act
        var user = new User(userId, userName,adminRole, usercompanyId,userCompany);
        
        //Assert
        
        Assert.Equal(userId, user.Id);
        Assert.Equal(userName, user.Username);
        Assert.Equal(adminRole, user.Role);
        // Assert.Equal(guestRole, user.Role);
        // Assert.Equal(userRole, user.Role);
        Assert.Equal(userCompany, user.Company);
        Assert.Equal(usercompanyId, user.CompanyId);

        
        
        
    }
    
    
}