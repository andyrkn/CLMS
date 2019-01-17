using Xunit;

namespace CLMS.Notification.Domain.Tests
{
    public class EmailMessageTests
    {
        [Fact]
        public void Given_Create_When_ParametersArePassed_Then_ShouldCreateEmailMessage()
        {
            // act
            var emailMessage = EmailMessage.Create("test", "Test subject", "hello");

            // assert
            Assert.NotNull(emailMessage);
        }

        [Fact]
        public void Given_Create_When_ParametersAreGiven_Then_ShouldSetParameters()
        {
            // arrange
            var to = "test";
            var subject = "Test subject";
            var body = "hello";

            // act
            var emailMessage = EmailMessage.Create(to, subject, body);

            // assert
            Assert.Equal(to, emailMessage.To);
            Assert.Equal(subject, emailMessage.Subject);
            Assert.Equal(body, emailMessage.Body);
        }
    }
}