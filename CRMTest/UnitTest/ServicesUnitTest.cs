using Xunit;
using MimeKit;
using server.Config;
using server.Services;
 
namespace End2EndTest;
 
public class TestEmailService
{
    [Fact]
    public void ConstructedMimeMessage_ShouldMatchExpectedValues()
    {
        // Arrange
        var settings = new EmailSettings(
            "smtp.gmail.com",
            587,
            "procrm.feature@gmail.com",
            "vllt bfic kdey oxru"
        );
 
        var to = "recipient@example.com";
        var subject = "Test Subject";
        var body = "<p>Hello, this is a test.</p>";
 
        // Act
        var message = new MimeMessage();
        message.From.Add(MailboxAddress.Parse(settings.FromEmail));
        message.To.Add(MailboxAddress.Parse(to));
        message.Subject = subject;
        message.Body = new TextPart("html") { Text = body };
 
        // Assert
        Assert.Equal(subject, message.Subject);
        Assert.Single(message.To);
        Assert.Single(message.From);
        Assert.Contains(to, message.To.ToString());
        Assert.Contains(settings.FromEmail, message.From.ToString());
        Assert.Equal("text/html; charset=utf-8",
            message.Body.ContentType.MimeType + "; charset=" + message.Body.ContentType.Charset);
        Assert.Equal(body, ((TextPart)message.Body).Text);
    }
}