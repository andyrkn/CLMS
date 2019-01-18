using System;
using System.Threading;
using CLMS.Notification.Domain.Entities;
using CLMS.Notification.Domain.Repository;
using CSharpFunctionalExtensions;
using MediatR;
using Moq;
using Xunit;

namespace CLMS.Notification.Business.Tests
{
    public class UnsubscribeCommandHandlerTests
    {
        private readonly string email = "test@email.com";
        private readonly Guid eventId = new Guid("628F02A9-5D8E-4458-AD24-7E817ABFF54F");
        private readonly Mock<IEventRepository> eventRepositoryMock = new Mock<IEventRepository>();

        [Fact]
        public void Given_Handle_When_CommandIsNull_Then_ShouldThrowException()
        {
            // act
            Action act = () => CommandHandler().Handle(null, CancellationToken.None);

            // assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void Given_Handle_When_EventIsNotFound_Then_ShouldReturnFailedResult()
        {
            // arrange
            eventRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(() => null);

            // act
            var result = CommandHandler().Handle(Command(), CancellationToken.None).Result;

            // assert
            Assert.True(result.IsFailure);
        }

        [Fact]
        public void Given_Handle_When_EventIsFound_Then_ShouldUnsubscribeFromEvent()
        {
            // arrange
            var @event = Event.Create(eventId, "test");
            @event.Subscribe(email);
            eventRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(@event);

            // act
            var result = CommandHandler().Handle(Command(), CancellationToken.None).Result;

            // assert
            eventRepositoryMock.Verify(x => x.Update(It.IsAny<Event>()));
            eventRepositoryMock.Verify(x => x.SaveChanges());
        }

        private IRequestHandler<UnsubscribeCommand, Result> CommandHandler()
        {
            return new UnsubscribeCommandHandler(eventRepositoryMock.Object);
        }

        private UnsubscribeCommand Command()
        {
            return new UnsubscribeCommand(eventId, email);
        }
    }
}