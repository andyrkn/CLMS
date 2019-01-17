using System;
using System.Collections.Generic;
using System.Linq;
using CLMS.Notification.Domain;
using CLMS.Notification.Domain.Entities;
using CLMS.Notification.Domain.Repository;
using Moq;
using Xunit;

namespace CLMS.Notification.Business.Tests
{
    public class ContentAddedEventHandlerTests
    {
        private readonly Mock<IEmailService> emailServiceMock = new Mock<IEmailService>();
        private readonly Mock<IEventRepository> eventRepositoryMock = new Mock<IEventRepository>();
        private readonly Guid originId = new Guid("9D2A574F-4DA6-4053-B2C5-1C49C364B384");

        [Fact]
        public void Given_Handle_When_EventIsNull_Then_ShouldThrowException()
        {
            // act
            Action act = () => Handler().Handle(null);

            // assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void Given_Handle_When_EventIsNotFound_Then_ShouldNotSendEmails()
        {
            // arrange
            eventRepositoryMock.Setup(x => x.GetAll()).Returns(new List<Event>().AsQueryable());

            // act
            Handler().Handle(Event());

            // assert
            emailServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void Given_Handle_When_EventIsFoundAndHasSubscription_Then_ShouldSendEmails()
        {
            // arrange // arrange
            var @event = Domain.Entities.Event.Create(originId, "test");
            @event.Subscribe("test@email.com");
            eventRepositoryMock.Setup(x => x.GetAll()).Returns(new List<Event> {@event}.AsQueryable());
            
            // act
            Handler().Handle(Event());

            // assert
            emailServiceMock.Verify(x => x.Send(It.IsAny<EmailMessage>()));
        }

        private ContentAddedEventHandler Handler()
        {
            return new ContentAddedEventHandler(eventRepositoryMock.Object, emailServiceMock.Object);
        }

        private ContentAddedEvent Event()
        {
            return new ContentAddedEvent {OriginId = originId};
        }
    }
}