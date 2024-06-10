using Xunit;
using MimeKit;
using MetallFactorUI.Services;

namespace MetallFactorUITests;

public class EmailServiceTests
{
    [Fact]
    public void SendEmail_ValidParameters_EmailSent()
    {
        var emailService = new EmailServiceSimple();
        emailService.SendEmail(
            "gen.vinnikov@gmail.com",
            "vika.vinnikov@gmail.com",
            "Test Subject",
            "Test Body",
            "smtp.gmail.com",
            587,
            "gen.vinnikov@gmail.com",
            "ronmoison2005" // or app-specific password
        );

    }
/*
    [Fact]
    public void ReceiveEmail_ValidParameters_EmailsReceived()
    {
        var emailService = new EmailService();
        var messages = emailService.ReceiveEmail(
            "imap.example.com",
            993,
            "username",
            "password"
        );

        Assert.NotNull(messages);
        Assert.True(messages.Count > 0);
    }
    */
}
