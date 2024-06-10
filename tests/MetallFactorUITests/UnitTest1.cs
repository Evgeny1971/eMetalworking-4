using Xunit;
using MimeKit;

namespace MetallFactorUITests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var emailService = new EmailService();
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
}